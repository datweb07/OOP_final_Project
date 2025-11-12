using System;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    [Serializable]
    public class InvoiceDetails : ISerializable
    {
        private string productId;
        private string productName;
        private decimal quantity = 0;
        private decimal unitPrice = 0;

        public string ProductID {
            get { return productId; }
            set { 
                productId = value ?? "Mã sản phẩm không xác định"; 
            }
        }

        public string ProductName {
            get { return productName; }
            set { 
                productName = value ?? "Tên sản phẩm không xác định"; 
            }
        }

        public decimal Quantity {
            get { return quantity; }
            set { 
                quantity = value >= 0 ? value : 0; 
            }
        }

        public decimal UnitPrice {
            get { return unitPrice; }
            set { 
                unitPrice = value >= 0 ? value : 0; 
            }
        }

        public decimal TotalPrice {
            get { return UnitPrice * Quantity; }
            set { }
        }

        public InvoiceDetails() {
            ProductID = "Mã sản phẩm không xác định";
            ProductName = "Tên sản phẩm không xác định";
            Quantity = 0;
            UnitPrice = 0;
        }

        public InvoiceDetails(string productId, string productName, decimal quantity, decimal unitPrice) {
            ProductID = productId;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public InvoiceDetails(SerializationInfo info, StreamingContext context) {
            try 
            { 
                ProductID = info.GetString("ProductID") ?? "Mã sản phẩm không xác định"; 
            }
            catch 
            { 
                ProductID = "Mã sản phẩm không xác định"; 
            }

            try 
            { 
                ProductName = info.GetString("ProductName") ?? "Tên sản phẩm không xác định"; 
            }
            catch 
            { 
                ProductName = "Tên sản phẩm không xác định"; 
            }

            try 
            { 
                Quantity = info.GetDecimal("Quantity"); 
            }
            catch 
            { 
                Quantity = 0; 
            }

            try 
            {
                UnitPrice = info.GetDecimal("UnitPrice"); 
            }
            catch
            { 
                UnitPrice = 0;
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context) {
            info.AddValue("ProductID", ProductID);
            info.AddValue("ProductName", ProductName);
            info.AddValue("Quantity", Quantity);
            info.AddValue("UnitPrice", UnitPrice);
            info.AddValue("TotalPrice", TotalPrice);
        }
    }
}