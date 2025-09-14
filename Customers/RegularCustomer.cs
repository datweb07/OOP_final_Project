using OOP_finalProject.Base;
using System;

namespace OOP_finalProject.Customers
{
    [Serializable]
    public class RegularCustomer : Customer
    {
        public RegularCustomer(string id, string name, string gender, string phoneNumber, string address) : base(id, name, gender, phoneNumber, address)
        {
        }
    }
}
