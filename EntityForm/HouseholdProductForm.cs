using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class HouseholdProductForm : Form
    {
        //public HouseholdProductForm()
        //{
        //    InitializeComponent();
        //}


        //private HouseholdProductData householdProductData = new HouseholdProductData();
        //private List<HouseholdProduct> householdProducts = new List<HouseholdProduct>();

        //BindingSource _src = new BindingSource();
        //private void FormHouseHoldItem_Load(object sender, EventArgs e)
        //{
        //    gridData.DataSource = _src;
        //    gridData.AllowUserToAddRows = false;
        //    gridData.ReadOnly = true;
        //    cboBrand.Items.Clear();
        //    cboBrand.Items.Add("Sony");
        //    cboBrand.Items.Add("Samsung");
        //    cboBrand.Items.Add("Apple");
        //    cboBrand.Items.Add("Nature Hike");
        //    cboBrand.Items.Add("IKIA");
        //    cboBrand.SelectedIndex = 0;
        //    householdProducts = householdProductData.GetData();
        //    DisplayInGrid();
        //}

        //private void DisplayInGrid()
        //{
        //    _src.DataSource = householdProducts;
        //    _src.ResetBindings(true);
        //}

        //private void btnRefresh_Click(object sender, EventArgs e)
        //{
        //    txtCode.Text = "";
        //    txtName.Text = "";
        //    txtPrice.Text = "";
        //    txtQty.Text = "";
        //    cboBrand.SelectedIndex = 0;
        //}

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(txtCode.Text))
        //    {
        //        MessageBox.Show("Mã đồ gia dụng không được để trống !"
        //            , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    if (string.IsNullOrEmpty(txtName.Text))
        //    {
        //        MessageBox.Show("Tên sản phẩm không được để trống !",
        //            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    if (txtPrice.Value < 0)
        //    {
        //        MessageBox.Show("Giá sản phẩm không được bé hơn 0 !",
        //            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    if (txtQty.Value < 0)
        //    {
        //        MessageBox.Show("Số lượng sản phẩm không được bé hơn 0 !",
        //            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    if (cboBrand.SelectedIndex < 0)
        //    {
        //        MessageBox.Show("Vui lòng chọn nhãn hiệu !"
        //           , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    HouseholdProduct householdProduct = null;

        //    for (int i = 0; i < householdProducts.Count; i++)
        //    {
        //        if (householdProducts[i].Id.ToLower() == txtCode.Text.ToLower())
        //        {
        //            householdProduct = householdProducts[i];
        //            break;
        //        }
        //    }

        //    if (householdProduct == null)
        //    {
        //        householdProduct = new HouseholdProduct(txtCode.Text, txtName.Text, txtPrice.Value, txtQty.Value, (string)cboBrand.SelectedItem);
        //        householdProducts.Add(householdProduct);
        //    }

        //    householdProduct.Name = txtName.Text;
        //    householdProduct.Price = txtPrice.Value;
        //    householdProduct.Quantity = txtQty.Value;
        //    householdProduct.Brand = (string)cboBrand.SelectedItem;

        //    DisplayInGrid();

        //    // save data in database
        //    householdProductData.SaveData(householdProducts);

        //    MessageBox.Show("Cập nhật thông tin đồ gia dụng thành công !"
        //        , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    return;
        //}

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    HouseholdProduct householdProduct = null;

        //    for (int i = 0; i < householdProducts.Count; i++)
        //    {
        //        if (householdProducts[i].Id.ToLower() == txtCode.Text.ToLower())
        //        {
        //            householdProduct = householdProducts[i];
        //            break;
        //        }
        //    }

        //    if (householdProduct != null)
        //    {
        //        householdProducts.Remove(householdProduct);
        //    }

        //    DisplayInGrid();

        //    householdProductData.SaveData(householdProducts);


        //    MessageBox.Show("Xoá thông tin đồ gia dụng thành công !"
        //        , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    return;
        //}

        //private void gridData_CellEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
        //        return;

        //    HouseholdProduct householdProduct = (HouseholdProduct)gridData.CurrentRow.DataBoundItem;

        //    if (householdProduct == null)
        //        return;

        //    Display(householdProduct);
        //}

        //public void Display(HouseholdProduct householdProduct)
        //{
        //    txtCode.Text = householdProduct.Id;
        //    txtName.Text = householdProduct.Name;
        //    txtPrice.Value = householdProduct.Price;
        //    txtQty.Value = householdProduct.Quantity;
        //    cboBrand.SelectedItem = householdProduct.Brand;
        //}

        public HouseholdProductForm()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            // Thiết lập màu sắc chủ đạo
            this.BackColor = Color.FromArgb(240, 240, 245);
            this.ForeColor = Color.FromArgb(40, 40, 50);

            // Font chữ
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        }

        #region Data and Members
        private HouseholdProductData householdProductData = new HouseholdProductData();
        private List<HouseholdProduct> householdProducts = new List<HouseholdProduct>();
        private BindingSource _src = new BindingSource();
        #endregion

        #region Event Handlers
        private void FormHouseHoldItem_Load(object sender, EventArgs e)
        {
            // Cấu hình ComboBox
            cboBrand.Items.Clear();
            cboBrand.Items.Add("Sony");
            cboBrand.Items.Add("Samsung");
            cboBrand.Items.Add("Apple");
            cboBrand.Items.Add("Nature Hike");
            cboBrand.Items.Add("IKEA");
            cboBrand.SelectedIndex = 0;

            // Cấu hình DataGridView
            gridData.DataSource = _src;
            gridData.AllowUserToAddRows = false;
            gridData.ReadOnly = true;
            gridData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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

            // Tải dữ liệu
            householdProducts = householdProductData.GetData();
            DisplayInGrid();

            // Đăng ký sự kiện mới
            btnSearch.Click += BtnSearch_Click;
            btnAddNew.Click += BtnAddNew_Click;
            // Sử dụng phương thức riêng thay cho lambda expression
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        // Phương thức xử lý sự kiện thay thế cho lambda
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            BtnSearch_Click(null, null);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                List<HouseholdProduct> filteredProducts = new List<HouseholdProduct>();
                string searchText = txtSearch.Text.ToLower();

                foreach (HouseholdProduct product in householdProducts)
                {
                    if (product.Id.ToLower().Contains(searchText) ||
                        product.Name.ToLower().Contains(searchText) ||
                        product.Brand.ToLower().Contains(searchText))
                    {
                        filteredProducts.Add(product);
                    }
                }

                _src.DataSource = filteredProducts;
                _src.ResetBindings(false);
                statusLabel.Text = "Tìm thấy " + filteredProducts.Count.ToString() + " kết quả";
            }
            else
            {
                DisplayInGrid();
                statusLabel.Text = "Sẵn sàng";
            }
        }

        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
            txtCode.Focus();
            statusLabel.Text = "Nhập thông tin sản phẩm mới";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtPrice.Value = 0;
            txtQty.Value = 0;
            cboBrand.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Mã đồ gia dụng không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtPrice.Value < 0)
            {
                MessageBox.Show("Giá sản phẩm không được bé hơn 0 !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtQty.Value < 0)
            {
                MessageBox.Show("Số lượng sản phẩm không được bé hơn 0 !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboBrand.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhãn hiệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


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
                householdProduct = new HouseholdProduct(txtCode.Text, txtName.Text, txtPrice.Value, txtQty.Value, (string)cboBrand.SelectedItem);
                householdProducts.Add(householdProduct);
            }
            else
            {
                householdProduct.Name = txtName.Text;
                householdProduct.Price = txtPrice.Value;
                householdProduct.Quantity = txtQty.Value;
                householdProduct.Brand = (string)cboBrand.SelectedItem;
            }

            // Save and Refresh 
            householdProductData.SaveData(householdProducts);
            DisplayInGrid();
            MessageBox.Show("Cập nhật thông tin đồ gia dụng thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            statusLabel.Text = "Đã lưu sản phẩm: " + householdProduct.Name;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            HouseholdProduct productToDelete = null;


            for (int i = 0; i < householdProducts.Count; i++)
            {
                if (householdProducts[i].Id.ToLower() == txtCode.Text.ToLower())
                {
                    productToDelete = householdProducts[i];
                    break;
                }
            }

            if (productToDelete != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm '" + productToDelete.Name + "'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    householdProducts.Remove(productToDelete);
                    householdProductData.SaveData(householdProducts);
                    DisplayInGrid();
                    btnRefresh_Click(null, null);
                    MessageBox.Show("Xoá thông tin đồ gia dụng thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    statusLabel.Text = "Đã xóa sản phẩm: " + productToDelete.Name;
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow) return;


            HouseholdProduct householdProduct = gridData.CurrentRow.DataBoundItem as HouseholdProduct;
            if (householdProduct != null)
            {
                Display(householdProduct);
            }
        }
        #endregion

        #region Helper Methods
        private void DisplayInGrid()
        {
            _src.DataSource = null;
            _src.DataSource = householdProducts;
            _src.ResetBindings(false);
        }

        public void Display(HouseholdProduct householdProduct)
        {
            txtCode.Text = householdProduct.Id;
            txtName.Text = householdProduct.Name;
            txtPrice.Value = householdProduct.Price;
            txtQty.Value = householdProduct.Quantity;
            cboBrand.SelectedItem = householdProduct.Brand;
        }
        #endregion
    }
}

