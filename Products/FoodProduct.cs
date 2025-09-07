using OOP_finalProject.Base;
using System;

namespace OOP_finalProject.Products
{

    [Serializable]
    public class FoodProduct : Product
    {
        public FoodProduct(string id, string name, decimal price, int quantity, string category) : base(id, name, price, quantity, category)
        {
        }
    }
}
