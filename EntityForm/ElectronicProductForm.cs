using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class ElectronicProductForm : Form
    {
        public ElectronicProductForm()
        {
            InitializeComponent();
        }

        private ElectronicProductData productData = new ElectronicProductData();
        private List<ElectronicProduct> products = new List<ElectronicProduct>();
        private List<ElectronicProduct> filteredProducts = new List<ElectronicProduct>();

        BindingSource _src = new BindingSource();

        private void ElectronicForm_Load(object sender, EventArgs e)
        {
            ElectronicProductData.CreateSampleData();
            gridData.DataSource = _src;
            gridData.AllowUserToAddRows = false;
            gridData.ReadOnly = true;

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

            // Khởi tạo danh sách bảo hành
            InitializeWarranty();

            // Thiết lập mặc định
            cmbSort.SelectedIndex = 0;
            cmbWarrantyFilter.SelectedIndex = 0;

            products = productData.GetData();
            filteredProducts = products.ToList();
            DisplayInGrid();
        }

        private void InitializeWarranty()
        {
            string[] warrantyPeriods = new string[] {
                "6 tháng", "12 tháng", "18 tháng", "24 tháng",
                "36 tháng", "48 tháng", "60 tháng"
            };

            // ComboBox bảo hành cho sản phẩm mới
            cboWarranty.Items.Clear();
            cboWarranty.Items.AddRange(warrantyPeriods);
            cboWarranty.SelectedIndex = 0;

            // ComboBox lọc bảo hành
            cmbWarrantyFilter.Items.Clear();
            cmbWarrantyFilter.Items.Add("Tất cả bảo hành");
            cmbWarrantyFilter.Items.AddRange(warrantyPeriods);
            cmbWarrantyFilter.SelectedIndex = 0;
        }

        private void DisplayInGrid()
        {
            _src.DataSource = filteredProducts;
            _src.ResetBindings(true);
            UpdateStatistics();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtName.Text = "";
            txtPrice.Value = 0;
            txtQuantity.Value = 0;
            txtSearch.Text = "";
            cboWarranty.SelectedIndex = 0;
            cmbWarrantyFilter.SelectedIndex = 0;
            chkLowStockOnly.Checked = false;


            cmbSort.SelectedIndex = 0;

            filteredProducts = products.ToList();


            DisplayInGrid();

            statusLabel.Text = "Đã làm mới danh sách";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            ElectronicProduct product = null;

            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Id.ToLower() == txtId.Text.ToLower())
                {
                    product = products[i];
                    break;
                }
            }

            if (product == null)
            {

                product = new ElectronicProduct(
                    txtId.Text,
                    txtName.Text,
                    txtPrice.Value,
                    txtQuantity.Value,
                    (string)cboWarranty.SelectedItem);
                products.Add(product);
            }
            else
            {
                product.Name = txtName.Text;
                product.Price = txtPrice.Value;
                product.Quantity = txtQuantity.Value;
                product.WarrantyPeriod = (string)cboWarranty.SelectedItem;
            }

            filteredProducts = products.ToList();
            DisplayInGrid();

            // Lưu file
            productData.SaveData(products);

            MessageBox.Show("Cập nhật thông tin sản phẩm điện tử thành công !",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            statusLabel.Text = "Đã lưu thông tin thành công";
            statusLabel.ForeColor = Color.FromArgb(46, 204, 113);
        }


        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Mã sản phẩm không được để trống !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtId.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống !",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }

            if (txtPrice.Value < 0)
            {
                MessageBox.Show("Giá sản phẩm không được bé hơn 0 !",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice.Focus();
                return false;
            }

            if (txtQuantity.Value < 0)
            {
                MessageBox.Show("Số lượng sản phẩm không được bé hơn 0 !",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Focus();
                return false;
            }

            if (cboWarranty.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn thời gian bảo hành !"
                   , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboWarranty.Focus();
                return false;
            }

            return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sản phẩm '{txtName.Text}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            ElectronicProduct product = null;

            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Id.ToLower() == txtId.Text.ToLower())
                {
                    product = products[i];
                    break;
                }
            }

            if (product != null)
            {
                products.Remove(product);
                ApplyFiltersAndSearch();
                productData.SaveData(products);

                MessageBox.Show("Xoá thông tin sản phẩm điện tử thành công !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnRefresh_Click(null, null);
                statusLabel.Text = "Đã xóa sản phẩm thành công";
                statusLabel.ForeColor = Color.FromArgb(46, 204, 113);
            }
        }

        private void gridData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            ElectronicProduct product = (ElectronicProduct)gridData.CurrentRow.DataBoundItem;

            if (product == null)
                return;

            Display(product);
        }

        public void Display(ElectronicProduct product)
        {
            txtId.Text = product.Id;
            txtName.Text = product.Name;
            txtPrice.Value = product.Price;
            txtQuantity.Value = product.Quantity;
            cboWarranty.SelectedItem = product.WarrantyPeriod;
        }

        #region Các chức năng mới

        /// <summary>
        /// Tìm kiếm sản phẩm
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }

        /// <summary>
        /// Thêm mới sản phẩm
        /// </summary>
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
            txtId.Focus();
            statusLabel.Text = "Nhập thông tin sản phẩm mới";
        }

        /// <summary>
        /// Áp dụng tất cả bộ lọc và tìm kiếm
        /// </summary>
        private void ApplyFiltersAndSearch()
        {
            // Bắt đầu từ danh sách đầy đủ
            filteredProducts = products.ToList();

            // Áp dụng tìm kiếm
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                filteredProducts = filteredProducts.Where(p =>
                    p.Id.ToLower().Contains(txtSearch.Text.ToLower()) ||
                    p.Name.ToLower().Contains(txtSearch.Text.ToLower()) ||
                    p.WarrantyPeriod.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            }

            // Áp dụng lọc bảo hành
            if (cmbWarrantyFilter.SelectedIndex > 0)
            {
                string selectedWarranty = cmbWarrantyFilter.SelectedItem.ToString();
                filteredProducts = filteredProducts.Where(p => p.WarrantyPeriod == selectedWarranty).ToList();
            }

            // Áp dụng lọc tồn kho thấp
            if (chkLowStockOnly.Checked)
            {
                filteredProducts = filteredProducts.Where(p => p.Quantity <= 10).ToList();
            }

            // Áp dụng sắp xếp
            ApplySorting();
            

            DisplayInGrid();
            statusLabel.Text = $"Tìm thấy {filteredProducts.Count} sản phẩm";
        }

        /// <summary>
        /// Áp dụng sắp xếp
        /// </summary>
        private void ApplySorting()
        {
            if (cmbSort.SelectedIndex == -1) return;

            switch (cmbSort.SelectedIndex)
            {
                case 0: // Mã SP (A-Z)
                    filteredProducts = filteredProducts.OrderBy(p => p.Id).ToList();
                    break;
                case 1: // Mã SP (Z-A)
                    filteredProducts = filteredProducts.OrderByDescending(p => p.Id).ToList();
                    break;
                case 2: // Tên SP (A-Z)
                    filteredProducts = filteredProducts.OrderBy(p => p.Name).ToList();
                    break;
                case 3: // Tên SP (Z-A)
                    filteredProducts = filteredProducts.OrderByDescending(p => p.Name).ToList();
                    break;
                case 4: // Giá (Thấp-Cao)
                    filteredProducts = filteredProducts.OrderBy(p => p.Price).ToList();
                    break;
                case 5: // Giá (Cao-Thấp)
                    filteredProducts = filteredProducts.OrderByDescending(p => p.Price).ToList();
                    break;
                case 6: // Số lượng (Thấp-Cao)
                    filteredProducts = filteredProducts.OrderBy(p => p.Quantity).ToList();
                    break;
                case 7: // Số lượng (Cao-Thấp)
                    filteredProducts = filteredProducts.OrderByDescending(p => p.Quantity).ToList();
                    break;
                case 8: // Bảo hành (A-Z)
                    filteredProducts = filteredProducts.OrderBy(p => p.WarrantyPeriod).ToList();
                    break;
                case 9: // Bảo hành (Z-A)
                    filteredProducts = filteredProducts.OrderByDescending(p => p.WarrantyPeriod).ToList();
                    break;
            }
        }

        /// <summary>
        /// Cập nhật thống kê
        /// </summary>
        private void UpdateStatistics()
        {
            int totalProducts = filteredProducts.Count;
            decimal totalValue = filteredProducts.Sum(p => p.Price * p.Quantity);
            int lowStockCount = filteredProducts.Count(p => p.Quantity <= 10);
            int warrantyCount = filteredProducts.Select(p => p.WarrantyPeriod).Distinct().Count();

            lblTotalProductsValue.Text = totalProducts.ToString();
            lblTotalValueValue.Text = $"{totalValue:N0} đ";
            lblLowStockValue.Text = lowStockCount.ToString();
            lblWarrantyCountValue.Text = warrantyCount.ToString();

            // Đổi màu theo số lượng
            lblTotalProductsValue.ForeColor = totalProducts > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblTotalValueValue.ForeColor = totalValue > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblLowStockValue.ForeColor = lowStockCount > 0 ? Color.Red : Color.FromArgb(46, 204, 113);
            lblWarrantyCountValue.ForeColor = warrantyCount > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
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