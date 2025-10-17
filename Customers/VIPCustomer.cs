using OOP_finalProject.Base;
using System.Runtime.Serialization;

namespace OOP_finalProject.Customers
{
    [DataContract]
    public class VIPCustomer : Customer
    {
        public VIPCustomer() { }
        public VIPCustomer(string id, string name, string gender, string phoneNumber, string address) : base(id, name, gender, phoneNumber, address)
        {
        }
    }
}
