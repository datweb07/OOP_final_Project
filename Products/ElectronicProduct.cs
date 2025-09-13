using OOP_finalProject.Base;
using System;

namespace OOP_finalProject.Products
{
    [Serializable]
    public class ElectronicProduct : Product
    {
        private string warrantyPeriod;
        public string WarrantyPeriod { get { return warrantyPeriod; } set { warrantyPeriod = value; } }
        public ElectronicProduct(string id, string name, decimal price, int quantity, string category, string warrantyPeriod) : base(id, name, price, quantity, category)
        {
            WarrantyPeriod = warrantyPeriod;
        }
        public override string Info()
        {
            return $"Thời gian bảo hành: {WarrantyPeriod}";
        }
    }
}
