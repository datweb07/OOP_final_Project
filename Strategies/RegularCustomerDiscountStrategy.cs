using OOP_finalProject.Interfaces;
using System;

namespace OOP_finalProject.Strategies
{
    public class RegularCustomerDiscountStrategy : IDiscountStrategy
    {
        private const decimal discountPercentage = 10m;

        // tính số tiền giảm giá 
        public decimal CalculateDiscount(decimal totalAmount)
        {
            if (totalAmount < 0)
            {
                throw new ArgumentException("Tổng giá trị đơn hàng không thể âm", nameof(totalAmount));
            }

            return totalAmount * (discountPercentage / 100);
        }

        public decimal GetDiscountPercentage()
        {
            return discountPercentage;
        }

        public string GetStrategyName()
        {
            return "Regular Customer Discount";
        }

        public string GetDescription()
        {
            return $"{discountPercentage}% trên tổng giá trị đơn hàng";
        }

        // ghi đè phương thức ToString để hiển thị thông tin chiến lược giảm giá
        public override string ToString()
        {
            return $"{GetStrategyName()} - {discountPercentage}%";
        }
    }
}
