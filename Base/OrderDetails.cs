using OOP_finalProject.Base;

namespace OOP_finalProject
{
    public class OrderDetails
    {
        private Product product;
        private int quantity = 0;

        public Product Product { get { return product; } set { product = value; } }
        public string ProductID
        {
            get
            {
                if (Product == null)
                    return "Không xác định";
                return Product.Id;
            }
        }

        public string ProductName
        {
            get
            {
                if (Product == null)
                    return "Không xác định";
                return Product.Name;
            }
        }

        public int Quantity { get { return quantity; } set { quantity = value; } }
        public decimal UnitPrice
        {
            get
            {
                if (Product == null)
                    return 0;
                return Product.Price;
            }
        }
        public decimal TotalPrice
        {
            get
            {
                if (Product == null)
                    return 0;
                return UnitPrice * Quantity;
            }
        }
    }
}
