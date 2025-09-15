using OOP_finalProject.Base;
using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        private DrinkProductData drinkProductData = new DrinkProductData();
        private FoodProductData foodProductData = new FoodProductData();
        private HouseholdProductData householdProductData = new HouseholdProductData();

        // Danh sách toàn bộ sản phẩm
        private List<Product> products = new List<Product>();

        BindingSource src = new BindingSource();
        private void FormProduct_Load(object sender, EventArgs e)
        {
            gridData.ReadOnly = true;
            gridData.DataSource = src;
            LoadProducts();
        }

        private void LoadProducts()
        {
            // lấy ra danh sách sản phẩm cụ thể và thêm vào danh sách tổng quát
            List<DrinkProduct> drinkProducts = drinkProductData.GetData();
            List<FoodProduct> foodProducts = foodProductData.GetData();
            List<HouseholdProduct> householdProducts = householdProductData.GetData();

            for (int i = 0; i < drinkProducts.Count; i++)
            {
                products.Add(drinkProducts[i]);
            }

            for (int i = 0; i < foodProducts.Count; i++)
            {
                products.Add(foodProducts[i]);
            }

            for (int i = 0; i < householdProducts.Count; i++)
            {
                products.Add(householdProducts[i]);
            }

            // Gán dữ liệu danh sách tổng quát vào BindingSource để hiển thị ra lưới
            src.DataSource = products;
            // Làm tươi lưới dữ liệu
            src.ResetBindings(true);
        }
    }
}
