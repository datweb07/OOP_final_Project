using OOP_finalProject.Base;
using System;

namespace OOP_finalProject.Products
{
    [Serializable]
    public class DrinkProduct : Product
    {
        private bool carbonated;
        public bool Carbonated { get { return carbonated; } set { carbonated = value; } }
        public DrinkProduct(string id, string name, decimal price, decimal quantity, bool carbonated) : base(id, name, price, quantity)
        {
            Carbonated = carbonated;
        }
        public override string Info()
        {
            return $"Có gas: {Carbonated}";
        }
    }
}
