using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_finalProject.Base
{
    [Serializable]
    public class Employee
    {
        private string id;
        private string name;
        private string email;
        private string phoneNumber;
        private string position;

        public string Id { get { return id; } set { id = value; } }

        public string Name { get { return name; } set { name = value; } }

        public string Email { get { return email; } set { email = value; } }

        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }

        public string Position { get { return position; } set { position = value; } }

        public Employee(string id, string name, string email, string phoneNumber, string position)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Position = position;
        }

    }
}
