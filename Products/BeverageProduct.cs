using OOP_finalProject.Base;
using System;

namespace OOP_finalProject.Products
{
    [Serializable]
    public class BeverageProduct : Product
    {
        private bool carbonated;
        public bool Carbonated { get { return carbonated; } set { carbonated = value; } }
        public BeverageProduct(string id, string name, decimal price, int quantity, string category, bool carbonated) : base(id, name, price, quantity, category)
        {
            Carbonated = carbonated;
        }
        public override string Info()
        {
            return $"Có ga: {Carbonated}";
        }
    }
}
