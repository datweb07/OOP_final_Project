using OOP_finalProject.Base;
using OOP_finalProject.Interfaces;
using System;
using System.Runtime.Serialization;

namespace OOP_finalProject.Employees
{
    [Serializable]
    public class Cashier : Employee, ISerializable, ISalaryCalculable
    {
        private string managerName;

        public string ManagerName
        {
            get { return managerName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Tên quản lý không thể để trống hoặc rỗng!");
                }
                managerName = value;
            }
        }

        public decimal HourlyRate
        {
            get { return 23000m; }
        }

        public decimal Salary
        {
            get { return DaysWorked * 8 * HourlyRate; }
        }

        public Cashier() { }

        public Cashier(string id, string name, string gender, string phoneNumber, string address) : base(id, name, gender, phoneNumber, address)
        {
            Role = "Cashier";
        }

        public Cashier(string id, string name, string gender, string phoneNumber, string address, string managerName) : base(id, name, gender, phoneNumber, address)
        {
            Role = "Cashier";
            ManagerName = managerName;
        }

        protected Cashier(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            try
            {
                managerName = info.GetString("ManagerName");
            }
            catch
            {
                managerName = "";
            }
        }

        public new void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("ManagerName", managerName);
        }

        public override string GetDisplayInfo()
        {
            return base.GetDisplayInfo() + $", Manager: {ManagerName}";
        }
    }
}
