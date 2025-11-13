using OOP_finalProject.Base;
using System;
using System.Runtime.Serialization;

namespace OOP_finalProject.Products
{
    [Serializable]
    public class HouseholdProduct : Product, ISerializable
    {
        private string brand;
        public string Brand { get { return brand; } set { brand = value; } }

        public HouseholdProduct(string id, string name, decimal price, decimal quantity, string brand) 
            : base(id, name, price, quantity)
        {
            Brand = brand;
        }

        public override string Info()
        {
            return $"Thương hiệu: {Brand}";
        }

        protected HouseholdProduct(SerializationInfo info, StreamingContext context)
           : base(info, context)
        {
            try
            {
                Brand = info.GetString("Brand");
            }
            catch (SerializationException)
            {
                // set giá trị mặc định
                Brand = "Unknown";
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Brand", Brand);
        }
    }
}