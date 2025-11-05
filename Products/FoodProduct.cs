<<<<<<< HEAD
using OOP_finalProject.Base;
using System;
using System.Runtime.Serialization;

namespace OOP_finalProject.Products
{
    [Serializable]
    public class FoodProduct : Product, ISerializable
=======
﻿using OOP_finalProject.Base;
using System;

namespace OOP_finalProject.Products
{

    [Serializable]
    public class FoodProduct : Product
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
    {
        private DateTime expirationDate;
        public DateTime ExpirationDate { get { return expirationDate; } set { expirationDate = value; } }
        public FoodProduct(string id, string name, decimal price, decimal quantity, DateTime expirationDate) : base(id, name, price, quantity)
        {
            ExpirationDate = expirationDate;
        }

        public override string Info()
        {
<<<<<<< HEAD
            return $"Ngày hết hạn: {ExpirationDate.ToString("dd/MM/yyyy HH:mm")}";
        }
        protected FoodProduct(SerializationInfo info, StreamingContext context)
           : base(info, context)
        {
            try
            {
                ExpirationDate = info.GetDateTime("ExpirationDate");
            }
            catch (SerializationException)
            {
                // Nếu file cũ không có trường ExpirationDate, set giá trị mặc định
                ExpirationDate = DateTime.Now.AddDays(30);
            }
        }

        public new void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("ExpirationDate", ExpirationDate);
=======
            return $"Ngày hết hạn: {ExpirationDate.ToShortDateString()}";
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        }
    }
}
