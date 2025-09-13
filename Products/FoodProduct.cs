using OOP_finalProject.Base;
using System;

namespace OOP_finalProject.Products
{

    [Serializable]
    public class FoodProduct : Product
    {
        private DateTime expirationDate;
        public DateTime ExpirationDate { get { return expirationDate; } set { expirationDate = value; } }
        public FoodProduct(string id, string name, decimal price, int quantity, string category, DateTime expirationDate) : base(id, name, price, quantity, category)
        {
            ExpirationDate = expirationDate;
        }

        public override string Info()
        {
            return $"Ngày hết hạn: {ExpirationDate.ToShortDateString()}";
        }
    }
}
