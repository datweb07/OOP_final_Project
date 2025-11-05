<<<<<<< HEAD
using OOP_finalProject.Base;
using OOP_finalProject.Strategies;
using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
=======
﻿using OOP_finalProject.Base;
using System;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7

namespace OOP_finalProject.Customers
{
    [Serializable]
<<<<<<< HEAD
    public class RegularCustomer : Customer, ISerializable
    {
        public RegularCustomer()
        {
            // set strategy cho Regular Customer
            SetDiscountStrategy(new RegularCustomerDiscountStrategy());
        }

        public RegularCustomer(string id, string name, string gender, string phoneNumber, string address)
            : base(id, name, gender, phoneNumber, address)
        {
            // set strategy cho Regular Customer
            SetDiscountStrategy(new RegularCustomerDiscountStrategy());
        }

        public override string CustomerType
        {
            get { return "Khách hàng thường"; }
        }

        public RegularCustomer(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            SetDiscountStrategy(new RegularCustomerDiscountStrategy());
        }
    }

    ///// <summary>
    ///// Regular Customer - Giảm giá 10%
    ///// </summary>
    //[Serializable]
    //public class RegularCustomer : Customer
    //{
    //    private const decimal DISCOUNT_RATE = 0.1m; // 10%

    //    public RegularCustomer() : base()
    //    {
    //        // ✅ Set CustomerType khi tạo object
    //        CustomerType = "Thường";
    //    }

    //    public RegularCustomer(string id, string name, string gender, string phoneNumber, string address)
    //        : base(id, name, gender, phoneNumber, address)
    //    {
    //        // ✅ Set CustomerType
    //        CustomerType = "Thường";

    //        // Set default discount strategy
    //        SetDiscountStrategy(new RegularCustomerDiscountStrategy());
    //    }

    //    // ✅ Constructor deserialization
    //    protected RegularCustomer(SerializationInfo info, StreamingContext context)
    //        : base(info, context)
    //    {
    //        // ✅ Đảm bảo CustomerType là Thường
    //        CustomerType = "Thường";
    //    }

    //    // Override methods nếu cần
    //    public override string GetDiscountInfo()
    //    {
    //        return $"Khách thường: Giảm {DISCOUNT_RATE * 100}%";
    //    }

    //    public override string ToString()
    //    {
    //        return $"[Regular] {Name} - {Id}";
    //    }
    //}
=======
    public class RegularCustomer : Customer
    {
        public RegularCustomer(string id, string name, string gender, string phoneNumber, string address) : base(id, name, gender, phoneNumber, address)
        {
        }
    }
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
}
