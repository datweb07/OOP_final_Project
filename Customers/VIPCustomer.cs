using OOP_finalProject.Base;
using System;

namespace OOP_finalProject.Customers
{
    [Serializable]
    public class VIPCustomer : Customer
    {
        public VIPCustomer(string id, string name, string email, string phoneNumber, string address, string type) : base(id, name, email, phoneNumber, address, type)
        {
        }
    }
}
