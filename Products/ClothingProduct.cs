using OOP_finalProject.Base;
using System;

namespace OOP_finalProject.Products
{
    [Serializable]
    public class ClothingProduct : Product
    {
        private string size;
        public string Size { get { return size; } set { size = value; } }
        public ClothingProduct(string id, string name, decimal price, decimal quantity, string size) : base(id, name, price, quantity)
        {
            Size = size;
        }
        public override string Info()
        {
            return $"Kích cỡ: {Size}";
        }
    }
}
