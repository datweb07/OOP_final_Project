using OOP_finalProject.Base;
using System;

namespace OOP_finalProject.Products
{
    [Serializable]
    public class ElectronicProduct : Product
    {
        private string warrantyPeriod;

        public string WarrantyPeriod
        {
            get { return warrantyPeriod; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Warranty period cannot be null or empty");
                warrantyPeriod = value;
            }
        }

        public ElectronicProduct(string id, string name, decimal price, int quantity, string warrantyPeriod) : base(id, name, price, quantity)
        {
            WarrantyPeriod = warrantyPeriod;
        }

        public override string Info()
        {
            return $"Thời gian bảo hành: {WarrantyPeriod}";
        }

        public override string GetDisplayInfo()
        {
            return base.GetDisplayInfo() + $", Warranty: {WarrantyPeriod}";
        }

        public override decimal CalculateTotal()
        {
            decimal baseTotal = base.CalculateTotal();
            decimal warrantyCost = Price * 0.05m; 
            return baseTotal + warrantyCost;
        }

        public override decimal CalculateDiscount(decimal discountPercentage)
        {
            if (discountPercentage > 20)
                discountPercentage = 20; 

            return base.CalculateDiscount(discountPercentage);
        }
    }
}
