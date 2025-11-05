using System.Collections.Generic;

namespace OOP_finalProject.Interfaces
{
    /// <summary>
    /// Interface Component cho Composite Pattern
    /// Định nghĩa các phương thức chung cho cả sản phẩm đơn lẻ và composite
    /// </summary>
    public interface IProductComponent
    {
        string Id { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
        decimal Quantity { get; set; }

        /// <summary>
        /// Tính tổng giá trị (cho sản phẩm đơn hoặc combo)
        /// </summary>
        decimal CalculateTotal();

        /// <summary>
        /// Tính giảm giá
        /// </summary>
        decimal CalculateDiscount(decimal discountPercentage);

        /// <summary>
        /// Lấy thông tin hiển thị
        /// </summary>
        string GetDisplayInfo();

        /// <summary>
        /// Lấy thông tin ngắn gọn
        /// </summary>
        string GetShortInfo();

        /// <summary>
        /// Kiểm tra xem có phải là composite không
        /// </summary>
        bool IsComposite();

        /// <summary>
        /// Lấy danh sách các component con (nếu là composite)
        /// </summary>
        List<IProductComponent> GetChildren();
    }
}
