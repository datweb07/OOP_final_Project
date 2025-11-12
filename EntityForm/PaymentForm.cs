using OOP_finalProject.Payments;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class PaymentForm : Form
    {
        private Invoice invoice;
        private Order order;
        private Payment payment;
        private decimal amount;
        private string invoiceId;

        public PaymentForm(Invoice invoice)
        {
            InitializeComponent();
            this.invoice = invoice;
            amount = invoice.FinalTotal;
            invoiceId = invoice.Id;
            InitializeForm();
        }

        // cái này có thể không cần thiết
        public PaymentForm(Order order)
        {
            InitializeComponent();
            this.order = order;
            amount = order.FinalTotal;
            invoiceId = order.OrderId;
            InitializeForm();
        }

        public PaymentForm(decimal amount, string invoiceId)
        {
            InitializeComponent();
            this.amount = amount;
            this.invoiceId = invoiceId;
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
            lblInvoiceId.Text = $"Hóa đơn: {invoiceId}";
            lblAmount.Text = $"Số tiền: {amount:N0} đ";
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
                if (payment == null)
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

                    // nếu là tiền mặt sẽ cập nhật vào Dashboard
                    if (selectedMethod == PaymentMethod.CASH)
                    {
                        try
                        {
                            // nếu form này được mở kèm theo 1 Invoice, lưu/ cập nhật hóa đơn vào dữ liệu
                            if (invoice != null)
                            {
                                // lưu phương thức thanh toán và mã giao dịch
                                try
                                {
                                    invoice.PaymentMethod = selectedMethod.ToString();
                                    invoice.TransactionId = payment?.TransactionId;
                                }
                                catch { }

                                InvoiceData invoiceData = new InvoiceData();
                                System.Collections.Generic.List<Invoice> invoices = invoiceData.GetData();
                                if (invoices == null)
                                {
                                    invoices = new System.Collections.Generic.List<Invoice>();
                                }

                                int existingIndex = -1;
                                for (int i = 0; i < invoices.Count; i++)
                                {
                                    if (invoices[i] != null && invoices[i].Id == invoice.Id)
                                    {
                                        existingIndex = i;
                                        break;
                                    }
                                }

                                if (existingIndex >= 0)
                                {
                                    invoices[existingIndex] = invoice;
                                }
                                else
                                {
                                    invoices.Add(invoice);
                                }

                                invoiceData.SaveData(invoices);
                            }

                            // tìm MainFormAdmin và yêu cầu refresh dashboard
                            FormCollection openForms = Application.OpenForms;
                            foreach (Form f in openForms)
                            {
                                if (f is MainFormAdmin)
                                {
                                    MainFormAdmin main = (MainFormAdmin)f;
                                    main.RefreshDashboardView();
                                    break;
                                }
                            }
                        }
                        catch
                        {
                            
                        }
                    }

                    DialogResult result = MessageBox.Show(
                        $"Thanh toán thành công!\n\n" +
                        $"Số tiền: {amount:N0} đ\n" +
                        $"Mã giao dịch: {payment.TransactionId}\n" +
                        $"Thời gian: {payment.TransactionDate:dd/MM/yyyy HH:mm:ss}\n\n" +
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
                        $"Thanh toán thất bại!\n\n{payment?.Message ?? "Có lỗi xảy ra"}",
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
            payment = PaymentFactory.CreatePayment(selectedMethod, amount, invoiceId);
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

            // ẩn/hiện theo phương thức thanh toán (phát triển thêm)
            bool isQR = (selectedMethod == PaymentMethod.QR_CODE);
            bool isCash = (selectedMethod == PaymentMethod.CASH);
            bool isCard = (selectedMethod == PaymentMethod.CARD);


            if (isQR || isCard)
            {
                // hiển thi label coming soon
                lblComingSoon.Visible = true;

                // ẩn cash
                lblReceivedAmount.Visible = false;
                txtReceivedAmount.Visible = false;
                lblChange.Visible = false;
                lblChangeAmount.Visible = false;

                // không cho thanh toán
                btnProcessPayment.Enabled = false;
            }
            else
            {
                // ẩn label coming soon
                lblComingSoon.Visible = false;

                // hiện thị cash
                lblReceivedAmount.Visible = isCash;
                txtReceivedAmount.Visible = isCash;
                lblChange.Visible = isCash;
                lblChangeAmount.Visible = isCash;

                // cho thanh toán nếu số tiền hợp lệ
                btnProcessPayment.Enabled = false;
            }

            // reset trạng thái
            lblStatus.Text = "Trạng thái: Chưa thanh toán";
            lblStatus.ForeColor = Color.Black;

            // Reset payment
            payment = null;

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
                if (GetSelectedPaymentMethod() != PaymentMethod.CASH)
                    return;

                string text = txtReceivedAmount.Text;
                if (text != null)
                {
                    text = text.Trim();
                }

                if (string.IsNullOrEmpty(text))
                {
                    lblChangeAmount.Text = "0 đ";
                    lblChangeAmount.ForeColor = Color.Black;
                    btnProcessPayment.Enabled = false;
                    return;
                }

                decimal receivedAmount;
                if (!decimal.TryParse(text, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out receivedAmount))
                {
                    lblChangeAmount.Text = "Số tiền không hợp lệ";
                    lblChangeAmount.ForeColor = Color.Red;
                    btnProcessPayment.Enabled = false;
                    return;
                }

                decimal change = receivedAmount - amount;
                if (change < 0)
                {
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
              
            }
        }

        private bool ProcessCashPayment()
        {
            if (payment == null || !(payment is CashPayment))
            {
                CreatePayment();
            }

            if (payment is CashPayment)
            {
                CashPayment cashPayment = (CashPayment)payment;

                if (string.IsNullOrEmpty(txtReceivedAmount.Text))
                {
                    MessageBox.Show("Vui lòng nhập số tiền khách đưa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                decimal receivedAmount;
                if (!decimal.TryParse(txtReceivedAmount.Text, out receivedAmount))
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
        public PaymentForm()
        {
            InitializeComponent();
        }
    }
}