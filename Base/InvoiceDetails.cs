<<<<<<< HEAD
﻿//using System;
//using System.Runtime.Serialization;

//namespace OOP_finalProject
//{
//    [Serializable]
//    public class InvoiceDetails : ISerializable
//    {
//        private string productId;
//        private string productName;
//        private decimal quantity = 0;
//        private decimal unitPrice = 0;
//        public string ProductID { get { return productId; } set { productId = value; } }
//        public string ProductName { get { return productName; } set { productName = value; } }
//        public decimal Quantity { get { return quantity; } set { quantity = value; } }
//        public decimal UnitPrice { get { return unitPrice; } set { unitPrice = value; } }
//        public decimal TotalPrice
//        {
//            get
//            {
//                return UnitPrice * Quantity;
//            }
//            set
//            {
//                // empty setter for serialization compatibility
//            }
//        }

//        public InvoiceDetails()
//        {
//        }

//        public InvoiceDetails(SerializationInfo info, StreamingContext context)
//        {
//            ProductID = info.GetString("ProductID");
//            ProductName = info.GetString("ProductName");
//            Quantity = info.GetDecimal("Quantity");
//            UnitPrice = info.GetDecimal("UnitPrice");
//        }

//        public void GetObjectData(SerializationInfo info, StreamingContext context)
//        {
//            info.AddValue("ProductID", ProductID);
//            info.AddValue("ProductName", ProductName);
//            info.AddValue("Quantity", Quantity);
//            info.AddValue("UnitPrice", UnitPrice);
//            info.AddValue("TotalPrice", TotalPrice);
//        }
//    }
//}

using System;
=======
﻿using System;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    [Serializable]
<<<<<<< HEAD

=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
    public class InvoiceDetails : ISerializable
    {
        private string productId;
        private string productName;
        private decimal quantity = 0;
        private decimal unitPrice = 0;
<<<<<<< HEAD


        public string ProductID
        {
            get { return productId; }
            set { productId = value ?? "UNKNOWN"; }
        }


        public string ProductName
        {
            get { return productName; }
            set { productName = value ?? "Sản phẩm không xác định"; }
        }


        public decimal Quantity
        {
            get { return quantity; }
            set { quantity = value >= 0 ? value : 0; }
        }


        public decimal UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value >= 0 ? value : 0; }
        }

=======
        public string ProductID { get { return productId; } set { productId = value; } }
        public string ProductName { get { return productName; } set { productName = value; } }
        public decimal Quantity { get { return quantity; } set { quantity = value; } }
        public decimal UnitPrice { get { return unitPrice; } set { unitPrice = value; } }
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        public decimal TotalPrice
        {
            get
            {
                return UnitPrice * Quantity;
            }
<<<<<<< HEAD
            set { }
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        }

        public InvoiceDetails()
        {
<<<<<<< HEAD
            ProductID = "UNKNOWN";
            ProductName = "Sản phẩm không xác định";
            Quantity = 0;
            UnitPrice = 0;
        }

        public InvoiceDetails(string productId, string productName, decimal quantity, decimal unitPrice)
        {
            ProductID = productId;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        }

        public InvoiceDetails(SerializationInfo info, StreamingContext context)
        {
<<<<<<< HEAD
            try { ProductID = info.GetString("ProductID") ?? "UNKNOWN"; }
            catch { ProductID = "UNKNOWN"; }

            try { ProductName = info.GetString("ProductName") ?? "Sản phẩm không xác định"; }
            catch { ProductName = "Sản phẩm không xác định"; }

            try { Quantity = info.GetDecimal("Quantity"); }
            catch { Quantity = 0; }

            try { UnitPrice = info.GetDecimal("UnitPrice"); }
            catch { UnitPrice = 0; }
=======
            ProductID = info.GetString("ProductID");
            ProductName = info.GetString("ProductName");
            Quantity = info.GetDecimal("Quantity");
            UnitPrice = info.GetDecimal("UnitPrice");
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ProductID", ProductID);
            info.AddValue("ProductName", ProductName);
            info.AddValue("Quantity", Quantity);
            info.AddValue("UnitPrice", UnitPrice);
            info.AddValue("TotalPrice", TotalPrice);
        }
<<<<<<< HEAD

        // Method để validate invoice detail
        public bool IsValid()
        {
            return !string.IsNullOrEmpty(ProductID) &&
                   !string.IsNullOrEmpty(ProductName) &&
                   Quantity > 0 &&
                   UnitPrice >= 0;
        }

        // Method để tạo string hiển thị
        public string GetDisplayText()
        {
            return $"{ProductName} (x{Quantity}) - {TotalPrice:N0} đ";
        }

        // Override ToString để debug
        public override string ToString()
        {
            return $"InvoiceDetail: {ProductID} - {ProductName} - {Quantity} x {UnitPrice:N0} = {TotalPrice:N0}";
        }

        // Method để so sánh hai invoice details
        public override bool Equals(object obj)
        {
            if (obj is InvoiceDetails other)
            {
                return ProductID == other.ProductID &&
                       ProductName == other.ProductName;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (ProductID + ProductName).GetHashCode();
        }

        // Method để clone invoice detail
        public InvoiceDetails Clone()
        {
            return new InvoiceDetails
            {
                ProductID = this.ProductID,
                ProductName = this.ProductName,
                Quantity = this.Quantity,
                UnitPrice = this.UnitPrice
            };
        }
    }
}
=======
    }
}
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
