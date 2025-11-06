using System.Collections.Generic;

namespace OOP_finalProject.Interfaces
{
    public interface IProductComponent
    {
        string Id { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
        decimal Quantity { get; set; }

        // tính tổng tiền cho sản phẩm đơn hoặc combo
        decimal CalculateTotal();

        // tính giảm giá
        decimal CalculateDiscount(decimal discountPercentage);

        // thông tin
        string GetDisplayInfo();

        // thông tin ngắn
        string GetShortInfo();

        // kiểm tra có phải là composite không
        bool IsComposite();

        // lấy ds sản phẩm con (nếu là composite)
        List<IProductComponent> GetChildren();
    }
}
