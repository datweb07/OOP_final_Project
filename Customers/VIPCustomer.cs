using OOP_finalProject.Base;
using OOP_finalProject.Interfaces;
using OOP_finalProject.Strategies;
using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace OOP_finalProject.Customers
{
    [Serializable]
    public class VIPCustomer : Customer, ISerializable
    {
        public VIPCustomer()
        {
            // set startegy cho VIP Customer
            SetDiscountStrategy(new VIPCustomerDiscountStrategy());
        }

        public VIPCustomer(string id, string name, string gender, string phoneNumber, string address)
            : base(id, name, gender, phoneNumber, address)
        {
            // set strategy cho VIP Customer
            SetDiscountStrategy(new VIPCustomerDiscountStrategy());
        }

        public override string CustomerType
        {
            get { return "Khách hàng VIP"; }
        }

        public VIPCustomer(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            SetDiscountStrategy(new VIPCustomerDiscountStrategy());
        }
    }

    ///// <summary>
    ///// VIP Customer - Giảm giá 30%
    ///// </summary>
    //[Serializable]
    //public class VIPCustomer : Customer
    //{
    //    private const decimal DISCOUNT_RATE = 0.3m; // 30%

    //    public VIPCustomer() : base()
    //    {
    //        // ✅ Set CustomerType khi tạo object
    //        CustomerType = "VIP";
    //    }

    //    public VIPCustomer(string id, string name, string gender, string phoneNumber, string address)
    //        : base(id, name, gender, phoneNumber, address)
    //    {
    //        // ✅ Set CustomerType
    //        CustomerType = "VIP";

    //        // Set default discount strategy
    //        SetDiscountStrategy(new VIPCustomerDiscountStrategy());
    //    }

    //    // ✅ Constructor deserialization
    //    protected VIPCustomer(SerializationInfo info, StreamingContext context)
    //        : base(info, context)
    //    {
    //        // ✅ Đảm bảo CustomerType là VIP
    //        CustomerType = "VIP";
    //    }

    //    // Override methods nếu cần
    //    public override string GetDiscountInfo()
    //    {
    //        return $"Khách VIP: Giảm {DISCOUNT_RATE * 100}%";
    //    }

    //    public override string ToString()
    //    {
    //        return $"[VIP] {Name} - {Id}";
    //    }
    //}
}
