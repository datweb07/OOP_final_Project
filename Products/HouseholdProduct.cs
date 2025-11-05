using OOP_finalProject.Base;
using System;
<<<<<<< HEAD
using System.Runtime.Serialization;
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7

namespace OOP_finalProject.Products
{
    [Serializable]
<<<<<<< HEAD
    public class HouseholdProduct : Product, ISerializable
    {
        private string brand;
        public string Brand { get { return brand; } set { brand = value; } }

        public HouseholdProduct(string id, string name, decimal price, decimal quantity, string brand) 
            : base(id, name, price, quantity)
=======
    public class HouseholdProduct : Product
    {
        private string brand;
        public string Brand { get { return brand; } set { brand = value; } }
        public HouseholdProduct(string id, string name, decimal price, decimal quantity, string brand) : base(id, name, price, quantity)
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        {
            Brand = brand;
        }

        public override string Info()
        {
            return $"Thương hiệu: {Brand}";
        }
<<<<<<< HEAD

        // Constructor cho deserialization
        protected HouseholdProduct(SerializationInfo info, StreamingContext context)
           : base(info, context)
        {
            try
            {
                Brand = info.GetString("Brand");
            }
            catch (SerializationException)
            {
                // Nếu file cũ không có trường Brand, set giá trị mặc định
                Brand = "Unknown";
            }
        }

        // Phương thức serialization - QUAN TRỌNG: Phải override và implement ISerializable
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Brand", Brand);
        }
    }
}
=======
    }
}
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
