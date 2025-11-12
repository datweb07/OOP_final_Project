using OOP_finalProject.Base;
using OOP_finalProject.Customers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class InvoiceForm : Form
    {
        #region Constants

        private const string CUSTOMER_TYPE_VIP = "VIP";
        private const string CUSTOMER_TYPE_REGULAR = "Thường";
        private const string CUSTOMER_TYPE_GUEST = "Khách lẻ";
        private const string CUSTOMER_TYPE_UNKNOWN = "Không xác định";

        private static class UIColors
        {
            public static readonly Color Success = Color.FromArgb(46, 204, 113);
            public static readonly Color Danger = Color.FromArgb(192, 0, 0);
            public static readonly Color Gray = Color.Gray;
            public static readonly Color VIPGold = Color.Gold;
            public static readonly Color RegularBlue = Color.FromArgb(65, 105, 225);
        }

        private const string MSG_NO_INVOICE = "Không có thông tin hóa đơn!";
        private const string MSG_SAVE_SUCCESS = "Lưu thông tin hóa đơn thành công!";
        private const string MSG_PRINT_SUCCESS = "In hóa đơn thành công!";
        private const string MSG_ERROR_TITLE = "Lỗi";
        private const string MSG_INFO_TITLE = "Thông báo";

        #endregion

        #region Fields

        private Invoice _invoice;
        private InvoiceData invoiceData = new InvoiceData();
        private BindingSource src = new BindingSource();

        #endregion

        #region Constructors

        public InvoiceForm()
        {
            InitializeComponent();
        }

        public InvoiceForm(Invoice invoice) : this()
        {
            _invoice = invoice;
        }

        #endregion

        #region Form Events

        private void FormInvoice_Load(object sender, EventArgs e)
        {
            try
            {
                if (_invoice == null)
                {
                    ShowError(MSG_NO_INVOICE);
                    this.Close();
                    return;
                }

                ConfigureDataGridView();
                LoadInvoiceData();
            }
            catch (Exception ex)
            {
                ShowError($"Lỗi khi tải hóa đơn: {ex.Message}");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            src?.Dispose();
        }

        #endregion

        #region Configuration

        private void ConfigureDataGridView()
        {
            gridData.ReadOnly = true;
            gridData.AllowUserToAddRows = false;
            gridData.AutoGenerateColumns = true;
            gridData.DataSource = src;
        }

        #endregion

        #region Load & Display Methods

        private void LoadInvoiceData()
        {
            try
            {
                // SỬ DỤNG CÁC PROPERTIES TỪ INVOICE CLASS
                // Hiển thị thông tin cơ bản
                lblCode.Text = _invoice.Id ?? "N/A";
                lblCreatedDate.Text = _invoice.DateCreated.ToString("dd/MM/yyyy HH:mm");

                // Sử dụng CashierName từ Invoice
                lblSellerName.Text = _invoice.CashierName;

                // Sử dụng CustomerName từ Invoice
                lblCustomerName.Text = _invoice.CustomerName;

                // Hiển thị thông tin customer với màu sắc
                DisplayCustomerInfo();

                // Hiển thị tổng kết hóa đơn - SỬ DỤNG COMPUTED PROPERTIES TỪ INVOICE
                DisplayInvoiceSummary();

                // Hiển thị danh sách sản phẩm
                src.DataSource = _invoice.InvoiceDetails;
                src.ResetBindings(true);

                // Cập nhật tiêu đề form
                this.Text = $"HÓA ĐƠN BÁN HÀNG - {_invoice.Id}";
            }
            catch (Exception ex)
            {
                ShowError($"Lỗi tải dữ liệu hóa đơn: {ex.Message}");
            }
        }

        private void DisplayCustomerInfo()
        {
            if (_invoice.Customer == null)
            {
                lblCustomerName.Text = CUSTOMER_TYPE_GUEST;
                lblCustomerName.ForeColor = UIColors.Gray;
                return;
            }

            // SỬ DỤNG CustomerTypeDisplay TỪ INVOICE
            string displayName = $"{_invoice.CustomerName} ({_invoice.CustomerTypeDisplay})";
            lblCustomerName.Text = displayName;

            // Set màu theo loại khách hàng
            string customerType = GetCustomerType(_invoice.Customer);
            lblCustomerName.ForeColor = GetCustomerTypeColor(customerType);
        }

        private void DisplayInvoiceSummary()
        {
            // SỬ DỤNG TRỰC TIẾP CÁC COMPUTED PROPERTIES TỪ INVOICE CLASS
            decimal subTotal = _invoice.SumTotal;           // Computed property
            decimal discountAmount = _invoice.DiscountAmount; // Computed property
            decimal finalTotal = _invoice.FinalTotal;       // Computed property
            decimal discountPercentage = _invoice.DiscountPercentage; // Computed property

            // Hiển thị tổng tiền
            lblSumTotal.Text = FormatCurrency(subTotal);

            // Hiển thị giảm giá
            if (discountPercentage > 0)
            {
                lblDiscount.Text = $"-{FormatCurrency(discountAmount)} ({discountPercentage}%)";
                lblDiscount.ForeColor = UIColors.Success;
                lblDiscount.Font = new Font(lblDiscount.Font, FontStyle.Bold);
            }
            else
            {
                lblDiscount.Text = FormatCurrency(0);
                lblDiscount.ForeColor = UIColors.Gray;
            }

            // Hiển thị thành tiền
            lblFinalTotal.Text = FormatCurrency(finalTotal);
            lblFinalTotal.ForeColor = UIColors.Danger;
            lblFinalTotal.Font = new Font(lblFinalTotal.Font.FontFamily, 12, FontStyle.Bold);
        }

        #endregion

        #region Customer Helper Methods

        private string GetCustomerType(Customer customer)
        {
            if (customer == null)
                return CUSTOMER_TYPE_UNKNOWN;

            if (customer is VIPCustomer)
                return CUSTOMER_TYPE_VIP;

            if (customer is RegularCustomer)
                return CUSTOMER_TYPE_REGULAR;

            return CUSTOMER_TYPE_UNKNOWN;
        }

        private Color GetCustomerTypeColor(string customerType)
        {
            switch (customerType)
            {
                case CUSTOMER_TYPE_VIP:
                    return UIColors.VIPGold;
                case CUSTOMER_TYPE_REGULAR:
                    return UIColors.RegularBlue;
                default:
                    return UIColors.Gray;
            }
        }

        #endregion

        #region Button Events

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_invoice == null)
                {
                    ShowError("Không có thông tin hóa đơn để lưu!");
                    return;
                }

                List<Invoice> invoices = invoiceData.GetData() ?? new List<Invoice>();

                // Tìm hóa đơn theo Id
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

                ShowSuccess(MSG_SAVE_SUCCESS);
                UpdateSaveButtonState();
            }
            catch (Exception ex)
            {
                ShowError($"Lỗi khi lưu hóa đơn: {ex.Message}");
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
                ShowError($"Lỗi khi in hóa đơn: {ex.Message}");
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

                // Mở form thanh toán QR
                QRPaymentForm paymentForm = new QRPaymentForm(_invoice);
                DialogResult result = paymentForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    ShowSuccess("Thanh toán thành công!");
                    // Có thể cập nhật trạng thái hóa đơn ở đây nếu cần
                }
            }
            catch (Exception ex)
            {
                ShowError($"Lỗi khi mở form thanh toán: {ex.Message}");
            }
        }

        #endregion

        #region Print Methods

        private void PrintInvoice()
        {
            try
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrintPage += PrintInvoicePage;

                PrintDialog printDialog = new PrintDialog { Document = printDoc };

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                    ShowSuccess(MSG_PRINT_SUCCESS);
                }
            }
            catch (Exception ex)
            {
                ShowError($"Lỗi in ấn: {ex.Message}");
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

                // Fonts
                Font titleFont = new Font("Arial", 16, FontStyle.Bold);
                Font headerFont = new Font("Arial", 12, FontStyle.Bold);
                Font normalFont = new Font("Arial", 10);
                Font smallFont = new Font("Arial", 9);

                // Tiêu đề
                DrawCenteredText(g, "HÓA ĐƠN BÁN HÀNG", titleFont, yPos, e.PageBounds.Width);
                yPos += 40;

                // Thông tin hóa đơn - SỬ DỤNG PROPERTIES TỪ INVOICE
                g.DrawString($"Số hóa đơn: {_invoice.Id}", headerFont, Brushes.Black, leftMargin, yPos);
                g.DrawString($"Ngày lập: {_invoice.DateCreated:dd/MM/yyyy HH:mm}", headerFont,
                    Brushes.Black, rightMargin - 250, yPos);
                yPos += 30;

                // Sử dụng CashierName từ Invoice
                g.DrawString($"Nhân viên: {_invoice.CashierName}", normalFont, Brushes.Black, leftMargin, yPos);
                yPos += 25;

                // Sử dụng CustomerName và CustomerTypeDisplay từ Invoice
                string customerDisplay = $"{_invoice.CustomerName} ({_invoice.CustomerTypeDisplay})";
                g.DrawString($"Khách hàng: {customerDisplay}", normalFont, Brushes.Black, leftMargin, yPos);
                yPos += 25;

                // Sử dụng DiscountInfo từ Invoice
                if (_invoice.DiscountPercentage > 0)
                {
                    g.DrawString($"Chương trình KM: {_invoice.DiscountInfo}", normalFont, Brushes.Black, leftMargin, yPos);
                    yPos += 25;
                }

                yPos += 15;

                // Header bảng
                DrawTableHeader(g, headerFont, leftMargin, yPos);
                yPos += 25;
                g.DrawLine(new Pen(Color.Black, 1), leftMargin, yPos, rightMargin, yPos);
                yPos += 10;

                // Chi tiết sản phẩm
                yPos = DrawInvoiceDetails(g, normalFont, leftMargin, yPos, e);

                if (e.HasMorePages)
                    return;

                yPos += 20;

                // Tổng kết - SỬ DỤNG COMPUTED PROPERTIES TỪ INVOICE
                yPos = DrawInvoiceSummary(g, headerFont, leftMargin, yPos, rightMargin);

                // Chữ ký
                DrawSignatures(g, normalFont, smallFont, leftMargin, yPos);
            }
            catch (Exception ex)
            {
                ShowError($"Lỗi tạo nội dung in: {ex.Message}");
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
                var detail = _invoice.InvoiceDetails[i];

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

            // SỬ DỤNG COMPUTED PROPERTIES TỪ INVOICE
            g.DrawString($"Tổng tiền: {FormatCurrency(_invoice.SumTotal)}",
                headerFont, Brushes.Black, leftMargin + 300, yPos);
            yPos += 25;

            if (_invoice.DiscountPercentage > 0)
            {
                g.DrawString($"Giảm giá: {_invoice.DiscountPercentage}% (-{FormatCurrency(_invoice.DiscountAmount)})",
                    headerFont, Brushes.Black, leftMargin + 300, yPos);
                yPos += 25;
            }

            g.DrawString($"Thành tiền: {FormatCurrency(_invoice.FinalTotal)}",
                new Font("Arial", 12, FontStyle.Bold), Brushes.Red, leftMargin + 300, yPos);
            yPos += 40;

            if (!string.IsNullOrEmpty(_invoice.PaymentMethod))
            {
                g.DrawString($"Phương thức thanh toán: {_invoice.PaymentMethod}",
                    new Font("Arial", 10, FontStyle.Regular), Brushes.Black, leftMargin, yPos - 87);
                yPos += 20;
            }

            if (!string.IsNullOrEmpty(_invoice.TransactionId))
            {
                g.DrawString($"Mã giao dịch: {_invoice.TransactionId}",
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

            string customerName = _invoice.Customer?.Name ?? CUSTOMER_TYPE_GUEST;
            string cashierName = _invoice.Cashier?.Name ?? CUSTOMER_TYPE_UNKNOWN;

            g.DrawString("(Ký, ghi rõ họ tên)", smallFont, Brushes.Black, leftMargin + 103, yPos);
            g.DrawString("(Ký, ghi rõ họ tên)", smallFont, Brushes.Black, leftMargin + 400, yPos);
            yPos += 20;

            // tên người mua hàng và bán hàng
            //g.DrawString(customerName, smallFont, Brushes.Black, leftMargin + 110, yPos);
            //g.DrawString(cashierName, smallFont, Brushes.Black, leftMargin + 420, yPos);
        }


        #endregion

        #region Helper Methods

        private int FindInvoiceIndex(List<Invoice> invoices, string invoiceId)
        {
            if (string.IsNullOrEmpty(invoiceId))
                return -1;

            for (int i = 0; i < invoices.Count; i++)
            {
                if (invoices[i]?.Id != null &&
                    invoices[i].Id.Equals(invoiceId, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }

            return -1;
        }

        private string FormatCurrency(decimal amount)
        {
            return $"{amount:N0} đ";
        }

        private void UpdateSaveButtonState()
        {
            btnSave.Enabled = false;
            btnSave.Text = "Đã Lưu";
            btnSave.BackColor = Color.LightGray;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, MSG_ERROR_TITLE,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowSuccess(string message)
        {
            MessageBox.Show(message, MSG_INFO_TITLE,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}