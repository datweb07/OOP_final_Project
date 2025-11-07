using OOP_finalProject.Base;
using OOP_finalProject.Strategies;
using System;
using System.Runtime.Serialization;

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
}
