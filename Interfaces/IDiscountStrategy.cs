namespace OOP_finalProject.Interfaces
{
    public interface IDiscountStrategy
    {
        // tính số tiền giảm giá dựa trên tổng giá trị đơn hàng
        decimal CalculateDiscount(decimal totalAmount);

        // lấy phần trăm giảm giá
        decimal GetDiscountPercentage();

        // lấy tên chiến lược giảm giá
        string GetStrategyName();

        // lấy mô tả chiến lược giảm giá
        string GetDescription();
    }
}
