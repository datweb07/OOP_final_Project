namespace OOP_finalProject.Interfaces
{
    /// <summary>
    /// Strategy Interface cho Discount Pattern
    /// Định nghĩa contract cho các chiến lược giảm giá khác nhau
    /// </summary>
    public interface IDiscountStrategy
    {
        /// <summary>
        /// Tính số tiền giảm giá dựa trên tổng giá trị đơn hàng
        /// </summary>
        /// <param name="totalAmount">Tổng giá trị đơn hàng</param>
        /// <returns>Số tiền được giảm</returns>
        decimal CalculateDiscount(decimal totalAmount);

        /// <summary>
        /// Lấy phần trăm giảm giá
        /// </summary>
        /// <returns>Phần trăm giảm giá (0-100)</returns>
        decimal GetDiscountPercentage();

        /// <summary>
        /// Lấy tên chiến lược giảm giá
        /// </summary>
        /// <returns>Tên chiến lược</returns>
        string GetStrategyName();

        /// <summary>
        /// Lấy mô tả về chiến lược giảm giá
        /// </summary>
        /// <returns>Mô tả chi tiết</returns>
        string GetDescription();
    }
}
