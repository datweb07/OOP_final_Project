using OOP_finalProject.Base;
using System;
using System.Runtime.Serialization;

namespace OOP_finalProject.Customers
{
    [DataContract]
    public class RegularCustomer : Customer
    {
        public RegularCustomer() { }
        public RegularCustomer(string id, string name, string gender, string phoneNumber, string address) : base(id, name, gender, phoneNumber, address)
        {
        }
    }
}
