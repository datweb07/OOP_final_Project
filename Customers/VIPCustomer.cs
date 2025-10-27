using OOP_finalProject.Base;
using OOP_finalProject.Strategies;
using System;

namespace OOP_finalProject.Customers
{
    /// <summary>
    /// VIP Customer - Khách hàng VIP
    /// Tự động áp dụng VIPCustomerDiscountStrategy (30% discount)
    /// </summary>
    [Serializable]
    public class VIPCustomer : Customer
    {
        public VIPCustomer() 
        {
            // Tự động set strategy cho VIP Customer
            SetDiscountStrategy(new VIPCustomerDiscountStrategy());
        }

        public VIPCustomer(string id, string name, string gender, string phoneNumber, string address) 
            : base(id, name, gender, phoneNumber, address)
        {
            // Tự động set strategy cho VIP Customer
            SetDiscountStrategy(new VIPCustomerDiscountStrategy());
        }
    }
}
