using OOP_finalProject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_finalProject.Products
{
    [Serializable]
    public class BeverageProduct : Product
    {
        public BeverageProduct(string id, string name, decimal price, int quantity, string category) : base(id, name, price, quantity, category)
        {
        }
    }
}
