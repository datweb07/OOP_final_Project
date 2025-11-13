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
                // set giá trị mặc định
                ExpirationDate = DateTime.Now.AddDays(30);
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("ExpirationDate", ExpirationDate);
        }
    }
}
