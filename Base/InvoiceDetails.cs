using System.Runtime.Serialization;

namespace OOP_finalProject
{
    public class InvoiceDetails : ISerializable
    {
        private string productId;
        private string productName;
        private decimal quantity = 0;
        private decimal unitPrice = 0;
        public string ProductID { get { return productId; } set { productId = value; } }
        public string ProductName { get { return productName; } set { productName = value; } }
        public decimal Quantity { get { return quantity; } set { quantity = value; } }
        public decimal UnitPrice { get { return unitPrice; } set { unitPrice = value; } }
        public decimal TotalPrice
        {
            get
            {
                return UnitPrice * Quantity;
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
