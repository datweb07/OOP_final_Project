using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class HouseholdProductForm : Form
    {
        public HouseholdProductForm()
        {
            InitializeComponent();
        }


        private HouseholdProductData householdProductData = new HouseholdProductData();
        private List<HouseholdProduct> householdProducts = new List<HouseholdProduct>();

        BindingSource _src = new BindingSource();
        private void FormHouseHoldItem_Load(object sender, EventArgs e)
        {
            HouseholdProductData.CreateSampleData();
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
        }

        private void DisplayInGrid()
        {
            _src.DataSource = householdProducts;
            _src.ResetBindings(true);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            txtQty.Text = "";
            cboBrand.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
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

            householdProduct.Name = txtName.Text;
            householdProduct.Price = txtPrice.Value;
            householdProduct.Quantity = txtQty.Value;
            householdProduct.Brand = (string)cboBrand.SelectedItem;

            DisplayInGrid();

            // save data in database
            householdProductData.SaveData(householdProducts);

            MessageBox.Show("Cập nhật thông tin đồ gia dụng thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
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
            }

            DisplayInGrid();

            householdProductData.SaveData(householdProducts);


            MessageBox.Show("Xoá thông tin đồ gia dụng thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
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
    }
}
