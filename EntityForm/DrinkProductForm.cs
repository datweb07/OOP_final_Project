using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
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

        BindingSource _src = new BindingSource();
        private void FormBeverage_Load(object sender, EventArgs e)
        {
            gridData.DataSource = _src;
            gridData.AllowUserToAddRows = false;
            gridData.ReadOnly = true;

            chkIsAlcoholic.Checked = true;
            drinkProducts = drinkProductData.GetData();
            DisplayInGrid();
        }

        // Hiển thị dữ liệu từ danh sách ra lưới
        private void DisplayInGrid()
        {
            // Gán nguồn dữ liệu cho BindinSource
            _src.DataSource = drinkProducts;
            // Làm tươi lại dữ liệu hiển thị
            _src.ResetBindings(true);
        }

        // Xoá trống các control trên form
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            txtQty.Text = "";
            chkIsAlcoholic.Checked = false;
        }

        // Lưu lại thông tin
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Mã đồ uống không được để trống !"
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

            // Duyệt qua danh sách kiểm tra đã tồn tại mã hàng này chưa
            DrinkProduct drinkProduct = null;

            for (int i = 0; i < drinkProducts.Count; i++)
            {
                if (drinkProducts[i].Id.ToLower() == txtCode.Text.ToLower())
                {
                    drinkProduct = drinkProducts[i];
                    break;
                }
            }

            // Nếu không tồn tại thì tạo mới đối tượng và
            // thêm vào danh sách
            if (drinkProduct == null)
            {
                drinkProduct = new DrinkProduct(txtCode.Text, txtName.Text, txtPrice.Value, txtQty.Value, chkIsAlcoholic.Checked);
                drinkProducts.Add(drinkProduct);
            }

            // Ngược lại thay đổi các thông tin của đối tượng tìm được
            // trong dánh sách
            drinkProduct.Name = txtName.Text;
            drinkProduct.Price = txtPrice.Value;
            drinkProduct.Quantity = txtQty.Value;
            drinkProduct.Carbonated = chkIsAlcoholic.Checked;

            // Hiển thị thông tin của danh sách mới ra lưới
            DisplayInGrid();

            // Lưu lại danh sách vào tập tin 
            drinkProductData.SaveData(drinkProducts);

            // Hiên thị thông báo lưu thành công

            MessageBox.Show("Cập nhật thông tin đồ uống thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Tìm đối tượng cần xoá trong danh sách

            DrinkProduct drinkProduct = null;

            for (int i = 0; i < drinkProducts.Count; i++)
            {
                if (drinkProducts[i].Id.ToLower() == txtCode.Text.ToLower())
                {
                    drinkProduct = drinkProducts[i];
                    break;
                }
            }

            // Nếu tìm thấy thì xoá khỏi danh sách
            if (drinkProduct != null)
            {
                drinkProducts.Remove(drinkProduct);
            }

            // Hiển thị lại lưới
            DisplayInGrid();

            // Lưu danh sách vào tập tin
            drinkProductData.SaveData(drinkProducts);

            // Hiển thị thông báo lưu thông tin thành công

            MessageBox.Show("Xoá thông tin đồ uống thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void gridData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            DrinkProduct drinkProduct = (DrinkProduct)gridData.CurrentRow.DataBoundItem;

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
    }
}
