//using OOP_finalProject.Base;
//using OOP_finalProject.Customers; // ✅ Thêm using statement
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Drawing.Printing;
//using System.Windows.Forms;

//namespace OOP_finalProject
//{
//    public partial class InvoiceForm : Form
//    {
//        #region Constants

//        // ✅ Constants cho customer types
//        private const string CUSTOMER_TYPE_VIP = "VIP";
//        private const string CUSTOMER_TYPE_REGULAR = "Thường";
//        private const string CUSTOMER_TYPE_GUEST = "Khách lẻ";
//        private const string CUSTOMER_TYPE_UNKNOWN = "Không xác định";

//        // ✅ Constants cho UI Colors
//        private static class UIColors
//        {
//            public static readonly Color Success = Color.FromArgb(46, 204, 113);
//            public static readonly Color Danger = Color.FromArgb(192, 0, 0);
//            public static readonly Color Gray = Color.Gray;
//            public static readonly Color VIPGold = Color.Gold;
//            public static readonly Color RegularBlue = Color.FromArgb(65, 105, 225);
//        }

//        // ✅ Constants cho messages
//        private const string MSG_NO_INVOICE = "Không có thông tin hóa đơn!";
//        private const string MSG_SAVE_SUCCESS = "Lưu thông tin hóa đơn thành công!";
//        private const string MSG_PRINT_SUCCESS = "In hóa đơn thành công!";
//        private const string MSG_ERROR_TITLE = "Lỗi";
//        private const string MSG_INFO_TITLE = "Thông báo";

//        #endregion

//        #region Fields

//        private Invoice _invoice;
//        private InvoiceData invoiceData = new InvoiceData();
//        private BindingSource src = new BindingSource();

//        #endregion

//        #region Constructors

//        public InvoiceForm()
//        {
//            InitializeComponent();
//        }

//        public InvoiceForm(Invoice invoice) : this()
//        {
//            _invoice = invoice;
//        }

//        #endregion

//        #region Form Events

//        private void FormInvoice_Load(object sender, EventArgs e)
//        {
//            try
//            {
//                if (_invoice == null)
//                {
//                    ShowError(MSG_NO_INVOICE);
//                    this.Close();
//                    return;
//                }

//                ConfigureDataGridView();
//                LoadInvoiceData();
//                UpdateStatistics();
//            }
//            catch (Exception ex)
//            {
//                ShowError($"Lỗi khi tải hóa đơn: {ex.Message}");
//            }
//        }

//        protected override void OnFormClosing(FormClosingEventArgs e)
//        {
//            base.OnFormClosing(e);
//            src?.Dispose();
//        }

//        #endregion

//        #region Configuration

//        private void ConfigureDataGridView()
//        {
//            gridData.ReadOnly = true;
//            gridData.AllowUserToAddRows = false;
//            gridData.AutoGenerateColumns = false;
//            gridData.DataSource = src;

//            // Định dạng cột
//            ConfigureColumn("Column3", DataGridViewContentAlignment.MiddleRight);
//            ConfigureColumn("Column4", DataGridViewContentAlignment.MiddleRight, "#,###");
//            ConfigureColumn("Column5", DataGridViewContentAlignment.MiddleRight, "#,###");
//        }

//        private void ConfigureColumn(string columnName,
//            DataGridViewContentAlignment alignment = DataGridViewContentAlignment.NotSet,
//            string format = null)
//        {
//            if (gridData.Columns[columnName] != null)
//            {
//                if (alignment != DataGridViewContentAlignment.NotSet)
//                    gridData.Columns[columnName].DefaultCellStyle.Alignment = alignment;

//                if (!string.IsNullOrEmpty(format))
//                    gridData.Columns[columnName].DefaultCellStyle.Format = format;
//            }
//        }

//        #endregion

//        #region Customer Display Methods

//        /// <summary>
//        /// ✅ Strategy Pattern: Lấy loại khách hàng
//        /// </summary>
//        private string GetCustomerType(Customer customer)
//        {
//            if (customer == null)
//                return CUSTOMER_TYPE_UNKNOWN;

//            // ✅ Không cần namespace đầy đủ vì đã có using
//            if (customer is VIPCustomer)
//                return CUSTOMER_TYPE_VIP;

//            if (customer is RegularCustomer)
//                return CUSTOMER_TYPE_REGULAR;

//            return CUSTOMER_TYPE_UNKNOWN;
//        }

//        /// <summary>
//        /// ✅ Lấy tên hiển thị khách hàng với loại
//        /// </summary>
//        private string GetCustomerDisplayName(Customer customer)
//        {
//            if (customer == null)
//                return CUSTOMER_TYPE_GUEST;

//            string customerType = GetCustomerType(customer);
//            return $"{customer.Name} ({customerType})";
//        }

//        /// <summary>
//        /// ✅ Lấy màu hiển thị theo loại khách hàng
//        /// </summary>
//        private Color GetCustomerTypeColor(string customerType)
//        {
//            switch (customerType)
//            {
//                case CUSTOMER_TYPE_VIP:
//                    return UIColors.VIPGold;
//                case CUSTOMER_TYPE_REGULAR:
//                    return UIColors.RegularBlue;
//                default:
//                    return UIColors.Gray;
//            }
//        }

//        #endregion

//        #region Load & Display Methods

//        private void LoadInvoiceData()
//        {
//            try
//            {
//                // Hiển thị thông tin cơ bản
//                lblCode.Text = _invoice.Id ?? "N/A";
//                lblCreatedDate.Text = _invoice.DateCreated.ToString("dd/MM/yyyy HH:mm");
//                lblSellerName.Text = _invoice.Cashier?.Name ?? CUSTOMER_TYPE_UNKNOWN;

//                // ✅ Sử dụng method riêng để hiển thị customer
//                DisplayCustomerInfo();

//                // Tính toán và hiển thị chi tiết hóa đơn
//                CalculateInvoiceDetails();

//                // Hiển thị danh sách sản phẩm
//                src.DataSource = _invoice.InvoiceDetails;
//                src.ResetBindings(true);

//                // Cập nhật tiêu đề form
//                this.Text = $"HÓA ĐƠN BÁN HÀNG - {_invoice.Id}";
//            }
//            catch (Exception ex)
//            {
//                ShowError($"Lỗi tải dữ liệu hóa đơn: {ex.Message}");
//            }
//        }

//        /// <summary>
//        /// ✅ Hiển thị thông tin khách hàng
//        /// </summary>
//        private void DisplayCustomerInfo()
//        {
//            if (_invoice.Customer == null)
//            {
//                lblCustomerName.Text = CUSTOMER_TYPE_GUEST;
//                lblCustomerName.ForeColor = UIColors.Gray;
//                return;
//            }

//            // ✅ Sử dụng method để lấy display name
//            string displayName = GetCustomerDisplayName(_invoice.Customer);
//            lblCustomerName.Text = displayName;

//            // ✅ Set màu theo loại khách hàng
//            string customerType = GetCustomerType(_invoice.Customer);
//            lblCustomerName.ForeColor = GetCustomerTypeColor(customerType);

//            // Log để debug (có thể bỏ trong production)
//            LogCustomerInfo(_invoice.Customer);
//        }

//        /// <summary>
//        /// ✅ Log thông tin customer để debug
//        /// </summary>
//        private void LogCustomerInfo(Customer customer)
//        {
//#if DEBUG
//            Console.WriteLine("=== Customer Info ===");
//            Console.WriteLine($"Customer object: {customer}");
//            Console.WriteLine($"Customer Name: {customer?.Name}");
//            Console.WriteLine($"Customer Type: {GetCustomerType(customer)}");
//            Console.WriteLine($"Is VIP: {customer is VIPCustomer}");
//            Console.WriteLine($"Is Regular: {customer is RegularCustomer}");
//            Console.WriteLine("====================");
//#endif
//        }

//        private void CalculateInvoiceDetails()
//        {
//            try
//            {
//                // Sử dụng các thuộc tính đã có của Invoice
//                decimal sumTotal = _invoice.SumTotal;
//                decimal discountPercentage = _invoice.DiscountPercentage;
//                decimal discountAmount = _invoice.DiscountAmount;
//                decimal finalTotal = _invoice.FinalTotal;

//                DisplayInvoiceSummary(sumTotal, discountAmount, finalTotal, discountPercentage);
//            }
//            catch (Exception ex)
//            {
//                ShowError($"Lỗi tính toán hóa đơn: {ex.Message}");
//            }
//        }

//        private void DisplayInvoiceSummary(decimal sumTotal, decimal discountAmount,
//            decimal finalTotal, decimal discountPercentage)
//        {
//            // Hiển thị tổng tiền
//            lblSumTotal.Text = FormatCurrency(sumTotal);

//            // Hiển thị giảm giá
//            if (discountPercentage > 0)
//            {
//                lblDiscount.Text = $"-{FormatCurrency(discountAmount)} ({discountPercentage}%)";
//                lblDiscount.ForeColor = UIColors.Success;
//                lblDiscount.Font = new Font(lblDiscount.Font, FontStyle.Bold);
//            }
//            else
//            {
//                lblDiscount.Text = FormatCurrency(0);
//                lblDiscount.ForeColor = UIColors.Gray;
//            }

//            // Hiển thị thành tiền
//            lblFinalTotal.Text = FormatCurrency(finalTotal);
//            lblFinalTotal.ForeColor = UIColors.Danger;
//            lblFinalTotal.Font = new Font(lblFinalTotal.Font.FontFamily, 12, FontStyle.Bold);
//        }

//        private void UpdateStatistics()
//        {
//            try
//            {
//                if (_invoice?.InvoiceDetails == null)
//                    return;

//                int itemCount = _invoice.InvoiceDetails.Count;
//                int productCount = 0;

//                for (int i = 0; i < _invoice.InvoiceDetails.Count; i++)
//                {
//                    productCount += (int)_invoice.InvoiceDetails[i].Quantity;
//                }

//                // Có thể hiển thị vào label nếu có
//                Console.WriteLine($"Items: {itemCount}, Products: {productCount}");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Lỗi cập nhật thống kê: {ex.Message}");
//            }
//        }

//        #endregion

//        #region Button Events

//        private void btnSave_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                if (_invoice == null)
//                {
//                    ShowError("Không có thông tin hóa đơn để lưu!");
//                    return;
//                }

//                List<Invoice> invoices = invoiceData.GetData() ?? new List<Invoice>();

//                // Tìm hóa đơn theo Id
//                int existingIndex = FindInvoiceIndex(invoices, _invoice.Id);

//                if (existingIndex >= 0)
//                {
//                    invoices[existingIndex] = _invoice;
//                }
//                else
//                {
//                    invoices.Add(_invoice);
//                }

//                invoiceData.SaveData(invoices);

//                ShowSuccess(MSG_SAVE_SUCCESS);
//                UpdateSaveButtonState();
//            }
//            catch (Exception ex)
//            {
//                ShowError($"Lỗi khi lưu hóa đơn: {ex.Message}");
//            }
//        }

//        private void btnPrint_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                PrintInvoice();
//            }
//            catch (Exception ex)
//            {
//                ShowError($"Lỗi khi in hóa đơn: {ex.Message}");
//            }
//        }

//        #endregion

//        #region Print Methods

//        private void PrintInvoice()
//        {
//            try
//            {
//                PrintDocument printDoc = new PrintDocument();
//                printDoc.PrintPage += PrintInvoicePage;

//                PrintDialog printDialog = new PrintDialog { Document = printDoc };

//                if (printDialog.ShowDialog() == DialogResult.OK)
//                {
//                    printDoc.Print();
//                    ShowSuccess(MSG_PRINT_SUCCESS);
//                }
//            }
//            catch (Exception ex)
//            {
//                ShowError($"Lỗi in ấn: {ex.Message}");
//            }
//        }

//        private void PrintInvoicePage(object sender, PrintPageEventArgs e)
//        {
//            try
//            {
//                Graphics g = e.Graphics;
//                float yPos = 50;
//                float leftMargin = 50;
//                float rightMargin = e.PageBounds.Width - 50;

//                // Fonts
//                Font titleFont = new Font("Arial", 16, FontStyle.Bold);
//                Font headerFont = new Font("Arial", 12, FontStyle.Bold);
//                Font normalFont = new Font("Arial", 10);
//                Font smallFont = new Font("Arial", 9);

//                // Tiêu đề
//                DrawCenteredText(g, "HÓA ĐƠN BÁN HÀNG", titleFont, yPos, e.PageBounds.Width);
//                yPos += 40;

//                // Thông tin hóa đơn
//                g.DrawString($"Số hóa đơn: {_invoice.Id}", headerFont, Brushes.Black, leftMargin, yPos);
//                g.DrawString($"Ngày lập: {_invoice.DateCreated:dd/MM/yyyy HH:mm}", headerFont,
//                    Brushes.Black, rightMargin - 250, yPos);
//                yPos += 30;

//                g.DrawString($"Nhân viên: {_invoice.Cashier?.Name ?? CUSTOMER_TYPE_UNKNOWN}",
//                    normalFont, Brushes.Black, leftMargin, yPos);
//                yPos += 25;

//                // ✅ Sử dụng method để lấy customer display
//                string customerDisplay = GetCustomerDisplayName(_invoice.Customer);
//                g.DrawString($"Khách hàng: {customerDisplay}", normalFont, Brushes.Black, leftMargin, yPos);
//                yPos += 40;

//                // Header bảng
//                DrawTableHeader(g, headerFont, leftMargin, yPos);
//                yPos += 25;
//                g.DrawLine(new Pen(Color.Black, 1), leftMargin, yPos, rightMargin, yPos);
//                yPos += 10;

//                // Chi tiết sản phẩm
//                yPos = DrawInvoiceDetails(g, normalFont, leftMargin, yPos, e);

//                if (e.HasMorePages)
//                    return;

//                yPos += 20;

//                // Tổng kết
//                yPos = DrawInvoiceSummary(g, headerFont, leftMargin, yPos, rightMargin);

//                // Chữ ký
//                DrawSignatures(g, normalFont, smallFont, leftMargin, yPos);
//            }
//            catch (Exception ex)
//            {
//                ShowError($"Lỗi tạo nội dung in: {ex.Message}");
//            }
//        }

//        private void DrawCenteredText(Graphics g, string text, Font font, float yPos, float pageWidth)
//        {
//            float textWidth = g.MeasureString(text, font).Width;
//            float xPos = (pageWidth - textWidth) / 2;
//            g.DrawString(text, font, Brushes.Black, xPos, yPos);
//        }

//        private void DrawTableHeader(Graphics g, Font font, float leftMargin, float yPos)
//        {
//            g.DrawString("STT", font, Brushes.Black, leftMargin, yPos);
//            g.DrawString("Tên sản phẩm", font, Brushes.Black, leftMargin + 50, yPos);
//            g.DrawString("SL", font, Brushes.Black, leftMargin + 300, yPos);
//            g.DrawString("Đơn giá", font, Brushes.Black, leftMargin + 350, yPos);
//            g.DrawString("Thành tiền", font, Brushes.Black, leftMargin + 450, yPos);
//        }

//        private float DrawInvoiceDetails(Graphics g, Font font, float leftMargin, float yPos, PrintPageEventArgs e)
//        {
//            for (int i = 0; i < _invoice.InvoiceDetails.Count; i++)
//            {
//                var detail = _invoice.InvoiceDetails[i];
//                decimal totalPrice = detail.Quantity * detail.UnitPrice;

//                g.DrawString((i + 1).ToString(), font, Brushes.Black, leftMargin, yPos);
//                g.DrawString(detail.ProductName, font, Brushes.Black, leftMargin + 50, yPos);
//                g.DrawString(detail.Quantity.ToString(), font, Brushes.Black, leftMargin + 300, yPos);
//                g.DrawString(detail.UnitPrice.ToString("#,###"), font, Brushes.Black, leftMargin + 350, yPos);
//                g.DrawString(totalPrice.ToString("#,###"), font, Brushes.Black, leftMargin + 450, yPos);

//                yPos += 20;

//                if (yPos > e.PageBounds.Height - 150)
//                {
//                    e.HasMorePages = true;
//                    return yPos;
//                }
//            }

//            return yPos;
//        }

//        private float DrawInvoiceSummary(Graphics g, Font headerFont, float leftMargin,
//            float yPos, float rightMargin)
//        {
//            g.DrawLine(new Pen(Color.Black, 1), leftMargin, yPos, rightMargin, yPos);
//            yPos += 20;

//            g.DrawString($"Tổng tiền: {FormatCurrency(_invoice.SumTotal)}",
//                headerFont, Brushes.Black, leftMargin + 300, yPos);
//            yPos += 25;

//            if (_invoice.DiscountPercentage > 0)
//            {
//                g.DrawString($"Giảm giá: {_invoice.DiscountPercentage}% (-{FormatCurrency(_invoice.DiscountAmount)})",
//                    headerFont, Brushes.Black, leftMargin + 300, yPos);
//                yPos += 25;
//            }

//            g.DrawString($"Thành tiền: {FormatCurrency(_invoice.FinalTotal)}",
//                new Font("Arial", 12, FontStyle.Bold), Brushes.Red, leftMargin + 300, yPos);
//            yPos += 40;

//            return yPos;
//        }

//        private void DrawSignatures(Graphics g, Font normalFont, Font smallFont, float leftMargin, float yPos)
//        {
//            g.DrawString("Người mua hàng", normalFont, Brushes.Black, leftMargin + 100, yPos);
//            g.DrawString("Người bán hàng", normalFont, Brushes.Black, leftMargin + 400, yPos);
//            yPos += 20;

//            string customerName = _invoice.Customer?.Name ?? CUSTOMER_TYPE_GUEST;
//            string cashierName = _invoice.Cashier?.Name ?? CUSTOMER_TYPE_UNKNOWN;

//            g.DrawString(customerName, smallFont, Brushes.Black, leftMargin + 110, yPos + 15);
//            g.DrawString(cashierName, smallFont, Brushes.Black, leftMargin + 420, yPos + 15);
//        }

//        #endregion

//        #region Helper Methods

//        /// <summary>
//        /// ✅ Tìm index của invoice trong list
//        /// </summary>
//        private int FindInvoiceIndex(List<Invoice> invoices, string invoiceId)
//        {
//            if (string.IsNullOrEmpty(invoiceId))
//                return -1;

//            for (int i = 0; i < invoices.Count; i++)
//            {
//                if (invoices[i]?.Id != null &&
//                    invoices[i].Id.Equals(invoiceId, StringComparison.OrdinalIgnoreCase))
//                {
//                    return i;
//                }
//            }

//            return -1;
//        }

//        /// <summary>
//        /// ✅ Format tiền tệ
//        /// </summary>
//        private string FormatCurrency(decimal amount)
//        {
//            return $"{amount:N0} đ";
//        }

//        /// <summary>
//        /// ✅ Cập nhật trạng thái button Save
//        /// </summary>
//        private void UpdateSaveButtonState()
//        {
//            btnSave.Enabled = false;
//            btnSave.Text = "Đã Lưu";
//            btnSave.BackColor = Color.FromArgb(149, 165, 166);
//        }

//        /// <summary>
//        /// ✅ Hiển thị thông báo lỗi
//        /// </summary>
//        private void ShowError(string message)
//        {
//            MessageBox.Show(message, MSG_ERROR_TITLE,
//                MessageBoxButtons.OK, MessageBoxIcon.Error);
//        }

//        /// <summary>
//        /// ✅ Hiển thị thông báo thành công
//        /// </summary>
//        private void ShowSuccess(string message)
//        {
//            MessageBox.Show(message, MSG_INFO_TITLE,
//                MessageBoxButtons.OK, MessageBoxIcon.Information);
//        }

//        #endregion
//    }
//}




//using OOP_finalProject.Customers;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Drawing.Printing;
//using System.Linq;
//using System.Windows.Forms;

//namespace OOP_finalProject
//{
//    public partial class InvoiceForm : Form
//    {
//        private Invoice _invoice;
//        private InvoiceData invoiceData = new InvoiceData();
//        private BindingSource src = new BindingSource();

//        public InvoiceForm()
//        {
//            InitializeComponent();
//        }

//        public InvoiceForm(Invoice invoice) : this()
//        {
//            _invoice = invoice;
//        }

//        private void FormInvoice_Load(object sender, EventArgs e)
//        {
//            try
//            {
//                if (_invoice == null)
//                {
//                    MessageBox.Show("Không có thông tin hóa đơn!", "Lỗi",
//                        MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    this.Close();
//                    return;
//                }

//                ConfigureDataGridView();
//                LoadInvoiceData();
//                UpdateStatistics();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Lỗi khi tải hóa đơn: {ex.Message}", "Lỗi",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void ConfigureDataGridView()
//        {
//            gridData.ReadOnly = true;
//            gridData.AllowUserToAddRows = false;
//            gridData.AutoGenerateColumns = false;
//            gridData.DataSource = src;

//            // Định dạng cột
//            gridData.Columns["Column4"].DefaultCellStyle.Format = "#,###";
//            gridData.Columns["Column5"].DefaultCellStyle.Format = "#,###";
//            gridData.Columns["Column3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
//            gridData.Columns["Column4"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
//            gridData.Columns["Column5"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
//        }

//        private void LoadInvoiceData()
//        {
//            // Hiển thị thông tin cơ bản
//            lblCode.Text = _invoice.Id;
//            lblCreatedDate.Text = _invoice.DateCreated.ToString("dd/MM/yyyy");
//            lblSellerName.Text = _invoice.Cashier?.Name ?? "Không xác định";
//            lblCustomerName.Text = _invoice.Customer?.Name ?? "Khách lẻ";

//            // Tính toán và hiển thị chi tiết hóa đơn
//            CalculateInvoiceDetails();

//            // Hiển thị danh sách sản phẩm
//            src.DataSource = _invoice.InvoiceDetails;
//            src.ResetBindings(true);

//            // Cập nhật tiêu đề form
//            this.Text = $"HÓA ĐƠN BÁN HÀNG - {_invoice.Id}";
//        }

//        private void CalculateInvoiceDetails()
//        {
//            try
//            {
//                // Sử dụng các thuộc tính đã có của Invoice
//                decimal sumTotal = _invoice.SumTotal;
//                decimal discountPercentage = _invoice.DiscountPercentage;
//                decimal discountAmount = _invoice.DiscountAmount;
//                decimal finalTotal = _invoice.FinalTotal;

//                DisplayInvoiceSummary(sumTotal, discountAmount, finalTotal, discountPercentage);
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Lỗi tính toán hóa đơn: {ex.Message}");
//            }
//        }

//        //private void ShowError(string message)
//        //{
//        //    MessageBox.Show(message, MSG_ERROR_TITLE,
//        //        MessageBoxButtons.OK, MessageBoxIcon.Error);
//        //}

//        private void DisplayInvoiceSummary(decimal sumTotal, decimal discountAmount, decimal finalTotal, decimal discountPercentage)
//        {
//            lblSumTotal.Text = $"{sumTotal:N0} đ";
//            lblFinalTotal.Text = $"{finalTotal:N0} đ";

//            if (discountPercentage > 0)
//            {
//                lblDiscount.Text = $"-{discountAmount:N0} đ ({discountPercentage}%)";
//                lblDiscount.ForeColor = Color.FromArgb(46, 204, 113);
//                lblDiscount.Font = new Font(lblDiscount.Font, FontStyle.Bold);
//            }
//            else
//            {
//                lblDiscount.Text = "0 đ";
//                lblDiscount.ForeColor = Color.Gray;
//            }

//            // Highlight thành tiền
//            lblFinalTotal.ForeColor = Color.FromArgb(192, 0, 0);
//            lblFinalTotal.Font = new Font(lblFinalTotal.Font.FontFamily, 12, FontStyle.Bold);
//        }

//        private void UpdateStatistics()
//        {
//            try
//            {
//                int itemCount = _invoice.InvoiceDetails.Count;
//                int productCount = _invoice.InvoiceDetails.Sum(d => (int)d.Quantity);

//                // Có thể thêm các thống kê khác nếu cần
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Lỗi cập nhật thống kê: {ex.Message}");
//            }
//        }

//        private void btnSave_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                if (_invoice == null)
//                {
//                    MessageBox.Show("Không có thông tin hóa đơn để lưu!", "Lỗi",
//                        MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    return;
//                }

//                List<Invoice> invoices = invoiceData.GetData();

//                // Kiểm tra xem hóa đơn đã tồn tại chưa
//                Invoice existingInvoice = invoices.FirstOrDefault(i => i.Id.ToLower() == _invoice.Id.ToLower());

//                if (existingInvoice != null)
//                {
//                    // Cập nhật hóa đơn hiện có
//                    int index = invoices.IndexOf(existingInvoice);
//                    invoices[index] = _invoice;
//                }
//                else
//                {
//                    // Thêm hóa đơn mới
//                    invoices.Add(_invoice);
//                }

//                invoiceData.SaveData(invoices);

//                MessageBox.Show("Lưu thông tin hóa đơn thành công!", "Thông báo",
//                    MessageBoxButtons.OK, MessageBoxIcon.Information);

//                btnSave.Enabled = false;
//                btnSave.Text = "Đã Lưu";
//                btnSave.BackColor = Color.FromArgb(149, 165, 166);
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Lỗi khi lưu hóa đơn: {ex.Message}", "Lỗi",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void btnPrint_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                PrintInvoice();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Lỗi khi in hóa đơn: {ex.Message}", "Lỗi",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void PrintInvoice()
//        {
//            try
//            {
//                PrintDocument printDoc = new PrintDocument();
//                printDoc.PrintPage += new PrintPageEventHandler(PrintInvoicePage);

//                PrintDialog printDialog = new PrintDialog();
//                printDialog.Document = printDoc;

//                if (printDialog.ShowDialog() == DialogResult.OK)
//                {
//                    printDoc.Print();
//                    MessageBox.Show("In hóa đơn thành công!", "Thông báo",
//                        MessageBoxButtons.OK, MessageBoxIcon.Information);
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Lỗi in ấn: {ex.Message}", "Lỗi",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private string GetCustomerTypeForDisplay()
//        {
//            if (_invoice.Customer == null)
//                return "Khách lẻ";

//            // Use the overridden CustomerType property
//            string customerType = _invoice.Customer.CustomerType;

//            // Logging for debugging
//            Console.WriteLine($"Customer object type: {_invoice.Customer.GetType().Name}");
//            Console.WriteLine($"Customer Type: {customerType}");

//            return customerType;
//        }

//        private void PrintInvoicePage(object sender, PrintPageEventArgs e)
//        {
//            try
//            {
//                Graphics graphics = e.Graphics;
//                Font titleFont = new Font("Arial", 16, FontStyle.Bold);
//                Font headerFont = new Font("Arial", 12, FontStyle.Bold);
//                Font normalFont = new Font("Arial", 10);
//                Font smallFont = new Font("Arial", 9);

//                float yPos = 50;
//                float leftMargin = 50;
//                float rightMargin = e.PageBounds.Width - 50;

//                // Tiêu đề
//                graphics.DrawString("HÓA ĐƠN BÁN HÀNG", titleFont, Brushes.Black,
//                    (e.PageBounds.Width - graphics.MeasureString("HÓA ĐƠN BÁN HÀNG", titleFont).Width) / 2, yPos);
//                yPos += 40;

//                // Thông tin hóa đơn
//                graphics.DrawString($"Số hóa đơn: {_invoice.Id}", headerFont, Brushes.Black, leftMargin, yPos);
//                graphics.DrawString($"Ngày lập: {_invoice.DateCreated:dd/MM/yyyy}", headerFont, Brushes.Black, rightMargin - 200, yPos);
//                yPos += 30;

//                graphics.DrawString($"Nhân viên: {_invoice.Cashier?.Name}", normalFont, Brushes.Black, leftMargin, yPos);
//                yPos += 25;
//                string customerType = GetCustomerTypeForDisplay();
//                graphics.DrawString($"Khách hàng: {_invoice.Customer?.Name} ({customerType})", normalFont, Brushes.Black, leftMargin, yPos);
//                yPos += 40;
//                if (customerType == null) { Console.WriteLine("Không xác định"); }
//                Console.WriteLine(customerType);

//                // Header bảng
//                graphics.DrawString("STT", headerFont, Brushes.Black, leftMargin, yPos);
//                graphics.DrawString("Tên sản phẩm", headerFont, Brushes.Black, leftMargin + 50, yPos);
//                graphics.DrawString("SL", headerFont, Brushes.Black, leftMargin + 300, yPos);
//                graphics.DrawString("Đơn giá", headerFont, Brushes.Black, leftMargin + 350, yPos);
//                graphics.DrawString("Thành tiền", headerFont, Brushes.Black, leftMargin + 450, yPos);
//                yPos += 25;

//                // Vẽ line
//                graphics.DrawLine(new Pen(Color.Black, 1), leftMargin, yPos, rightMargin, yPos);
//                yPos += 10;

//                // Chi tiết sản phẩm
//                for (int i = 0; i < _invoice.InvoiceDetails.Count; i++)
//                {
//                    var detail = _invoice.InvoiceDetails[i];
//                    decimal totalPrice = detail.Quantity * detail.UnitPrice;

//                    graphics.DrawString((i + 1).ToString(), normalFont, Brushes.Black, leftMargin, yPos);
//                    graphics.DrawString(detail.ProductName, normalFont, Brushes.Black, leftMargin + 50, yPos);
//                    graphics.DrawString(detail.Quantity.ToString(), normalFont, Brushes.Black, leftMargin + 300, yPos);
//                    graphics.DrawString(detail.UnitPrice.ToString("#,###"), normalFont, Brushes.Black, leftMargin + 350, yPos);
//                    graphics.DrawString(totalPrice.ToString("#,###"), normalFont, Brushes.Black, leftMargin + 450, yPos);

//                    yPos += 20;

//                    // Kiểm tra nếu hết trang
//                    if (yPos > e.PageBounds.Height - 150)
//                    {
//                        e.HasMorePages = true;
//                        return;
//                    }
//                }

//                yPos += 20;

//                // Tổng kết
//                graphics.DrawLine(new Pen(Color.Black, 1), leftMargin, yPos, rightMargin, yPos);
//                yPos += 20;

//                graphics.DrawString($"Tổng tiền: {_invoice.SumTotal:N0} đ", headerFont, Brushes.Black, leftMargin + 300, yPos);
//                yPos += 25;

//                if (_invoice.DiscountPercentage > 0)
//                {
//                    graphics.DrawString($"Giảm giá: {_invoice.DiscountPercentage}% (-{_invoice.DiscountAmount:N0} đ)",
//                        headerFont, Brushes.Black, leftMargin + 300, yPos);
//                    yPos += 25;
//                }

//                graphics.DrawString($"Thành tiền: {_invoice.FinalTotal:N0} đ",
//                    new Font("Arial", 12, FontStyle.Bold), Brushes.Red, leftMargin + 300, yPos);
//                yPos += 40;

//                // Chữ ký
//                graphics.DrawString("Người mua hàng", normalFont, Brushes.Black, leftMargin + 100, yPos);
//                graphics.DrawString("Người bán hàng", normalFont, Brushes.Black, leftMargin + 400, yPos);
//                yPos += 20;

//                graphics.DrawString("(Ký, ghi rõ họ tên)", smallFont, Brushes.Black, leftMargin + 80, yPos);
//                graphics.DrawString("(Ký, ghi rõ họ tên)", smallFont, Brushes.Black, leftMargin + 380, yPos);
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Lỗi tạo nội dung in: {ex.Message}", "Lỗi",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        protected override void OnFormClosing(FormClosingEventArgs e)
//        {
//            base.OnFormClosing(e);
//            // Giải phóng tài nguyên
//            src.Dispose();
//        }
//    }
//}


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

            //// Xóa columns cũ nếu có
            //gridData.Columns.Clear();

            //// Thêm columns mới với DataPropertyName đúng
            //gridData.Columns.Add(new DataGridViewTextBoxColumn()
            //{
            //    DataPropertyName = "ProductID",
            //    HeaderText = "MÃ SP",
            //    Width = 100
            //});

            //gridData.Columns.Add(new DataGridViewTextBoxColumn()
            //{
            //    DataPropertyName = "ProductName",
            //    HeaderText = "TÊN SẢN PHẨM",
            //    Width = 200,
            //    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            //});

            //gridData.Columns.Add(new DataGridViewTextBoxColumn()
            //{
            //    DataPropertyName = "Quantity",
            //    HeaderText = "SỐ LƯỢNG",
            //    Width = 80,
            //    DefaultCellStyle = new DataGridViewCellStyle()
            //    {
            //        Alignment = DataGridViewContentAlignment.MiddleRight
            //    }
            //});

            //gridData.Columns.Add(new DataGridViewTextBoxColumn()
            //{
            //    DataPropertyName = "UnitPrice",
            //    HeaderText = "ĐƠN GIÁ",
            //    Width = 120,
            //    DefaultCellStyle = new DataGridViewCellStyle()
            //    {
            //        Alignment = DataGridViewContentAlignment.MiddleRight,
            //        Format = "N0"
            //    }
            //});

            //gridData.Columns.Add(new DataGridViewTextBoxColumn()
            //{
            //    DataPropertyName = "TotalPrice",
            //    HeaderText = "THÀNH TIỀN",
            //    Width = 150,
            //    DefaultCellStyle = new DataGridViewCellStyle()
            //    {
            //        Alignment = DataGridViewContentAlignment.MiddleRight,
            //        Format = "N0"
            //    }
            //});

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