using OOP_finalProject.Base;
using OOP_finalProject.Customers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class InvoiceForm : Form
    {
        // const quản lý khách hàng
        private const string customerTypeVIP = "VIP";
        private const string customerTypeRegular = "Thường";
        private const string customerTypeGuest = "Khách lẻ";
        private const string customerTypeUnknown = "Không xác định";

        private static class UIColors
        {
            public static readonly Color Success = Color.FromArgb(46, 204, 113);
            public static readonly Color Danger = Color.FromArgb(192, 0, 0);
            public static readonly Color Gray = Color.Gray;
            public static readonly Color VIPGold = Color.Gold;
            public static readonly Color RegularBlue = Color.FromArgb(65, 105, 225);
        }

        // const thông báo trạng thái hóa đơn
        private const string msgNoInvoice = "Không có thông tin hóa đơn!";
        private const string msgSaveSuccess = "Lưu thông tin hóa đơn thành công!";
        private const string msgPrintSuccess = "In hóa đơn thành công!";
        private const string msgErrorTitle = "Lỗi";
        private const string msgInfoTitle = "Thông báo";

        private Invoice _invoice;
        private InvoiceData invoiceData = new InvoiceData();
        private BindingSource src = new BindingSource();


        public InvoiceForm()
        {
            InitializeComponent();
        }

        public InvoiceForm(Invoice invoice) : this()
        {
            _invoice = invoice;
        }


        private void FormInvoice_Load(object sender, EventArgs e)
        {
            try
            {
                if (_invoice == null)
                {
                    ShowError(msgNoInvoice);
                    this.Close();
                    return;
                }

                ConfigureDataGridView();  // tùy chỉnh dataGridView
                LoadInvoiceData();
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi tải hóa đơn: " + ex.Message);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (src != null)
            {
                src.Dispose();
            }
        }


        private void ConfigureDataGridView()
        {
            gridData.ReadOnly = true;
            gridData.AllowUserToAddRows = false;
            gridData.AutoGenerateColumns = true;
            gridData.DataSource = src;
        }

        private void LoadInvoiceData()
        {
            try
            {
                lblCode.Text = _invoice.Id ?? "N/A";
                lblCreatedDate.Text = _invoice.DateCreated.ToString("dd/MM/yyyy HH:mm");
                lblSellerName.Text = _invoice.CashierName;
                lblCustomerName.Text = _invoice.CustomerName;

                DisplayCustomerInfo();

                // hiển thị tổng quan hóa đơn
                DisplayInvoiceSummary();

                // hiển thi danh sách sản phẩm trong details
                src.DataSource = _invoice.InvoiceDetails;
                src.ResetBindings(true);

                // tiêu đề
                this.Text = "HÓA ĐƠN BÁN HÀNG - " + _invoice.Id;
            }
            catch (Exception ex)
            {
                ShowError("Lỗi tải dữ liệu hóa đơn: " + ex.Message);
            }
        }

        private void DisplayCustomerInfo()
        {
            if (_invoice.Customer == null)
            {
                lblCustomerName.Text = customerTypeGuest;
                lblCustomerName.ForeColor = UIColors.Gray;
                return;
            }

            //hiển thị CustomerTypeDisplay
            string displayName = _invoice.CustomerName + " (" + _invoice.CustomerTypeDisplay + ")";
            lblCustomerName.Text = displayName;

            // thiết lập màu theo loại khách hàng
            string customerType = GetCustomerType(_invoice.Customer);
            lblCustomerName.ForeColor = GetCustomerTypeColor(customerType);
        }

        private void DisplayInvoiceSummary()
        {
            decimal subTotal = _invoice.SumTotal;           
            decimal discountAmount = _invoice.DiscountAmount; 
            decimal finalTotal = _invoice.FinalTotal;       
            decimal discountPercentage = _invoice.DiscountPercentage;

            // tổng tiền
            lblSumTotal.Text = FormatCurrency(subTotal);

            // giảm giá
            if (discountPercentage > 0)
            {
                lblDiscount.Text = "-" + FormatCurrency(discountAmount) + " (" + discountPercentage + "%)";
                lblDiscount.ForeColor = UIColors.Success;
                lblDiscount.Font = new Font(lblDiscount.Font, FontStyle.Bold);
            }
            else
            {
                lblDiscount.Text = FormatCurrency(0);
                lblDiscount.ForeColor = UIColors.Gray;
            }

            //  thành tiền
            lblFinalTotal.Text = FormatCurrency(finalTotal);
            lblFinalTotal.ForeColor = UIColors.Danger;
            lblFinalTotal.Font = new Font(lblFinalTotal.Font.FontFamily, 12, FontStyle.Bold);
        }


        private string GetCustomerType(Customer customer)
        {
            if (customer == null)
                return customerTypeUnknown;

            if (customer is VIPCustomer)
                return customerTypeVIP;

            if (customer is RegularCustomer)
                return customerTypeRegular;

            return customerTypeUnknown;
        }

        private Color GetCustomerTypeColor(string customerType)
        {
            switch (customerType)
            {
                case customerTypeVIP:
                    return UIColors.VIPGold;
                case customerTypeRegular:
                    return UIColors.RegularBlue;
                default:
                    return UIColors.Gray;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_invoice == null)
                {
                    ShowError("Không có thông tin hóa đơn để lưu!");
                    return;
                }

                List<Invoice> invoices = invoiceData.GetData();
                if (invoices == null)
                {
                    invoices = new List<Invoice>();
                }

                // tìm hóa đơn theo Id
                int existingIndex = FindInvoiceIndex(invoices, _invoice.Id);

                if (existingIndex >= 0)
                {
                    invoices[existingIndex] = _invoice;
                }
                else
                {
                    invoices.Add(_invoice);
                }

                invoiceData.SaveData(invoices);

                ShowSuccess(msgSaveSuccess);
                UpdateSaveButtonState();
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi lưu hóa đơn: " + ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintInvoice();
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi in hóa đơn: " + ex.Message);
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (_invoice == null)
                {
                    ShowError("Không có thông tin hóa đơn để thanh toán!");
                    return;
                }

                // mở paymentForm
                PaymentForm paymentForm = new PaymentForm(_invoice);
                DialogResult result = paymentForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    ShowSuccess("Thanh toán thành công!");
                    // Có thể cập nhật trạng thái hóa đơn ở đây nếu cần
                }
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi mở form thanh toán: " + ex.Message);
            }
        }



        private void PrintInvoice()
        {
            try
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrintPage += new PrintPageEventHandler(PrintInvoicePage);

                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDoc;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                    ShowSuccess(msgPrintSuccess);
                }
            }
            catch (Exception ex)
            {
                ShowError("Lỗi in ấn: " + ex.Message);
            }
        }

        private void PrintInvoicePage(object sender, PrintPageEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                float yPos = 50;
                float leftMargin = 50;
                float rightMargin = e.PageBounds.Width - 50;

                Font titleFont = new Font("Arial", 16, FontStyle.Bold);
                Font headerFont = new Font("Arial", 12, FontStyle.Bold);
                Font normalFont = new Font("Arial", 10);
                Font smallFont = new Font("Arial", 9);

                // tiêu đề
                DrawCenteredText(g, "HÓA ĐƠN BÁN HÀNG", titleFont, yPos, e.PageBounds.Width);
                yPos += 40;

                // Thông tin hóa đơn 
                g.DrawString("Số hóa đơn: " + _invoice.Id, headerFont, Brushes.Black, leftMargin, yPos);
                g.DrawString("Ngày lập: " + _invoice.DateCreated.ToString("dd/MM/yyyy HH:mm"), headerFont,
                    Brushes.Black, rightMargin - 250, yPos);
                yPos += 30;

                // CashierName
                g.DrawString("Nhân viên: " + _invoice.CashierName, normalFont, Brushes.Black, leftMargin, yPos);
                yPos += 25;

                //  CustomerName và CustomerTypeDisplay 
                string customerDisplay = _invoice.CustomerName + " (" + _invoice.CustomerTypeDisplay + ")";
                g.DrawString("Khách hàng: " + customerDisplay, normalFont, Brushes.Black, leftMargin, yPos);
                yPos += 25;

                //  DiscountInfo từ Invoice
                if (_invoice.DiscountPercentage > 0)
                {
                    g.DrawString("Chương trình KM: " + _invoice.DiscountInfo, normalFont, Brushes.Black, leftMargin, yPos);
                    yPos += 25;
                }

                yPos += 15;

                // Header bảng
                DrawTableHeader(g, headerFont, leftMargin, yPos);
                yPos += 25;
                g.DrawLine(new Pen(Color.Black, 1), leftMargin, yPos, rightMargin, yPos);
                yPos += 10;

                // chi tiết sản phẩm
                yPos = DrawInvoiceDetails(g, normalFont, leftMargin, yPos, e);

                if (e.HasMorePages)
                    return;

                yPos += 20;

                // Tổng kết
                yPos = DrawInvoiceSummary(g, headerFont, leftMargin, yPos, rightMargin);

                // Chữ ký
                DrawSignatures(g, normalFont, smallFont, leftMargin, yPos);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi tạo nội dung in: " + ex.Message);
            }
        }

        private void DrawCenteredText(Graphics g, string text, Font font, float yPos, float pageWidth)
        {
            float textWidth = g.MeasureString(text, font).Width;
            float xPos = (pageWidth - textWidth) / 2;
            g.DrawString(text, font, Brushes.Black, xPos, yPos);
        }

        private void DrawTableHeader(Graphics g, Font font, float leftMargin, float yPos)
        {
            g.DrawString("STT", font, Brushes.Black, leftMargin, yPos);
            g.DrawString("Tên sản phẩm", font, Brushes.Black, leftMargin + 50, yPos);
            g.DrawString("SL", font, Brushes.Black, leftMargin + 300, yPos);
            g.DrawString("Đơn giá", font, Brushes.Black, leftMargin + 350, yPos);
            g.DrawString("Tổng tiền", font, Brushes.Black, leftMargin + 450, yPos);
        }

        private float DrawInvoiceDetails(Graphics g, Font font, float leftMargin, float yPos, PrintPageEventArgs e)
        {
            for (int i = 0; i < _invoice.InvoiceDetails.Count; i++)
            {
                InvoiceDetails detail = _invoice.InvoiceDetails[i];

                g.DrawString((i + 1).ToString(), font, Brushes.Black, leftMargin, yPos);
                g.DrawString(detail.ProductName, font, Brushes.Black, leftMargin + 50, yPos);
                g.DrawString(detail.Quantity.ToString(), font, Brushes.Black, leftMargin + 300, yPos);
                g.DrawString(detail.UnitPrice.ToString("N0"), font, Brushes.Black, leftMargin + 350, yPos);
                g.DrawString(detail.TotalPrice.ToString("N0"), font, Brushes.Black, leftMargin + 450, yPos);

                yPos += 20;

                if (yPos > e.PageBounds.Height - 150)
                {
                    e.HasMorePages = true;
                    return yPos;
                }
            }

            return yPos;
        }

        private float DrawInvoiceSummary(Graphics g, Font headerFont, float leftMargin,
            float yPos, float rightMargin)
        {
            g.DrawLine(new Pen(Color.Black, 1), leftMargin, yPos, rightMargin, yPos);
            yPos += 20;

            g.DrawString("Tổng tiền: " + FormatCurrency(_invoice.SumTotal),
                headerFont, Brushes.Black, leftMargin + 300, yPos);
            yPos += 25;

            if (_invoice.DiscountPercentage > 0)
            {
                g.DrawString("Giảm giá: " + _invoice.DiscountPercentage + "% (-" + FormatCurrency(_invoice.DiscountAmount) + ")",
                    headerFont, Brushes.Black, leftMargin + 300, yPos);
                yPos += 25;
            }

            g.DrawString("Thành tiền: " + FormatCurrency(_invoice.FinalTotal),
                new Font("Arial", 12, FontStyle.Bold), Brushes.Red, leftMargin + 300, yPos);
            yPos += 40;

            if (!string.IsNullOrEmpty(_invoice.PaymentMethod))
            {
                g.DrawString("Phương thức thanh toán: " + _invoice.PaymentMethod,
                    new Font("Arial", 10, FontStyle.Regular), Brushes.Black, leftMargin, yPos - 87);
                yPos += 20;
            }

            if (!string.IsNullOrEmpty(_invoice.TransactionId))
            {
                g.DrawString("Mã giao dịch: " + _invoice.TransactionId,
                    new Font("Arial", 10, FontStyle.Regular), Brushes.Black, leftMargin, yPos - 82);
                yPos += 20;
            }

            return yPos;
        }

        private void DrawSignatures(Graphics g, Font normalFont, Font smallFont, float leftMargin, float yPos)
        {
            g.DrawString("Người mua hàng", normalFont, Brushes.Black, leftMargin + 100, yPos);
            g.DrawString("Người bán hàng", normalFont, Brushes.Black, leftMargin + 400, yPos);
            yPos += 20;

            string customerName = _invoice.Customer != null ? _invoice.Customer.Name : customerTypeGuest;
            string cashierName = _invoice.Cashier != null ? _invoice.Cashier.Name : customerTypeUnknown;

            g.DrawString("(Ký, ghi rõ họ tên)", smallFont, Brushes.Black, leftMargin + 103, yPos);
            g.DrawString("(Ký, ghi rõ họ tên)", smallFont, Brushes.Black, leftMargin + 400, yPos);
            yPos += 20;

            // tên người mua hàng và bán hàng
            //g.DrawString(customerName, smallFont, Brushes.Black, leftMargin + 110, yPos);
            //g.DrawString(cashierName, smallFont, Brushes.Black, leftMargin + 420, yPos);
        }


        private int FindInvoiceIndex(List<Invoice> invoices, string invoiceId)
        {
            if (string.IsNullOrEmpty(invoiceId))
                return -1;

            for (int i = 0; i < invoices.Count; i++)
            {
                if (invoices[i] != null && invoices[i].Id != null &&
                    invoices[i].Id.Equals(invoiceId, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }

            return -1;
        }

        private string FormatCurrency(decimal amount)
        {
            return amount.ToString("N0") + " đ";
        }

        private void UpdateSaveButtonState()
        {
            btnSave.Enabled = false;
            btnSave.Text = "Đã Lưu";
            btnSave.BackColor = Color.LightGray;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, msgErrorTitle,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowSuccess(string message)
        {
            MessageBox.Show(message, msgInfoTitle,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}