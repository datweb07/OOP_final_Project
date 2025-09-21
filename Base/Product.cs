using System;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization;

namespace OOP_finalProject.Base
{
    [Serializable]
    public abstract class Product : ISerializable
    {
        private string id;
        private string name;
        private decimal price;
        private decimal quantity;
        //private string category;

        public string Id { get { return id; } set { id = value; } }

        public string Name { get { return name; } set { name = value; } }

        public decimal Price { get { return price; } set { price = value; } }

        public decimal Quantity { get { return quantity; } set { quantity = value; } }

        //public string Category { get { return category; } set { category = value; } }

        //public Product(string id, string name, decimal price, int quantity, string category)
        //{
        //    Id = id;
        //    Name = name;
        //    Price = price;
        //    Quantity = quantity;
        //    Category = category;
        //}

        public Product(string id, string name, decimal price, decimal quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public Product()
        {
        }

        public Product(SerializationInfo info, StreamingContext context)
        {
            Id = info.GetString("Id");
            Name = info.GetString("Name");
            Price = info.GetDecimal("Price");
            Quantity = info.GetDecimal("Quantity");
        }

        public abstract string Info();
        public string Display
        {
            get { return Info(); }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("Name", Name);
            info.AddValue("Price", Price);
            info.AddValue("Quantity", Quantity);
        }


    }

}
