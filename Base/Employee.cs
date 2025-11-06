using System;
using System.Runtime.Serialization;
using OOP_finalProject.Interfaces;

namespace OOP_finalProject.Base
{
    [Serializable]
    public class Employee : IAuthenticatable, ISerializable
    {
        private string id;
        private string name;
        private string gender;
        private string phoneNumber;
        private string address;
        private string role;
        private DateTime hireDate;
        public string Id
        {
            get { return id; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ID nhân viên không được để trống hoặc rỗng!");
                id = value;
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tên nhân viên không được để trống hoặc rỗng!");
                name = value;
            }
        }
        public string Gender
        {
            get { return gender; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Giới tính nhân viên không được để trống hoặc rỗng!");
                gender = value;
            }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Số điện thoại nhân viên không được để trống hoặc rỗng!");
                phoneNumber = value;
            }
        }
        public string Address
        {
            get { return address; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Địa chỉ không được để trống hoặc rỗng!");
                address = value;
            }
        }
        public string Role
        {
            get { return role; }
            set { role = value; }
        }
        public DateTime HireDate
        {
            get { return hireDate; }
            private set { hireDate = value; }
        }
        public int DaysWorked
        {
            get { return (DateTime.Today - HireDate.Date).Days; }
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
        public Employee(SerializationInfo info, StreamingContext context)
        {
            Id = info.GetString("Id");
            Name = info.GetString("Name");
            Gender = info.GetString("Gender");
            PhoneNumber = info.GetString("PhoneNumber");
            Address = info.GetString("Address");
            Role = info.GetString("Role");
            HireDate = info.GetDateTime("HireDate");
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("Name", Name);
            info.AddValue("Gender", Gender);
            info.AddValue("PhoneNumber", PhoneNumber);
            info.AddValue("Address", Address);
            info.AddValue("Role", Role);
            info.AddValue("HireDate", HireDate);
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
