using System;
using System.Collections.Generic;
using System.Drawing;
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
        private List<Invoice> invoices = new List<Invoice>();
        private List<Invoice> filteredInvoices = new List<Invoice>();

        private void FormInvoiceList_Load(object sender, EventArgs e)
        {
            gridData.AutoGenerateColumns = false;
            gridData.AllowUserToAddRows = false;
            gridData.ReadOnly = true;
            gridData.DataSource = src;

            // Tùy chỉnh giao diện DataGridView
            gridData.BorderStyle = BorderStyle.None;
            gridData.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 245);
            gridData.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridData.DefaultCellStyle.SelectionBackColor = Color.FromArgb(65, 105, 225);
            gridData.DefaultCellStyle.SelectionForeColor = Color.White;
            gridData.BackgroundColor = Color.White;
            gridData.EnableHeadersVisualStyles = false;
            gridData.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridData.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(65, 105, 225);
            gridData.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridData.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            gridData.Dock = DockStyle.Fill;
            gridData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            cmbSort.SelectedIndex = 0;

            invoices = invoiceData.GetData();
            filteredInvoices = new List<Invoice>(invoices);
            LoadGrid();
            UpdateStatistics();
        }

        private void LoadGrid()
        {
            src.DataSource = filteredInvoices;
            src.ResetBindings(true);
            UpdateStatistics();
        }

        private void btnXemHoaDon_Click(object sender, EventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn hoá đơn cần xem!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Invoice invoice = gridData.CurrentRow.DataBoundItem as Invoice;
            if (invoice == null)
                return;

            InvoiceForm frm = new InvoiceForm(invoice);
            frm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn hoá đơn cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Invoice invoice = gridData.CurrentRow.DataBoundItem as Invoice;
            if (invoice == null)
            {
                MessageBox.Show("Không tìm thấy hoá đơn cần xoá ! "
              , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xoá hoá đơn '" + invoice.Id + "'?\n\nThao tác này không thể hoàn tác!",
                "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            List<Invoice> allInvoices = invoiceData.GetData();
            Invoice toDelete = null;

            for (int i = 0; i < allInvoices.Count; i++)
            {
                if (allInvoices[i].Id.ToLower() == invoice.Id.ToLower())
                {
                    toDelete = allInvoices[i];
                    break;
                }
            }

            if (toDelete != null)
            {
                allInvoices.Remove(toDelete);
                invoiceData.SaveData(allInvoices);

                // cập nhật lại danh sách
                invoices = allInvoices;
                filteredInvoices = new List<Invoice>(invoices);
                LoadGrid();

                MessageBox.Show("Xoá hoá đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusLabel.Text = "Đã xóa hoá đơn thành công";
                statusLabel.ForeColor = Color.FromArgb(46, 204, 113);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cmbSort.SelectedIndex = 0;

            invoices = invoiceData.GetData();
            filteredInvoices = new List<Invoice>(invoices);
            LoadGrid();
            statusLabel.Text = "Đã làm mới danh sách";
        }

        // tìm kiếm hóa đơn
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }

        // lọc và tìm kiếm
        private void ApplyFiltersAndSearch()
        {
            // gắn vào danh sách đầy đủ
            filteredInvoices = new List<Invoice>(invoices);

            // tìm kiếm
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                List<Invoice> searchResults = new List<Invoice>();
                string searchText = txtSearch.Text.ToLower();

                for (int i = 0; i < filteredInvoices.Count; i++)
                {
                    Invoice invoice = filteredInvoices[i];
                    if (invoice.Id.ToLower().Contains(searchText) || invoice.CashierName.ToLower().Contains(searchText) || invoice.CustomerName.ToLower().Contains(searchText))
                    {
                        searchResults.Add(invoice);
                    }
                }
                filteredInvoices = searchResults;
            }

            // sắp xếp
            ApplySorting();

            LoadGrid();
            statusLabel.Text = "Tìm thấy " + filteredInvoices.Count + " hoá đơn";
        }

        private void ApplySorting()
        {
            if (cmbSort.SelectedIndex == -1) return;

            switch (cmbSort.SelectedIndex)
            {
                case 0: // Mã HĐ (A-Z)
                    filteredInvoices.Sort((p1, p2) => p1.Id.CompareTo(p2.Id));
                    break;
                case 1: // Mã HĐ (Z-A)
                    filteredInvoices.Sort((p1, p2) => p2.Id.CompareTo(p1.Id));
                    break;
                case 2: // Ngày lập (Cũ-Nhất)
                    filteredInvoices.Sort((p1, p2) => p1.DateCreated.CompareTo(p2.DateCreated));
                    break;
                case 3: // Ngày lập (Mới-Nhất)
                    filteredInvoices.Sort((p1, p2) => p2.DateCreated.CompareTo(p1.DateCreated));
                    break;
                case 4: // Nhân viên (A-Z)
                    filteredInvoices.Sort((p1, p2) => p1.CashierName.CompareTo(p2.CashierName));
                    break;
                case 5: // Nhân viên (Z-A)
                    filteredInvoices.Sort((p1, p2) => p2.CashierName.CompareTo(p1.CashierName));
                    break;
                case 6: // Khách hàng (A-Z)
                    filteredInvoices.Sort((p1, p2) => p1.CustomerName.CompareTo(p2.CustomerName));
                    break;
                case 7: // Khách hàng (Z-A)
                    filteredInvoices.Sort((p1, p2) => p2.CustomerName.CompareTo(p1.CustomerName));
                    break;
                case 8: // Thành tiền (Thấp-Cao)
                    filteredInvoices.Sort((p1, p2) => p1.FinalTotal.CompareTo(p2.FinalTotal));
                    break;
                case 9: // Thành tiền (Cao-Thấp)
                    filteredInvoices.Sort((p1, p2) => p2.FinalTotal.CompareTo(p1.FinalTotal));
                    break;
            }
        }

        // chi tiết thống kê
        private void UpdateStatistics()
        {
            int totalInvoices = filteredInvoices.Count;

            decimal totalRevenue = 0;
            for (int i = 0; i < filteredInvoices.Count; i++)
            {
                totalRevenue += filteredInvoices[i].FinalTotal;
            }

            decimal totalDiscount = 0;
            for (int i = 0; i < filteredInvoices.Count; i++)
            {
                totalDiscount += filteredInvoices[i].DiscountAmount;
            }

            List<string> distinctCustomers = new List<string>();
            for (int i = 0; i < filteredInvoices.Count; i++)
            {
                string customerName = filteredInvoices[i].CustomerName;
                if (!string.IsNullOrEmpty(customerName) && !distinctCustomers.Contains(customerName))
                {
                    distinctCustomers.Add(customerName);
                }
            }
            int customerCount = distinctCustomers.Count;

            lblTotalInvoicesValue.Text = totalInvoices.ToString();
            lblTotalRevenueValue.Text = totalRevenue.ToString("N0") + " đ";
            lblTotalDiscountValue.Text = totalDiscount.ToString("N0") + " đ";
            lblCustomerCountValue.Text = customerCount.ToString();

            // đổi màu theo số lượng
            lblTotalInvoicesValue.ForeColor = totalInvoices > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblTotalRevenueValue.ForeColor = totalRevenue > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblTotalDiscountValue.ForeColor = totalDiscount > 0 ? Color.FromArgb(255, 165, 0) : Color.Gray;
            lblCustomerCountValue.ForeColor = customerCount > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }
    }
}