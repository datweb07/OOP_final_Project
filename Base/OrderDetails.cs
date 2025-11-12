using OOP_finalProject.Base;
using System;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    [Serializable]
    public class OrderDetails : ISerializable
    {
        private Product product;
        private decimal quantity = 0;

        public Product Product { get { return product; } set { product = value; } }

        public string ProductID
        {
            get
            {
                if (Product == null)
                {
                    return "Không xác định";
                }
                return Product.Id;
            }
        }

        public string ProductName
        {
            get
            {
                if (Product == null)
                {
                    return "Không xác định";
                }
                return Product.Name;
            }
        }

        public decimal Quantity { get { return quantity; } set { quantity = value; } }

        public decimal UnitPrice
        {
            get
            {
                if (Product == null)
                {
                    return 0;
                }
                return Product.Price;
            }
        }

        public decimal TotalPrice
        {
            get
            {
                if (Product == null)
                {
                    return 0;
                }
                return UnitPrice * Quantity;
            }
        }

        public OrderDetails() { }

        public OrderDetails(SerializationInfo info, StreamingContext context)
        {
            Product = (Product)info.GetValue("Product", typeof(Product));
            Quantity = info.GetDecimal("Quantity");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Product", Product);
            info.AddValue("Quantity", Quantity);
            info.AddValue("ProductId", ProductID);
            info.AddValue("ProductName", ProductName);
            info.AddValue("UnitPrice", UnitPrice);
            info.AddValue("TotalPrice", TotalPrice);
        }
    }
}
