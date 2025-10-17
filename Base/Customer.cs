using System;
using System.Runtime.Serialization;

namespace OOP_finalProject.Base
{
    //[Serializable]
    //public class Customer : ISerializable
    //{
    //    private string id;
    //    private string name;
    //    private string gender;
    //    private string phoneNumber;
    //    private string address;

    //    public string Id { get { return id; } set { id = value; } }

    //    public string Name { get { return name; } set { name = value; } }

    //    public string Gender { get { return gender; } set { gender = value; } }

    //    public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }

    //    public string Address { get { return address; } set { address = value; } }


    //    public Customer(string id, string name, string gender, string phoneNumber, string address)
    //    {
    //        Id = id;
    //        Name = name;
    //        Gender = gender;
    //        PhoneNumber = phoneNumber;
    //        Address = address;

    //    }

    //    public Customer()
    //    {
    //    }

    //    public Customer(SerializationInfo info, StreamingContext context)
    //    {
    //        Id = info.GetString("Id");
    //        Name = info.GetString("Name");
    //        Gender = info.GetString("Gender");
    //        PhoneNumber = info.GetString("PhoneNumber");
    //        Address = info.GetString("Address");
    //    }

    //    public void GetObjectData(SerializationInfo info, StreamingContext context)
    //    {
    //        info.AddValue("Id", Id);
    //        info.AddValue("Name", Name);
    //        info.AddValue("Gender", Gender);
    //        info.AddValue("PhoneNumber", PhoneNumber);
    //        info.AddValue("Address", Address);
    //    }
    //}

    [DataContract]
    public class Customer
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string Address { get; set; }

        public Customer() { }

        public Customer(string id, string name, string gender, string phoneNumber, string address)
        {
            Id = id;
            Name = name;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Address = address;
        }
    }
}
