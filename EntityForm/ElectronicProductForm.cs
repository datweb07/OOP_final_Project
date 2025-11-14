using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class ElectronicProductForm : Form
    {
        public ElectronicProductForm()
        {
            InitializeComponent();
        }

        private ElectronicProductData electronicProductData = new ElectronicProductData();
        private List<ElectronicProduct> electronicProducts = new List<ElectronicProduct>();
        private List<ElectronicProduct> filteredProducts = new List<ElectronicProduct>();
        private bool isFresh = false;

        BindingSource _src = new BindingSource();

        private void ElectronicForm_Load(object sender, EventArgs e)
        {
            electronicProductData.CreateSampleData();
            gridData.DataSource = _src;
            gridData.AllowUserToAddRows = false;
            gridData.ReadOnly = true;

            // tùy chỉnh giao diện DataGridView
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

            // khởi tạo thời gian bảo hành
            InitializeWarranty();

            cmbSort.SelectedIndex = 0;
            cmbWarrantyFilter.SelectedIndex = 0;

            electronicProducts = electronicProductData.GetData();
            filteredProducts = new List<ElectronicProduct>(electronicProducts);
            DisplayInGrid();
        }

        private void InitializeWarranty()
        {
            string[] warrantyPeriods = new string[] {
                "6 tháng", "12 tháng", "18 tháng", "24 tháng",
                "36 tháng", "48 tháng", "60 tháng"
            };

            // thêm thời gian bảo hành vào comboBox
            cboWarranty.Items.Clear();
            cboWarranty.Items.AddRange(warrantyPeriods);
            cboWarranty.SelectedIndex = 0;

            // lọc thời gian bảo hành
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
            statusLabel.Text = "Tìm thấy " + filteredProducts.Count + " sản phẩm";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            isFresh = true;

            txtId.Text = "";
            txtName.Text = "";
            txtPrice.Value = 0;
            txtQuantity.Value = 0;
            txtSearch.Text = "";
            cboWarranty.SelectedIndex = 0;
            cmbWarrantyFilter.SelectedIndex = 0;
            chkLowStockOnly.Checked = false;
            cmbSort.SelectedIndex = 0;

            filteredProducts = new List<ElectronicProduct>(electronicProducts);
            ApplyFiltersAndSearch();
            statusLabel.Text = "Đã làm mới danh sách";
            isFresh = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            ElectronicProduct product = null;

            for (int i = 0; i < electronicProducts.Count; i++)
            {
                if (electronicProducts[i].Id.ToLower() == txtId.Text.ToLower())
                {
                    product = electronicProducts[i];
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
                electronicProducts.Add(product);
            }
            else
            {
                product.Name = txtName.Text;
                product.Price = txtPrice.Value;
                product.Quantity = txtQuantity.Value;
                product.WarrantyPeriod = (string)cboWarranty.SelectedItem;
            }

            filteredProducts = new List<ElectronicProduct>(electronicProducts);
            DisplayInGrid();

            // lưu file dữ liệu
            electronicProductData.SaveData(electronicProducts);

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
                "Bạn có chắc chắn muốn xóa sản phẩm '" + txtName.Text + "'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            ElectronicProduct product = null;

            for (int i = 0; i < electronicProducts.Count; i++)
            {
                if (electronicProducts[i].Id.ToLower() == txtId.Text.ToLower())
                {
                    product = electronicProducts[i];
                    break;
                }
            }

            if (product != null)
            {
                electronicProducts.Remove(product);
                ApplyFiltersAndSearch();
                electronicProductData.SaveData(electronicProducts);

                MessageBox.Show("Xoá thông tin sản phẩm điện tử thành công !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnRefresh_Click(null, null);
                statusLabel.Text = "Đã xóa sản phẩm thành công";
                statusLabel.ForeColor = Color.FromArgb(46, 204, 113);
            }
        }

        private void gridData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (isFresh) return;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
            txtId.Focus();
            statusLabel.Text = "Nhập thông tin sản phẩm mới";
        }

        // lọc và tìm kiếm sản phẩm
        private void ApplyFiltersAndSearch()
        {
            // gắn lại danh sách ban đầu
            filteredProducts = new List<ElectronicProduct>(electronicProducts);

            // tìm kiếm
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                List<ElectronicProduct> searchResults = new List<ElectronicProduct>();
                string searchText = txtSearch.Text.ToLower();

                for (int i = 0; i < filteredProducts.Count; i++)
                {
                    ElectronicProduct product = filteredProducts[i];
                    if (product.Id.ToLower().Contains(searchText) ||
                        product.Name.ToLower().Contains(searchText) ||
                        product.WarrantyPeriod.ToLower().Contains(searchText))
                    {
                        searchResults.Add(product);
                    }
                }
                filteredProducts = searchResults;
            }

            // lọc bảo hành
            if (cmbWarrantyFilter.SelectedIndex > 0)
            {
                string selectedWarranty = cmbWarrantyFilter.SelectedItem.ToString();
                List<ElectronicProduct> warrantyResults = new List<ElectronicProduct>();

                for (int i = 0; i < filteredProducts.Count; i++)
                {
                    if (filteredProducts[i].WarrantyPeriod == selectedWarranty)
                    {
                        warrantyResults.Add(filteredProducts[i]);
                    }
                }
                filteredProducts = warrantyResults;
            }

            // lọc tồn kho thấp
            if (chkLowStockOnly.Checked)
            {
                List<ElectronicProduct> lowStockResults = new List<ElectronicProduct>();

                for (int i = 0; i < filteredProducts.Count; i++)
                {
                    if (filteredProducts[i].Quantity <= 10)
                    {
                        lowStockResults.Add(filteredProducts[i]);
                    }
                }
                filteredProducts = lowStockResults;
            }

            // sắp xếp
            ApplySorting();

            DisplayInGrid();
            statusLabel.Text = "Tìm thấy " + filteredProducts.Count + " kết quả";
        }

        // sắp xếp sản phẩm
        private void ApplySorting()
        {
            if (cmbSort.SelectedIndex == -1) return;

            switch (cmbSort.SelectedIndex)
            {
                case 0: // Mã SP (A-Z)
                    filteredProducts.Sort((p1, p2) => p1.Id.CompareTo(p2.Id));
                    break;
                case 1: // Mã SP (Z-A)
                    filteredProducts.Sort((p1, p2) => p2.Id.CompareTo(p1.Id));
                    break;
                case 2: // Tên SP (A-Z)
                    filteredProducts.Sort((p1, p2) => p1.Name.CompareTo(p2.Name));
                    break;
                case 3: // Tên SP (Z-A)
                    filteredProducts.Sort((p1, p2) => p2.Name.CompareTo(p1.Name));
                    break;
                case 4: // Giá (Thấp-Cao)
                    filteredProducts.Sort((p1, p2) => p1.Price.CompareTo(p2.Price));
                    break;
                case 5: // Giá (Cao-Thấp)
                    filteredProducts.Sort((p1, p2) => p2.Price.CompareTo(p1.Price));
                    break;
                case 6: // Số lượng (Thấp-Cao)
                    filteredProducts.Sort((p1, p2) => p1.Quantity.CompareTo(p2.Quantity));
                    break;
                case 7: // Số lượng (Cao-Thấp)
                    filteredProducts.Sort((p1, p2) => p2.Quantity.CompareTo(p1.Quantity));
                    break;
                case 8: // Bảo hành (A-Z)
                    filteredProducts.Sort((p1, p2) => p1.WarrantyPeriod.CompareTo(p2.WarrantyPeriod));
                    break;
                case 9: // Bảo hành (Z-A)
                    filteredProducts.Sort((p1, p2) => p2.WarrantyPeriod.CompareTo(p1.WarrantyPeriod));
                    break;
            }
        }

        // hiển thị thống kế
        private void UpdateStatistics()
        {
            int totalProducts = filteredProducts.Count;

            decimal totalValue = 0;
            for (int i = 0; i < filteredProducts.Count; i++)
            {
                totalValue += filteredProducts[i].Price * filteredProducts[i].Quantity;
            }

            int lowStockCount = 0;
            for (int i = 0; i < filteredProducts.Count; i++)
            {
                if (filteredProducts[i].Quantity <= 10)
                {
                    lowStockCount++;
                }
            }

            List<string> distinctWarranties = new List<string>();
            for (int i = 0; i < filteredProducts.Count; i++)
            {
                string warranty = filteredProducts[i].WarrantyPeriod;
                if (!distinctWarranties.Contains(warranty))
                {
                    distinctWarranties.Add(warranty);
                }
            }
            int warrantyCount = distinctWarranties.Count;

            lblTotalProductsValue.Text = totalProducts.ToString();
            lblTotalValueValue.Text = totalValue.ToString("N0") + " đ";
            lblLowStockValue.Text = lowStockCount.ToString();
            lblWarrantyCountValue.Text = warrantyCount.ToString();

            lblTotalProductsValue.ForeColor = totalProducts > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblTotalValueValue.ForeColor = totalValue > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblLowStockValue.ForeColor = lowStockCount > 0 ? Color.Red : Color.FromArgb(46, 204, 113);
            lblWarrantyCountValue.ForeColor = warrantyCount > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }
    }
}