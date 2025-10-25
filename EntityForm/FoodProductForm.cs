using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class FoodProductForm : Form
    {
        public FoodProductForm()
        {
            InitializeComponent();
        }

        private FoodProductData foodProductData = new FoodProductData();
        private List<FoodProduct> foodProducts = new List<FoodProduct>();

        BindingSource _src = new BindingSource();
        private void FormFood_Load(object sender, EventArgs e)
        {
            FoodProductData.CreateSampleData();
            gridData.DataSource = _src;
            gridData.AllowUserToAddRows = false;
            gridData.ReadOnly = true;
            foodProducts = foodProductData.GetData();
            DisplayInGrid();
        }

        private void DisplayInGrid()
        {
            _src.DataSource = foodProducts;
            _src.ResetBindings(true);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            txtQty.Text = "";
            dtExpirationDate.Value = DateTime.Now;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Mã thực phẩm không được để trống !"
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

            FoodProduct foodProduct = null;

            for (int i = 0; i < foodProducts.Count; i++)
            {
                if (foodProducts[i].Id.ToLower() == txtCode.Text.ToLower())
                {
                    foodProduct = foodProducts[i];
                    break;
                }
            }

            if (foodProduct == null)
            {
                foodProduct = new FoodProduct(txtCode.Text, txtName.Text, txtPrice.Value, txtQty.Value, dtExpirationDate.Value);
                foodProducts.Add(foodProduct);
            }

            foodProduct.Name = txtName.Text;
            foodProduct.Price = txtPrice.Value;
            foodProduct.Quantity = txtQty.Value;
            foodProduct.ExpirationDate = dtExpirationDate.Value;

            DisplayInGrid();

            // save data in database
            foodProductData.SaveData(foodProducts);

            MessageBox.Show("Cập nhật thông tin thực phẩm thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FoodProduct foodProduct = null;

            for (int i = 0; i < foodProducts.Count; i++)
            {
                if (foodProducts[i].Id.ToLower() == txtCode.Text.ToLower())
                {
                    foodProduct = foodProducts[i];
                    break;
                }
            }

            if (foodProduct != null)
            {
                foodProducts.Remove(foodProduct);
            }

            DisplayInGrid();

            foodProductData.SaveData(foodProducts);


            MessageBox.Show("Xoá thông tin thực phẩm thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void gridData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            FoodProduct foodProduct = (FoodProduct)gridData.CurrentRow.DataBoundItem;

            if (foodProduct == null)
                return;

            Display(foodProduct);
        }

        public void Display(FoodProduct foodProduct)
        {
            txtCode.Text = foodProduct.Id;
            txtName.Text = foodProduct.Name;
            txtPrice.Value = foodProduct.Price;
            txtQty.Value = foodProduct.Quantity;

            //// Kiểm tra trước khi gán
            //if (foodProduct.ExpirationDate < dtExpirationDate.MinDate)
            //    dtExpirationDate.Value = DateTime.Now;
            //else
            //    dtExpirationDate.Value = foodProduct.ExpirationDate;
        }

    }
}
