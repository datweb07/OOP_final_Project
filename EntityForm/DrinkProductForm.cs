using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class DrinkProductForm : Form
    {
        public DrinkProductForm()
        {
            InitializeComponent();
        }

        private DrinkProductData drinkProductData = new DrinkProductData();
        private List<DrinkProduct> drinkProducts = new List<DrinkProduct>();
        private List<DrinkProduct> filteredProducts = new List<DrinkProduct>();
        private bool isRefresh = false;

        BindingSource _src = new BindingSource();

        private void FormBeverage_Load(object sender, EventArgs e)
        {
            DrinkProductData.CreateSampleData();
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

            chkIsAlcoholic.Checked = false;
            drinkProducts = drinkProductData.GetData();
            filteredProducts = drinkProducts.ToList();

            // Mặc định chọn option đầu tiên trong comboBox sắp xếp
            cmbSort.SelectedIndex = 0;

            DisplayInGrid();
            UpdateStatistics();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
            txtCode.Focus();
            statusLabel.Text = "Nhập thông tin sản phẩm mới";
        }

        private void DisplayInGrid()
        {
            _src.DataSource = filteredProducts;
            _src.ResetBindings(true);
            UpdateStatistics();
            statusLabel.Text = $"Tìm thấy {filteredProducts.Count} sản phẩm";
        }
       
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            isRefresh = true;
            
            txtCode.Text = "";
            txtName.Text = "";
            txtPrice.Value = 0;
            txtQty.Value = 0;
            chkIsAlcoholic.Checked = false;
            txtSearch.Text = "";
            rdoAll.Checked = true;
            cmbSort.SelectedIndex = 0;
          

            filteredProducts = drinkProducts.ToList();
            // Reset về danh sách đầy đủ
            ApplyFiltersAndSearch();
            statusLabel.Text = "Đã làm mới danh sách";
            isRefresh = false;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Mã đồ uống không được để trống !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCode.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống !",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }

            if (txtPrice.Value < 0)
            {
                MessageBox.Show("Giá sản phẩm không được bé hơn 0 !",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice.Focus();
                return;
            }

            if (txtQty.Value < 0)
            {
                MessageBox.Show("Số lượng sản phẩm không được bé hơn 0 !",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQty.Focus();
                return;
            }

            DrinkProduct drinkProduct = null;

            for (int i = 0; i < drinkProducts.Count; i++)
            {
                if (drinkProducts[i].Id.ToLower() == txtCode.Text.ToLower())
                {
                    drinkProduct = drinkProducts[i];
                    break;
                }
            }

            if (drinkProduct == null)
            {
                drinkProduct = new DrinkProduct(txtCode.Text, txtName.Text, txtPrice.Value, txtQty.Value, chkIsAlcoholic.Checked);
                drinkProducts.Add(drinkProduct);
            }
            else
            {
                drinkProduct.Name = txtName.Text;
                drinkProduct.Price = txtPrice.Value;
                drinkProduct.Quantity = txtQty.Value;
                drinkProduct.Carbonated = chkIsAlcoholic.Checked;
            }

            // Cập nhật danh sách lọc
            ApplyFiltersAndSearch();

            drinkProductData.SaveData(drinkProducts);

            MessageBox.Show("Cập nhật thông tin đồ uống thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            statusLabel.Text = "Đã lưu thông tin thành công";
            statusLabel.ForeColor = Color.FromArgb(46, 204, 113);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
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

            DrinkProduct drinkProduct = null;

            for (int i = 0; i < drinkProducts.Count; i++)
            {
                if (drinkProducts[i].Id.ToLower() == txtCode.Text.ToLower())
                {
                    drinkProduct = drinkProducts[i];
                    break;
                }
            }

            if (drinkProduct != null)
            {
                drinkProducts.Remove(drinkProduct);
                ApplyFiltersAndSearch();
                drinkProductData.SaveData(drinkProducts);

                MessageBox.Show("Xoá thông tin đồ uống thành công !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnRefresh_Click(null, null);

                statusLabel.Text = "Đã xóa sản phẩm thành công";
                statusLabel.ForeColor = Color.FromArgb(46, 204, 113);
            }
        }

        private void gridData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (isRefresh) return;
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            DrinkProduct drinkProduct = gridData.CurrentRow.DataBoundItem as DrinkProduct;

            if (drinkProduct == null)
                return;

            Display(drinkProduct);
        }

        public void Display(DrinkProduct drinkProduct)
        {
            txtCode.Text = drinkProduct.Id;
            txtName.Text = drinkProduct.Name;
            txtPrice.Value = drinkProduct.Price;
            txtQty.Value = drinkProduct.Quantity;
            chkIsAlcoholic.Checked = drinkProduct.Carbonated;
        }

        #region Các chức năng mới

        /// <summary>
        /// Lọc sản phẩm theo gas
        /// </summary>
        private void FilterProducts(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }

        /// <summary>
        /// Sắp xếp sản phẩm
        /// </summary>
        private void SortProducts(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }

        /// <summary>
        /// Áp dụng tất cả bộ lọc và tìm kiếm
        /// </summary>
        private void ApplyFiltersAndSearch()
        {
            // Bắt đầu từ danh sách đầy đủ
            filteredProducts = drinkProducts.ToList();

            // Áp dụng tìm kiếm
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                filteredProducts = filteredProducts.Where(p =>
                    p.Id.ToLower().Contains(txtSearch.Text.ToLower()) ||
                    p.Name.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            }

            // Áp dụng lọc gas
            if (rdoWithGas.Checked)
            {
                filteredProducts = filteredProducts.Where(p => p.Carbonated).ToList();
            }
            else if (rdoWithoutGas.Checked)
            {
                filteredProducts = filteredProducts.Where(p => !p.Carbonated).ToList();
            }

            // Áp dụng sắp xếp
            ApplySorting();

            DisplayInGrid();

            statusLabel.Text = $"Tìm thấy {filteredProducts.Count} kết quả";
        }

        /// <summary>
        /// Áp dụng sắp xếp theo lựa chọn trong comboBox
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
            }
        }

        /// <summary>
        /// Cập nhật thống kê tổng sản phẩm và giá trị
        /// </summary>
        private void UpdateStatistics()
        {
            int totalProducts = filteredProducts.Count;
            decimal totalValue = filteredProducts.Sum(p => p.Price * p.Quantity);

            lblTotalProductsValue.Text = totalProducts.ToString();
            lblTotalValueValue.Text = $"{totalValue:N0} đ";

            // Đổi màu theo số lượng
            lblTotalProductsValue.ForeColor = totalProducts > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblTotalValueValue.ForeColor = totalValue > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
        }

        #endregion
    }
}

