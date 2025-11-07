using OOP_finalProject.Base;
using OOP_finalProject.Strategies;
using System;
using System.Runtime.Serialization;

namespace OOP_finalProject.Customers
{
    [Serializable]
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
}
