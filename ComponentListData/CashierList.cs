using OOP_finalProject.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOP_finalProject
{
    [Serializable]
    public class CashierList : ISerializable
    {
        private List<Cashier> cashiers = new List<Cashier>();
        public List<Cashier> Cashiers { get { return cashiers; } set { cashiers = value; } }
        public CashierList()
        {
        }
        public CashierList(List<Cashier> cashiers)
        {
            Cashiers = cashiers;
        }
        public CashierList(SerializationInfo info, StreamingContext context)
        {
            Cashiers = (List<Cashier>)info.GetValue("Cashiers", typeof(List<Cashier>));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Cashiers", Cashiers);
        }
        public void AddCashier(Cashier cashier)
        {
            cashiers.Add(cashier);
        }
    }
}
