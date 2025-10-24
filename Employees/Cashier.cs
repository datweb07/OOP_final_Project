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
        public Cashier() { }

        public Cashier(string id, string name, string gender, string phoneNumber, string address) : base(id, name, gender, phoneNumber, address) {
            Role = "Cashier";
        }
        protected Cashier(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
