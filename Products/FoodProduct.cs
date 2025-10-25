using OOP_finalProject.Base;
using System;
using System.Runtime.Serialization;

namespace OOP_finalProject.Products
{
    [Serializable]
    public class FoodProduct : Product, ISerializable
    {
        private DateTime expirationDate;
        public DateTime ExpirationDate { get { return expirationDate; } set { expirationDate = value; } }
        public FoodProduct(string id, string name, decimal price, decimal quantity, DateTime expirationDate) : base(id, name, price, quantity)
        {
            ExpirationDate = expirationDate;
        }

        public override string Info()
        {
            return $"Ngày hết hạn: {ExpirationDate.ToShortDateString()}";
        }
        protected FoodProduct(SerializationInfo info, StreamingContext context)
           : base(info, context)
        {
        }
    }
}
