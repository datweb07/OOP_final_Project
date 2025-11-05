<<<<<<< HEAD
﻿//using OOP_finalProject.Products;
//using System;
//using System.Collections.Generic;
//using System.Windows.Forms;

//namespace OOP_finalProject
//{
//    public partial class HouseholdProductForm : Form
//    {
//        public HouseholdProductForm()
//        {
//            InitializeComponent();
//        }


//        private HouseholdProductData householdProductData = new HouseholdProductData();
//        private List<HouseholdProduct> householdProducts = new List<HouseholdProduct>();

//        BindingSource _src = new BindingSource();
//        private void FormHouseHoldItem_Load(object sender, EventArgs e)
//        {
//            HouseholdProductData.CreateSampleData();
//            gridData.DataSource = _src;
//            gridData.AllowUserToAddRows = false;
//            gridData.ReadOnly = true;
//            cboBrand.Items.Clear();
//            cboBrand.Items.Add("Sony");
//            cboBrand.Items.Add("Samsung");
//            cboBrand.Items.Add("Apple");
//            cboBrand.Items.Add("Nature Hike");
//            cboBrand.Items.Add("IKIA");
//            cboBrand.SelectedIndex = 0;
//            householdProducts = householdProductData.GetData();
//            DisplayInGrid();
//        }

//        private void DisplayInGrid()
//        {
//            _src.DataSource = householdProducts;
//            _src.ResetBindings(true);
//        }

//        private void btnRefresh_Click(object sender, EventArgs e)
//        {
//            txtCode.Text = "";
//            txtName.Text = "";
//            txtPrice.Text = "";
//            txtQty.Text = "";
//            cboBrand.SelectedIndex = 0;
//        }

//        private void btnSave_Click(object sender, EventArgs e)
//        {
//            if (string.IsNullOrEmpty(txtCode.Text))
//            {
//                MessageBox.Show("Mã đồ gia dụng không được để trống !"
//                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            if (string.IsNullOrEmpty(txtName.Text))
//            {
//                MessageBox.Show("Tên sản phẩm không được để trống !",
//                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            if (txtPrice.Value < 0)
//            {
//                MessageBox.Show("Giá sản phẩm không được bé hơn 0 !",
//                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            if (txtQty.Value < 0)
//            {
//                MessageBox.Show("Số lượng sản phẩm không được bé hơn 0 !",
//                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            if (cboBrand.SelectedIndex < 0)
//            {
//                MessageBox.Show("Vui lòng chọn nhãn hiệu !"
//                   , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }
//            HouseholdProduct householdProduct = null;

//            for (int i = 0; i < householdProducts.Count; i++)
//            {
//                if (householdProducts[i].Id.ToLower() == txtCode.Text.ToLower())
//                {
//                    householdProduct = householdProducts[i];
//                    break;
//                }
//            }

//            if (householdProduct == null)
//            {
//                householdProduct = new HouseholdProduct(txtCode.Text, txtName.Text, txtPrice.Value, txtQty.Value, (string)cboBrand.SelectedItem);
//                householdProducts.Add(householdProduct);
//            }

//            householdProduct.Name = txtName.Text;
//            householdProduct.Price = txtPrice.Value;
//            householdProduct.Quantity = txtQty.Value;
//            householdProduct.Brand = (string)cboBrand.SelectedItem;

//            DisplayInGrid();

//            // save data in database
//            householdProductData.SaveData(householdProducts);

//            MessageBox.Show("Cập nhật thông tin đồ gia dụng thành công !"
//                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            return;
//        }

//        private void btnDelete_Click(object sender, EventArgs e)
//        {
//            HouseholdProduct householdProduct = null;

//            for (int i = 0; i < householdProducts.Count; i++)
//            {
//                if (householdProducts[i].Id.ToLower() == txtCode.Text.ToLower())
//                {
//                    householdProduct = householdProducts[i];
//                    break;
//                }
//            }

//            if (householdProduct != null)
//            {
//                householdProducts.Remove(householdProduct);
//            }

//            DisplayInGrid();

//            householdProductData.SaveData(householdProducts);


//            MessageBox.Show("Xoá thông tin đồ gia dụng thành công !"
//                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            return;
//        }

//        private void gridData_CellEnter(object sender, DataGridViewCellEventArgs e)
//        {
//            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
//                return;

//            HouseholdProduct householdProduct = (HouseholdProduct)gridData.CurrentRow.DataBoundItem;

//            if (householdProduct == null)
//                return;

//            Display(householdProduct);
//        }

//        public void Display(HouseholdProduct householdProduct)
//        {
//            txtCode.Text = householdProduct.Id;
//            txtName.Text = householdProduct.Name;
//            txtPrice.Value = householdProduct.Price;
//            txtQty.Value = householdProduct.Quantity;
//            cboBrand.SelectedItem = householdProduct.Brand;
//        }
//    }
//}


using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
=======
﻿using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class HouseholdProductForm : Form
    {
        public HouseholdProductForm()
        {
            InitializeComponent();
        }

<<<<<<< HEAD
        private HouseholdProductData householdProductData = new HouseholdProductData();
        private List<HouseholdProduct> householdProducts = new List<HouseholdProduct>();
        private List<HouseholdProduct> filteredProducts = new List<HouseholdProduct>();

        BindingSource _src = new BindingSource();

        private void FormHouseHoldItem_Load(object sender, EventArgs e)
        {
            HouseholdProductData.CreateSampleData();

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

            // Khởi tạo danh sách thương hiệu
            InitializeBrands();

            // Thiết lập mặc định
            cmbSort.SelectedIndex = 0;
            cmbBrandFilter.SelectedIndex = 0;

            householdProducts = householdProductData.GetData();
            filteredProducts = householdProducts.ToList();
            DisplayInGrid();
        }

        private void InitializeBrands()
        {
            string[] brands = new string[] {
        "Sony", "Samsung", "Apple", "Nature Hike", "IKIA",
        "LG", "Toshiba", "Panasonic", "Philips", "Electrolux",
        "Midea", "Aqua", "Sunhouse", "Kangaroo", "Lock&Lock"
    };

            // ComboBox thương hiệu cho sản phẩm mới
            cboBrand.Items.Clear();
            cboBrand.Items.AddRange(brands);
            cboBrand.SelectedIndex = 0;

            // ComboBox lọc thương hiệu
            cmbBrandFilter.Items.Clear();
            cmbBrandFilter.Items.Add("Tất cả thương hiệu");
            cmbBrandFilter.Items.AddRange(brands);
            cmbBrandFilter.SelectedIndex = 0;
=======

        private HouseholdProductData householdProductData = new HouseholdProductData();
        private List<HouseholdProduct> householdProducts = new List<HouseholdProduct>();

        BindingSource _src = new BindingSource();
        private void FormHouseHoldItem_Load(object sender, EventArgs e)
        {
            gridData.DataSource = _src;
            gridData.AllowUserToAddRows = false;
            gridData.ReadOnly = true;
            cboBrand.Items.Clear();
            cboBrand.Items.Add("Sony");
            cboBrand.Items.Add("Samsung");
            cboBrand.Items.Add("Apple");
            cboBrand.Items.Add("Nature Hike");
            cboBrand.Items.Add("IKIA");
            cboBrand.SelectedIndex = 0;
            householdProducts = householdProductData.GetData();
            DisplayInGrid();
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        }

        private void DisplayInGrid()
        {
<<<<<<< HEAD
            _src.DataSource = filteredProducts;
            _src.ResetBindings(true);
            UpdateStatistics();
=======
            _src.DataSource = householdProducts;
            _src.ResetBindings(true);
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtName.Text = "";
<<<<<<< HEAD
            txtPrice.Value = 0;
            txtQty.Value = 0;
            txtSearch.Text = "";
            cboBrand.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            cmbBrandFilter.SelectedIndex = 0;
            chkLowStockOnly.Checked = false;

            filteredProducts = householdProducts.ToList();
            ApplyFiltersAndSearch();
            statusLabel.Text = "Đã làm mới danh sách";
=======
            txtPrice.Text = "";
            txtQty.Text = "";
            cboBrand.SelectedIndex = 0;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if (!ValidateInput())
                return;

=======
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Mã đồ gia dụng không được để trống !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống !",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtPrice.Value < 0)
            {
                MessageBox.Show("Giá sản phẩm không được bé hơn 0 !",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtQty.Value < 0)
            {
                MessageBox.Show("Số lượng sản phẩm không được bé hơn 0 !",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboBrand.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhãn hiệu !"
                   , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            HouseholdProduct householdProduct = null;

            for (int i = 0; i < householdProducts.Count; i++)
            {
                if (householdProducts[i].Id.ToLower() == txtCode.Text.ToLower())
                {
                    householdProduct = householdProducts[i];
                    break;
                }
            }

            if (householdProduct == null)
            {
<<<<<<< HEAD
                householdProduct = new HouseholdProduct(
                    txtCode.Text,
                    txtName.Text,
                    txtPrice.Value,
                    txtQty.Value,
                    (string)cboBrand.SelectedItem);
                householdProducts.Add(householdProduct);
            }
            else
            {
                householdProduct.Name = txtName.Text;
                householdProduct.Price = txtPrice.Value;
                householdProduct.Quantity = txtQty.Value;
                householdProduct.Brand = (string)cboBrand.SelectedItem;
            }

            ApplyFiltersAndSearch();
=======
                householdProduct = new HouseholdProduct(txtCode.Text, txtName.Text, txtPrice.Value, txtQty.Value, (string)cboBrand.SelectedItem);
                householdProducts.Add(householdProduct);
            }

            householdProduct.Name = txtName.Text;
            householdProduct.Price = txtPrice.Value;
            householdProduct.Quantity = txtQty.Value;
            householdProduct.Brand = (string)cboBrand.SelectedItem;

            DisplayInGrid();

            // save data in database
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            householdProductData.SaveData(householdProducts);

            MessageBox.Show("Cập nhật thông tin đồ gia dụng thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
<<<<<<< HEAD

            statusLabel.Text = "Đã lưu thông tin thành công";
            statusLabel.ForeColor = Color.FromArgb(46, 204, 113);
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Mã đồ gia dụng không được để trống !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCode.Focus();
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

            if (txtQty.Value < 0)
            {
                MessageBox.Show("Số lượng sản phẩm không được bé hơn 0 !",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQty.Focus();
                return false;
            }

            if (cboBrand.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn thương hiệu !"
                   , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboBrand.Focus();
                return false;
            }

            return true;
=======
            return;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
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

=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            HouseholdProduct householdProduct = null;

            for (int i = 0; i < householdProducts.Count; i++)
            {
                if (householdProducts[i].Id.ToLower() == txtCode.Text.ToLower())
                {
                    householdProduct = householdProducts[i];
                    break;
                }
            }

            if (householdProduct != null)
            {
                householdProducts.Remove(householdProduct);
<<<<<<< HEAD
                ApplyFiltersAndSearch();
                householdProductData.SaveData(householdProducts);

                MessageBox.Show("Xoá thông tin đồ gia dụng thành công !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnRefresh_Click(null, null);
                statusLabel.Text = "Đã xóa sản phẩm thành công";
                statusLabel.ForeColor = Color.FromArgb(46, 204, 113);
            }
=======
            }

            DisplayInGrid();

            householdProductData.SaveData(householdProducts);


            MessageBox.Show("Xoá thông tin đồ gia dụng thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        }

        private void gridData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            HouseholdProduct householdProduct = (HouseholdProduct)gridData.CurrentRow.DataBoundItem;

            if (householdProduct == null)
                return;

            Display(householdProduct);
        }

        public void Display(HouseholdProduct householdProduct)
        {
            txtCode.Text = householdProduct.Id;
            txtName.Text = householdProduct.Name;
            txtPrice.Value = householdProduct.Price;
            txtQty.Value = householdProduct.Quantity;
            cboBrand.SelectedItem = householdProduct.Brand;
        }
<<<<<<< HEAD

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
            txtCode.Focus();
            statusLabel.Text = "Nhập thông tin sản phẩm mới";
        }

        /// <summary>
        /// Áp dụng tất cả bộ lọc và tìm kiếm
        /// </summary>
        private void ApplyFiltersAndSearch()
        {
            // Bắt đầu từ danh sách đầy đủ
            filteredProducts = householdProducts.ToList();

            // Áp dụng tìm kiếm
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                filteredProducts = filteredProducts.Where(p =>
                    p.Id.ToLower().Contains(txtSearch.Text.ToLower()) ||
                    p.Name.ToLower().Contains(txtSearch.Text.ToLower()) ||
                    p.Brand.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            }

            // Áp dụng lọc thương hiệu
            if (cmbBrandFilter.SelectedIndex > 0)
            {
                string selectedBrand = cmbBrandFilter.SelectedItem.ToString();
                filteredProducts = filteredProducts.Where(p => p.Brand == selectedBrand).ToList();
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
                case 8: // Thương hiệu (A-Z)
                    filteredProducts = filteredProducts.OrderBy(p => p.Brand).ToList();
                    break;
                case 9: // Thương hiệu (Z-A)
                    filteredProducts = filteredProducts.OrderByDescending(p => p.Brand).ToList();
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
            int brandCount = filteredProducts.Select(p => p.Brand).Distinct().Count();

            lblTotalProductsValue.Text = totalProducts.ToString();
            lblTotalValueValue.Text = $"{totalValue:N0} đ";
            lblLowStockValue.Text = lowStockCount.ToString();
            lblBrandCountValue.Text = brandCount.ToString();

            // Đổi màu theo số lượng
            lblTotalProductsValue.ForeColor = totalProducts > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblTotalValueValue.ForeColor = totalValue > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblLowStockValue.ForeColor = lowStockCount > 0 ? Color.Red : Color.FromArgb(46, 204, 113);
            lblBrandCountValue.ForeColor = brandCount > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
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
=======
    }
}
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
