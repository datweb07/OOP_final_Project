using OOP_finalProject.Payments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class QRPaymentForm : Form
    {
        private Invoice _invoice;
        private Order _order;
        private Payment _payment;
        private decimal _amount;
        private string _invoiceId;

        public QRPaymentForm(Invoice invoice)
        {
            InitializeComponent();
            _invoice = invoice;
            _amount = invoice.FinalTotal;
            _invoiceId = invoice.Id;
            InitializeForm();
        }

        // cái này có thể không cần thiết
        public QRPaymentForm(Order order)
        {
            InitializeComponent();
            _order = order;
            _amount = order.FinalTotal;
            _invoiceId = order.OrderId;
            InitializeForm();
        }

        public QRPaymentForm(decimal amount, string invoiceId)
        {
            InitializeComponent();
            _amount = amount;
            _invoiceId = invoiceId;
            InitializeForm();
        }

        private void InitializeForm()
        {
            // hiển thị các phương thức thanh toán
            LoadPaymentMethods();

            DisplayInvoiceInfo();

            cboPaymentMethod.SelectedIndex = 0;  // mặc định là tiền mặt

            UpdatePaymentMethodUI();

            txtReceivedAmount.TextChanged += txtReceivedAmount_TextChanged;

        }

        private void LoadPaymentMethods()
        {
            cboPaymentMethod.Items.Clear();
            cboPaymentMethod.Items.Add("Tiền mặt");
            cboPaymentMethod.Items.Add("Thẻ");
            cboPaymentMethod.Items.Add("Quét mã QR");
        }

        private void DisplayInvoiceInfo()
        {
            lblInvoiceId.Text = $"Hóa đơn: {_invoiceId}";
            lblAmount.Text = $"Số tiền: {_amount:N0} đ";
            lblAmount.ForeColor = Color.FromArgb(192, 0, 0);
            lblAmount.Font = new Font(lblAmount.Font.FontFamily, 14, FontStyle.Bold);
        }

        private void cboPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePaymentMethodUI();
        }

        private void btnProcessPayment_Click(object sender, EventArgs e)
        {
            try
            {
                PaymentMethod selectedMethod = GetSelectedPaymentMethod();

                // Tạo payment nếu chưa có
                if (_payment == null)
                {
                    CreatePayment();
                }

                bool success = false;

                switch (selectedMethod)
                {
                    case PaymentMethod.CASH:
                        success = ProcessCashPayment();
                        break;
                    //case PaymentMethod.CARD:
                    //    success = ProcessCardPayment();
                    //    break;
                    //case PaymentMethod.QR_CODE:
                    //    success = ProcessQRPayment();
                    //    break;
                }

                if (success)
                {
                    lblStatus.Text = $"Trạng thái: Thanh toán thành công ✓";
                    lblStatus.ForeColor = Color.Green;

                    // Nếu là thanh toán tiền mặt, yêu cầu refresh Dashboard để cập nhật Doanh Thu
                    if (selectedMethod == PaymentMethod.CASH)
                    {
                        try
                        {
                            // Nếu form này được mở kèm theo 1 Invoice, lưu/ cập nhật hóa đơn vào dữ liệu
                            if (_invoice != null)
                            {
                                // Ghi nhận phương thức thanh toán và mã giao dịch lên Invoice (nếu có)
                                try
                                {
                                    _invoice.PaymentMethod = selectedMethod.ToString();
                                    _invoice.TransactionId = _payment?.TransactionId;
                                }
                                catch { }

                                var invoiceData = new InvoiceData();
                                System.Collections.Generic.List<Invoice> invoices = invoiceData.GetData() ?? new System.Collections.Generic.List<Invoice>();

                                int existingIndex = invoices.FindIndex(i => i != null && i.Id == _invoice.Id);

                                if (existingIndex >= 0)
                                {
                                    invoices[existingIndex] = _invoice;
                                }
                                else
                                {
                                    invoices.Add(_invoice);
                                }

                                invoiceData.SaveData(invoices);
                            }

                            // Tìm MainFormAdmin và yêu cầu refresh dashboard
                            foreach (Form f in Application.OpenForms)
                            {
                                if (f is MainFormAdmin main)
                                {
                                    main.RefreshDashboardView();
                                    break;
                                }
                            }
                        }
                        catch
                        {
                            // Không bắt buộc: nếu không tìm thấy hoặc lỗi thì bỏ qua
                        }
                    }

                    DialogResult result = MessageBox.Show(
                        $"Thanh toán thành công!\n\n" +
                        $"Số tiền: {_amount:N0} đ\n" +
                        $"Mã giao dịch: {_payment.TransactionId}\n" +
                        $"Thời gian: {_payment.TransactionDate:dd/MM/yyyy HH:mm:ss}\n\n" +
                        $"Bạn có muốn đóng form không?",
                        "Thành công",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information
                    );

                    if (result == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    lblStatus.Text = $"Trạng thái: Thanh toán thất bại ✗";
                    lblStatus.ForeColor = Color.Red;
                    MessageBox.Show(
                        $"Thanh toán thất bại!\n\n{_payment?.Message ?? "Có lỗi xảy ra"}",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CreatePayment()
        {
            PaymentMethod selectedMethod = GetSelectedPaymentMethod();
            _payment = PaymentFactory.CreatePayment(selectedMethod, _amount, _invoiceId);
        }

        private PaymentMethod GetSelectedPaymentMethod()
        {
            switch (cboPaymentMethod.SelectedIndex)
            {
                case 0:
                    return PaymentMethod.CASH;
                case 1:
                    return PaymentMethod.CARD;
                case 2:
                    return PaymentMethod.QR_CODE;
                default:
                    return PaymentMethod.CASH;
            }
        }

        private void UpdatePaymentMethodUI()
        {
            PaymentMethod selectedMethod = GetSelectedPaymentMethod();

            // Ẩn/hiện các controls theo phương thức thanh toán
            bool isQR = (selectedMethod == PaymentMethod.QR_CODE);
            bool isCash = (selectedMethod == PaymentMethod.CASH);
            bool isCard = (selectedMethod == PaymentMethod.CARD);

            // If QR or Card selected: show only the coming-soon label and disable payment
            if (isQR || isCard)
            {
                // Show single centered message
                lblComingSoon.Visible = true;

                // Hide Cash controls
                lblReceivedAmount.Visible = false;
                txtReceivedAmount.Visible = false;
                lblChange.Visible = false;
                lblChangeAmount.Visible = false;

                // Disable the payment button for not-ready modes
                btnProcessPayment.Enabled = false;
            }
            else
            {
                // Hide coming soon label
                lblComingSoon.Visible = false;

                // Cash Payment controls
                lblReceivedAmount.Visible = isCash;
                txtReceivedAmount.Visible = isCash;
                lblChange.Visible = isCash;
                lblChangeAmount.Visible = isCash;

                // By default disable payment until received amount is valid (textchanged will enable)
                btnProcessPayment.Enabled = false;
            }

            // Reset status
            lblStatus.Text = "Trạng thái: Chưa thanh toán";
            lblStatus.ForeColor = Color.Black;

            // Reset payment
            _payment = null;

            // Reset change display when switching methods
            if (!isCash)
            {
                lblChangeAmount.Text = "0 đ";
                lblChangeAmount.ForeColor = Color.Green;
            }
        }

        private void txtReceivedAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Only handle when cash is selected
                if (GetSelectedPaymentMethod() != PaymentMethod.CASH)
                    return;

                string text = txtReceivedAmount.Text?.Trim();
                if (string.IsNullOrEmpty(text))
                {
                    lblChangeAmount.Text = "0 đ";
                    lblChangeAmount.ForeColor = Color.Black;
                    btnProcessPayment.Enabled = false;
                    return;
                }

                if (!decimal.TryParse(text, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out decimal receivedAmount))
                {
                    lblChangeAmount.Text = "Số tiền không hợp lệ";
                    lblChangeAmount.ForeColor = Color.Red;
                    btnProcessPayment.Enabled = false;
                    return;
                }

                decimal change = receivedAmount - _amount;
                if (change < 0)
                {
                    // Show how much more is needed
                    lblChangeAmount.Text = $"Chưa đủ: {Math.Abs(change):N0} đ";
                    lblChangeAmount.ForeColor = Color.Red;
                    btnProcessPayment.Enabled = false;
                }
                else
                {
                    lblChangeAmount.Text = $"{change:N0} đ";
                    lblChangeAmount.ForeColor = Color.Green;
                    btnProcessPayment.Enabled = true;
                }
            }
            catch
            {
                // ignore UI errors
            }
        }

        private bool ProcessCashPayment()
        {
            if (_payment == null || !(_payment is CashPayment))
            {
                CreatePayment();
            }

            if (_payment is CashPayment cashPayment)
            {
                if (string.IsNullOrEmpty(txtReceivedAmount.Text))
                {
                    MessageBox.Show("Vui lòng nhập số tiền khách đưa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (!decimal.TryParse(txtReceivedAmount.Text, out decimal receivedAmount))
                {
                    MessageBox.Show("Số tiền không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!cashPayment.ReceiveCash(receivedAmount))
                {
                    MessageBox.Show(cashPayment.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Hiển thị tiền thối lại
                lblChangeAmount.Text = $"{cashPayment.ChangeAmount:N0} đ";
                lblChangeAmount.ForeColor = Color.Green;

                return cashPayment.ProcessPayment();
            }

            return false;
        }
        public QRPaymentForm()
        {
            InitializeComponent();
        }
    }
}
