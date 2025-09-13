using OOP_finalProject.Base;
using System;

namespace OOP_finalProject.Products
{
    [Serializable]
    public class HouseholdProduct : Product
    {
        private string brand;
        public string Brand { get { return brand; } set { brand = value; } }
        public HouseholdProduct(string id, string name, decimal price, int quantity, string category, string brand) : base(id, name, price, quantity, category)
        {
            Brand = brand;
        }

        public override string Info()
        {
            return $"Thương hiệu: {Brand}";
        }
    }
}
