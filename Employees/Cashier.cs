using OOP_finalProject.Base;
using System;
using System.Runtime.Serialization;

namespace OOP_finalProject.Employees
{
    //[Serializable]
    //public class Cashier : Employee, ISerializable
    //{
    //    public Cashier(string id, string name, string gender, string phoneNumber, string address) : base(id, name, gender, phoneNumber, address)
    //    {
    //    }
    //    public Cashier()
    //    {
    //    }
    //}

    //[Serializable]
    //[DataContract]
    //public class Cashier : Employee, ISerializable
    //{
    //    public Cashier() { }  // ← QUAN TRỌNG

    //    public Cashier(string id, string name, string gender, string phoneNumber, string address)
    //        : base(id, name, gender, phoneNumber, address)
    //    {
    //    }

    //    protected Cashier(SerializationInfo info, StreamingContext context)
    //        : base(info, context)
    //    {
    //    }

    //    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    //    {
    //        base.GetObjectData(info, context);
    //    }
    //}

    [Serializable]
    public class Cashier : Employee, ISerializable
    {
        private string managerName;

        public string ManagerName
        {
            get { return managerName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tên quản lý không thể để trống!");
                managerName = value;
            }
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
