using OOP_finalProject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOP_finalProject
{
    [Serializable]
    //[KnownType(typeof(Customer))]
    public class CustomerList : ISerializable
    {
        private List<Customer> customers = new List<Customer>();
        //[DataMember]
        public List<Customer> Customers { get { return customers; } set { customers = value; } }
        public CustomerList()
        {
        }
        public CustomerList(List<Customer> customers)
        {
            Customers = customers;
        }
        public CustomerList(SerializationInfo info, StreamingContext context)
        {
            Customers = (List<Customer>)info.GetValue("Customers", typeof(List<Customer>));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Customers", Customers);
        }
        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }
    }
}
