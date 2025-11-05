//using System;
//using System.Collections.Generic;
//using System.Windows.Forms;

//namespace OOP_finalProject
//{
//    public partial class ListInvoiceForm : Form
//    {
//        public ListInvoiceForm()
//        {
//            InitializeComponent();
//        }

//        InvoiceData invoiceData = new InvoiceData();
//        BindingSource src = new BindingSource();
//        private void FormInvoiceList_Load(object sender, EventArgs e)
//        {
//            gridData.AutoGenerateColumns = false;
//            gridData.AllowUserToAddRows = false;
//            gridData.ReadOnly = true;
//            gridData.DataSource = src;
//            LoadGrid();
//        }

//        private void LoadGrid()
//        {
//            src.DataSource = invoiceData.GetData();
//            src.ResetBindings(true);
//        }

//        private void btnXemHoaDon_Click(object sender, EventArgs e)
//        {
//            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
//                return;

//            Invoice invoice = gridData.CurrentRow.DataBoundItem as Invoice;

//            if (invoice == null)
//                return;

//            InvoiceForm frm = new InvoiceForm(invoice);
//            frm.ShowDialog();
//        }

//        private void btnDelete_Click(object sender, EventArgs e)
//        {
//            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
//                return;

//            Invoice invoice = gridData.CurrentRow.DataBoundItem as Invoice;

//            if (invoice == null)
//            {
//                MessageBox.Show("Không tìm thấy hoá đơn cần xoá ! "
//              , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                return;
//            }

//            if (MessageBox.Show("Bạn muốn xoá hoá đơn được chọn ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
//                return;

//            List<Invoice> invoices = invoiceData.GetData();

//            Invoice toDelete = null;

//            for (int i = 0; i < invoices.Count; i++)
//            {
//                if (invoices[i].Id.ToLower() == invoice.Id.ToLower())
//                {
//                    toDelete = invoices[i];
//                    break;
//                }
//            }

//            if (toDelete != null)
//            {
//                invoices.Remove(toDelete);
//            }

//            invoiceData.SaveData(invoices);

//            LoadGrid();

//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            // Cấu hình DataGridView
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

            // Cấu hình để gridData rộng hết cỡ
            gridData.Dock = DockStyle.Fill;
            gridData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Thiết lập mặc định
            cmbSort.SelectedIndex = 0;

            invoices = invoiceData.GetData();
            filteredInvoices = invoices.ToList();
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

            if (MessageBox.Show($"Bạn có chắc chắn muốn xoá hoá đơn '{invoice.Id}'?\n\nThao tác này không thể hoàn tác!",
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

                // Cập nhật danh sách
                invoices = allInvoices;
                filteredInvoices = invoices.ToList();
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
            filteredInvoices = invoices.ToList();
            LoadGrid();
            statusLabel.Text = "Đã làm mới danh sách";
        }

        #region Các chức năng mới

        /// <summary>
        /// Tìm kiếm hoá đơn
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }

        /// <summary>
        /// Áp dụng tất cả bộ lọc và tìm kiếm
        /// </summary>
        private void ApplyFiltersAndSearch()
        {
            // Bắt đầu từ danh sách đầy đủ
            filteredInvoices = invoices.ToList();

            // Áp dụng tìm kiếm
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                filteredInvoices = filteredInvoices.Where(p =>
                    p.Id.ToLower().Contains(txtSearch.Text.ToLower()) ||
                    p.CashierName.ToLower().Contains(txtSearch.Text.ToLower()) ||
                    p.CustomerName.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            }

            // Áp dụng sắp xếp
            ApplySorting();

            LoadGrid();
            statusLabel.Text = $"Tìm thấy {filteredInvoices.Count} hoá đơn";
        }

        /// <summary>
        /// Áp dụng sắp xếp
        /// </summary>
        private void ApplySorting()
        {
            if (cmbSort.SelectedIndex == -1) return;

            switch (cmbSort.SelectedIndex)
            {
                case 0: // Mã HĐ (A-Z)
                    filteredInvoices = filteredInvoices.OrderBy(p => p.Id).ToList();
                    break;
                case 1: // Mã HĐ (Z-A)
                    filteredInvoices = filteredInvoices.OrderByDescending(p => p.Id).ToList();
                    break;
                case 2: // Ngày lập (Cũ-Nhất)
                    filteredInvoices = filteredInvoices.OrderBy(p => p.DateCreated).ToList();
                    break;
                case 3: // Ngày lập (Mới-Nhất)
                    filteredInvoices = filteredInvoices.OrderByDescending(p => p.DateCreated).ToList();
                    break;
                case 4: // Nhân viên (A-Z)
                    filteredInvoices = filteredInvoices.OrderBy(p => p.CashierName).ToList();
                    break;
                case 5: // Nhân viên (Z-A)
                    filteredInvoices = filteredInvoices.OrderByDescending(p => p.CashierName).ToList();
                    break;
                case 6: // Khách hàng (A-Z)
                    filteredInvoices = filteredInvoices.OrderBy(p => p.CustomerName).ToList();
                    break;
                case 7: // Khách hàng (Z-A)
                    filteredInvoices = filteredInvoices.OrderByDescending(p => p.CustomerName).ToList();
                    break;
                case 8: // Thành tiền (Thấp-Cao)
                    filteredInvoices = filteredInvoices.OrderBy(p => p.FinalTotal).ToList();
                    break;
                case 9: // Thành tiền (Cao-Thấp)
                    filteredInvoices = filteredInvoices.OrderByDescending(p => p.FinalTotal).ToList();
                    break;
            }
        }

        /// <summary>
        /// Cập nhật thống kê
        /// </summary>
        private void UpdateStatistics()
        {
            int totalInvoices = filteredInvoices.Count;
            decimal totalRevenue = filteredInvoices.Sum(p => p.FinalTotal);
            decimal totalDiscount = filteredInvoices.Sum(p => p.DiscountAmount);
            int customerCount = filteredInvoices.Select(p => p.CustomerName).Distinct().Count();

            lblTotalInvoicesValue.Text = totalInvoices.ToString();
            lblTotalRevenueValue.Text = $"{totalRevenue:N0} đ";
            lblTotalDiscountValue.Text = $"{totalDiscount:N0} đ";
            lblCustomerCountValue.Text = customerCount.ToString();

            // Đổi màu theo số lượng
            lblTotalInvoicesValue.ForeColor = totalInvoices > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblTotalRevenueValue.ForeColor = totalRevenue > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblTotalDiscountValue.ForeColor = totalDiscount > 0 ? Color.FromArgb(255, 165, 0) : Color.Gray;
            lblCustomerCountValue.ForeColor = customerCount > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
        }

        /// <summary>
        /// Sự kiện khi thay đổi lựa chọn lọc
        /// </summary>
        private void FilterChanged(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }

        #endregion
    }
}