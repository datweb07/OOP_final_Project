using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_finalProject.Base
{
    [Serializable]
    public class Customer
    {
        private string id;
        private string name;
        private string email;
        private string phoneNumber;
        private string address;
        private string type;

        public string Id { get { return id; } set { id = value; } }

        public string Name { get { return name; } set { name = value; } }

        public string Email { get { return email; } set { email = value; } }

        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }

        public string Address { get { return address; } set { address = value; } }

        public string Type { get { return type; } set { type = value; } }

        public Customer(string id, string name, string email, string phoneNumber, string address, string type)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            Type = type;
        }
    } 
}
