using OOP_finalProject.Interfaces;
using System;

namespace OOP_finalProject.Strategies
{
    // Khách hàng VIP thì giảm giá 30% trên tổng giá trị đơn hàng
    public class VIPCustomerDiscountStrategy : IDiscountStrategy
    {
        private const decimal discountPercentage = 30m;

        // tính số tiền giảm giá (30%) dựa trên tổng giá trị đơn hàng
        public decimal CalculateDiscount(decimal totalAmount)
        {
            if (totalAmount < 0)
            {
                throw new ArgumentException("Tổng giá trị đơn hàng không thể âm", nameof(totalAmount));
            }

            return totalAmount * (discountPercentage / 100);
        }

        // lấy phần trăm giảm giá
        public decimal GetDiscountPercentage()
        {
            return discountPercentage;
        }

        // lấy tên chiến lược
        public string GetStrategyName()
        {
            return "VIP Customer Discount";
        }

        // lấy mô tả
        public string GetDescription()
        {
            return $"Khách hàng VIP được giảm giá {discountPercentage}% trên tổng giá trị đơn hàng";
        }

        // ghi đè phương thức ToString để hiển thị thông tin chiến lược giảm giá
        public override string ToString()
        {
            return $"{GetStrategyName()} - {discountPercentage}%";
        }
    }
}
