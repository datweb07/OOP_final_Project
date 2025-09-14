using System;

namespace OOP_finalProject.Base
{
    [Serializable]
    public class Customer
    {
        private string id;
        private string name;
        private string gender;
        private string phoneNumber;
        private string address;
        

        public string Id { get { return id; } set { id = value; } }

        public string Name { get { return name; } set { name = value; } }
        public string Gender { get { return gender; } set { gender = value; } }

        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }

        public string Address { get { return address; } set { address = value; } }

        

        public Customer(string id, string name, string gender, string phoneNumber, string address)
        {
            Id = id;
            Name = name;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Address = address;
            
        }

        public Customer()
        {
        }
    } 
}
