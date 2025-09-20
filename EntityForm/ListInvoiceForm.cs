using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class ListInvoiceForm : Form
    {
        public ListInvoiceForm()
        {
            InitializeComponent();
        }

        InvoiceData invoiceData = new InvoiceData();
        BindingSource src = new BindingSource();
        private void FormInvoiceList_Load(object sender, EventArgs e)
        {
            gridData.AutoGenerateColumns = false;
            gridData.AllowUserToAddRows = false;
            gridData.ReadOnly = true;
            gridData.DataSource = src;
            LoadGrid();
        }

        private void LoadGrid()
        {
            src.DataSource = invoiceData.GetData();
            src.ResetBindings(true);
        }

        private void btnXemHoaDon_Click(object sender, EventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            Invoice invoice = gridData.CurrentRow.DataBoundItem as Invoice;

            if (invoice == null)
                return;

            InvoiceForm frm = new InvoiceForm(invoice);
            frm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            Invoice invoice = gridData.CurrentRow.DataBoundItem as Invoice;

            if (invoice == null)
            {
                MessageBox.Show("Không tìm thấy hoá đơn cần xoá ! "
              , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn muốn xoá hoá đơn được chọn ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            List<Invoice> invoices = invoiceData.GetData();

            Invoice toDelete = null;

            for (int i = 0; i < invoices.Count; i++)
            {
                if (invoices[i].Id.ToLower() == invoice.Id.ToLower())
                {
                    toDelete = invoices[i];
                    break;
                }
            }

            if (toDelete != null)
            {
                invoices.Remove(toDelete);
            }

            invoiceData.SaveData(invoices);

            LoadGrid();

        }
    }
}
