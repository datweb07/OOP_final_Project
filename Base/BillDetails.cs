using System;

namespace OOP_finalProject
{
    [Serializable]
    public class BillDetails
    {
        private string productId;
        private string productName;
        private int quantity = 0;
        private decimal unitPrice = 0;
        public string ProductID { get { return productId; } set { productId = value; } }
        public string ProductName { get { return productName; } set { productName = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }
        public decimal UnitPrice { get { return unitPrice; } set { unitPrice = value; } }
        public decimal TotalPrice
        {
            get
            {
                return UnitPrice * Quantity;
            }
        }
    }
}
