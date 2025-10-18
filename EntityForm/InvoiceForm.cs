using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class InvoiceForm : Form
    {
        private Invoice _invoice;
        InvoiceData invoiceData = new InvoiceData();
        public InvoiceForm()
        {
            InitializeComponent();
        }

        public InvoiceForm(Invoice invoice)
            : this()
        {
            _invoice = invoice;
        }

        BindingSource src = new BindingSource();
        private void FormInvoice_Load(object sender, EventArgs e)
        {
            if (_invoice == null)
            {
                return;
            }
            gridData.DataSource = src;
            gridData.AutoGenerateColumns = false;
            lblCode.Text = _invoice.Id;
            lblCreatedDate.Text = _invoice.DateCreated.ToString("dd/MM/yyyy");
            lblSellerName.Text = _invoice.Cashier.Name;
            lblCustomerName.Text = _invoice.Customer.Name;
            
            // Hiển thị thông tin discount (Strategy Pattern)
            lblSumTotal.Text = _invoice.SumTotal.ToString("#,###");
            
            // Hiển thị discount nếu có
            if (_invoice.DiscountPercentage > 0)
            {
                lblSumTotal.Text += $"\nGiảm giá ({_invoice.DiscountPercentage}%): -{_invoice.DiscountAmount.ToString("#,###")}";
                lblSumTotal.Text += $"\nThành tiền: {_invoice.FinalTotal.ToString("#,###")}";
            }
            
            src.DataSource = _invoice.InvoiceDetails;
            src.ResetBindings(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<Invoice> invoices = invoiceData.GetData();

            Invoice invoice = null;

            for (int i = 0; i < invoices.Count; i++)
            {
                if (_invoice.Id.ToLower() == invoices[i].Id.ToLower())
                {
                    invoices[i] = _invoice;
                    invoice = invoices[i];
                    break;
                }
            }

            if (invoice == null)
            {
                invoices.Add(_invoice);
            }

            invoiceData.SaveData(invoices);

            MessageBox.Show("Lưu thông tin hoá đơn thành công ! "
               , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
