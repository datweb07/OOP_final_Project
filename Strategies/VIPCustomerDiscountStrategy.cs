using OOP_finalProject.Interfaces;
using System;

namespace OOP_finalProject.Strategies
{
    /// <summary>
    /// Concrete Strategy cho khách hàng VIP
    /// Giảm giá 30% trên tổng giá trị đơn hàng
    /// </summary>
    public class VIPCustomerDiscountStrategy : IDiscountStrategy
    {
        private const decimal DISCOUNT_PERCENTAGE = 30m;

        /// <summary>
        /// Tính số tiền giảm giá cho khách hàng VIP (30%)
        /// </summary>
        /// <param name="totalAmount">Tổng giá trị đơn hàng</param>
        /// <returns>Số tiền được giảm</returns>
        public decimal CalculateDiscount(decimal totalAmount)
        {
            if (totalAmount < 0)
            {
                throw new ArgumentException("Tổng giá trị đơn hàng không thể âm", nameof(totalAmount));
            }

            return totalAmount * (DISCOUNT_PERCENTAGE / 100);
        }

        /// <summary>
        /// Lấy phần trăm giảm giá
        /// </summary>
        /// <returns>30%</returns>
        public decimal GetDiscountPercentage()
        {
            return DISCOUNT_PERCENTAGE;
        }

        /// <summary>
        /// Lấy tên chiến lược
        /// </summary>
        /// <returns>Tên chiến lược</returns>
        public string GetStrategyName()
        {
            return "VIP Customer Discount";
        }

        /// <summary>
        /// Lấy mô tả chiến lược
        /// </summary>
        /// <returns>Mô tả chi tiết</returns>
        public string GetDescription()
        {
            return $"Khách hàng VIP được giảm giá {DISCOUNT_PERCENTAGE}% trên tổng giá trị đơn hàng";
        }

        /// <summary>
        /// Override ToString để hiển thị thông tin
        /// </summary>
        public override string ToString()
        {
            return $"{GetStrategyName()} - {DISCOUNT_PERCENTAGE}%";
        }
    }
}
