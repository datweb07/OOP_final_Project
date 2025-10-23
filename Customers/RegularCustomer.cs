using OOP_finalProject.Base;
using OOP_finalProject.Strategies;
using System;
using System.Runtime.Serialization;

namespace OOP_finalProject.Customers
{
    /// <summary>
    /// Regular Customer - Khách hàng thường
    /// Tự động áp dụng RegularCustomerDiscountStrategy (10% discount)
    /// </summary>
    [Serializable]
    public class RegularCustomer : Customer
    {
        public RegularCustomer() 
        {
            // Tự động set strategy cho Regular Customer
            SetDiscountStrategy(new RegularCustomerDiscountStrategy());
        }

        public RegularCustomer(string id, string name, string gender, string phoneNumber, string address) 
            : base(id, name, gender, phoneNumber, address)
        {
            // Tự động set strategy cho Regular Customer
            SetDiscountStrategy(new RegularCustomerDiscountStrategy());
        }
    }
}
