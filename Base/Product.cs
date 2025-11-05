using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using OOP_finalProject.Interfaces;

namespace OOP_finalProject.Base
{
    [Serializable]
    public abstract class Product : ISerializable, IDisplayable, ICalculable, IProductComponent
    {
        private string id;
        private string name;
        private decimal price;
        private decimal quantity;

        public string Id
        {
            get { return id; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ID cannot be null or empty");
                id = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be null or empty");
                name = value;
            }
        }

        public virtual decimal Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Price cannot be negative");
                price = value;
            }
        }

        public virtual decimal Quantity
        {
            get { return quantity; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Quantity cannot be negative");
                quantity = value;
            }
        }

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

        public virtual string GetDisplayInfo()
        {
            return $"ID: {Id}, Name: {Name}, Price: {Price:C}, Quantity: {Quantity}";
        }

        public virtual string GetShortInfo()
        {
            return $"{Name} - {Price:C}";
        }

        public virtual decimal CalculateTotal()
        {
            return Price * Quantity;
        }

        public virtual decimal CalculateDiscount(decimal discountPercentage)
        {
            if (discountPercentage < 0 || discountPercentage > 100)
                throw new ArgumentException("Discount percentage must be between 0 and 100");

            return CalculateTotal() * (discountPercentage / 100);
        }

        public string Display
        {
            get { return Info(); }
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("Name", Name);
            info.AddValue("Price", Price);
            info.AddValue("Quantity", Quantity);
        }

        // Implement IProductComponent methods
        public virtual bool IsComposite()
        {
            return false; // Sản phẩm đơn lẻ không phải composite
        }

        public virtual List<IProductComponent> GetChildren()
        {
            return new List<IProductComponent>(); // Sản phẩm đơn lẻ không có con
        }
    }
}
