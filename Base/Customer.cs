using OOP_finalProject.Interfaces;
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

        // Strategy Pattern: Discount Strategy
        private IDiscountStrategy discountStrategy;

        public Customer() { }

        public Customer(string id, string name, string gender, string phoneNumber, string address)
        {
            Id = id;
            Name = name;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        /// <summary>
        /// Thiết lập chiến lược giảm giá cho khách hàng
        /// </summary>
        public virtual void SetDiscountStrategy(IDiscountStrategy strategy)
        {
            discountStrategy = strategy;
        }

        /// <summary>
        /// Lấy chiến lược giảm giá hiện tại
        /// </summary>
        public virtual IDiscountStrategy GetDiscountStrategy()
        {
            return discountStrategy;
        }

        /// <summary>
        /// Tính số tiền giảm giá dựa trên strategy
        /// </summary>
        public virtual decimal CalculateDiscount(decimal totalAmount)
        {
            if (discountStrategy == null)
            {
                return 0; // Không có giảm giá nếu chưa set strategy
            }

            return discountStrategy.CalculateDiscount(totalAmount);
        }

        /// <summary>
        /// Lấy phần trăm giảm giá
        /// </summary>
        public virtual decimal GetDiscountPercentage()
        {
            if (discountStrategy == null)
            {
                return 0;
            }

            return discountStrategy.GetDiscountPercentage();
        }

        /// <summary>
        /// Lấy thông tin về loại giảm giá
        /// </summary>
        public virtual string GetDiscountInfo()
        {
            if (discountStrategy == null)
            {
                return "Không có giảm giá";
            }

            return discountStrategy.GetDescription();
        }
    }
}
