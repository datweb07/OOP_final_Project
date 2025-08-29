using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_finalProject.Base
{
    [Serializable]
    public abstract class Product
    {
        private string id;
        private string name;
        private decimal price;
        private int quantity;
        private string category;

        public string Id { get { return id; } set { id = value; } }

        public string Name { get { return name; } set { name = value; } }

        public decimal Price { get { return price; } set { price = value; } }

        public int Quantity { get { return quantity; } set { quantity = value; } }

        public string Category { get { return category; } set { category = value; } }

        public Product(string id, string name, decimal price, int quantity, string category)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
            Category = category;
        }
    }

}
