using System;
using System.Runtime.Serialization;
using OOP_finalProject.Interfaces;

namespace OOP_finalProject.Base
{
    [DataContract]
    public class Employee : IAuthenticatable, IDisplayable
    {
        private string id;
        private string name;
        private string gender;
        private string phoneNumber;
        private string address;
        private string role;
        private DateTime hireDate;

        [DataMember]
        public string Id
        {
            get { return id; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Employee ID cannot be null or empty");
                id = value;
            }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Employee name cannot be null or empty");
                name = value;
            }
        }

        [DataMember]
        public string Gender
        {
            get { return gender; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Gender cannot be null or empty");
                gender = value;
            }
        }

        [DataMember]
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Phone number cannot be null or empty");
                phoneNumber = value;
            }
        }

        [DataMember]
        public string Address
        {
            get { return address; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Address cannot be null or empty");
                address = value;
            }
        }

        public string Role
        {
            get { return role; }
            protected set { role = value; }
        }

        public DateTime HireDate
        {
            get { return hireDate; }
            private set { hireDate = value; }
        }


        public Employee()
        {
            HireDate = DateTime.Now;
        }

        public Employee(string id, string name, string gender, string phoneNumber, string address)
        {
            Id = id;
            Name = name;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Address = address;
            HireDate = DateTime.Now;
        }

        public virtual bool ValidateCredentials(string username, string password)
        {
            return !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password);
        }

        public virtual string GetRole()
        {
            return Role ?? "Employee";
        }

        public virtual string GetDisplayInfo()
        {
            return $"Employee: {Name} ({Id}) - {GetRole()}";
        }

        public virtual string GetShortInfo()
        {
            return $"{Name} - {GetRole()}";
        }
    }
}
