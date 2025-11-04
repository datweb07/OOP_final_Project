using OOP_finalProject.Base;
using OOP_finalProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OOP_finalProject.Products
{
    /// <summary>
    /// CompositeProduct - Composite Pattern
    /// Đại diện cho một nhóm sản phẩm (combo/bundle)
    /// Có thể chứa nhiều sản phẩm đơn lẻ hoặc composite khác
    /// </summary>
    [Serializable]
    public class ComboProduct : Product, ISerializable
    {
        private List<IProductComponent> children = new List<IProductComponent>();

        private decimal discountPercentage = 0; // Giảm giá cho combo

        private string description; // Mô tả combo

        public ComboProduct() : base()
        {
        }

        public ComboProduct(string id, string name, decimal discountPercentage = 0, string description = "")
            : base(id, name, 0, 1) // Price sẽ được tính tự động, Quantity mặc định là 1
        {
            this.discountPercentage = discountPercentage;
            this.description = description;
        }

        public ComboProduct(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            try
            {
                children = (List<IProductComponent>)info.GetValue("Children", typeof(List<IProductComponent>));
                discountPercentage = info.GetDecimal("DiscountPercentage");
                description = info.GetString("Description");
            }
            catch
            {
                children = new List<IProductComponent>();
                discountPercentage = 0;
                description = "";
            }
        }

        public decimal DiscountPercentage
        {
            get { return discountPercentage; }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException("Discount percentage must be between 0 and 100");
                discountPercentage = value;
            }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// Thêm sản phẩm vào combo
        /// </summary>
        public void Add(IProductComponent component)
        {
            if (component == null)
                throw new ArgumentNullException(nameof(component));

            // Kiểm tra không thêm chính nó vào
            if (component == this)
                throw new InvalidOperationException("Cannot add composite to itself");

            children.Add(component);
        }

        /// <summary>
        /// Xóa sản phẩm khỏi combo
        /// </summary>
        public void Remove(IProductComponent component)
        {
            children.Remove(component);
        }

        /// <summary>
        /// Xóa sản phẩm theo ID
        /// </summary>
        public void RemoveById(string productId)
        {
            children.RemoveAll(c => c.Id == productId);
        }

        /// <summary>
        /// Lấy sản phẩm con theo index
        /// </summary>
        public IProductComponent GetChild(int index)
        {
            if (index < 0 || index >= children.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            return children[index];
        }

        /// <summary>
        /// Đếm số lượng sản phẩm con
        /// </summary>
        public int GetChildCount()
        {
            return children.Count;
        }

        /// <summary>
        /// Override IsComposite - trả về true
        /// </summary>
        public override bool IsComposite()
        {
            return true;
        }

        /// <summary>
        /// Override GetChildren - trả về danh sách con
        /// </summary>
        public override List<IProductComponent> GetChildren()
        {
            return new List<IProductComponent>(children);
        }

        /// <summary>
        /// Tính tổng giá gốc của combo (tổng giá các sản phẩm con)
        /// </summary>
        public decimal GetOriginalPrice()
        {
            decimal total = 0;
            foreach (var child in children)
            {
                total += child.CalculateTotal();
            }
            return total;
        }

        /// <summary>
        /// Override Price - Giá combo sau khi giảm
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal originalPrice = GetOriginalPrice();
                decimal discount = originalPrice * (discountPercentage / 100);
                return originalPrice - discount;
            }
            set
            {
                // Không cho phép set giá trực tiếp cho composite
                // Giá được tính tự động từ các sản phẩm con
            }
        }

        /// <summary>
        /// Override CalculateTotal - Tính tổng giá trị combo
        /// </summary>
        public override decimal CalculateTotal()
        {
            return Price * Quantity;
        }

        /// <summary>
        /// Override CalculateDiscount
        /// </summary>
        public override decimal CalculateDiscount(decimal additionalDiscountPercentage)
        {
            if (additionalDiscountPercentage < 0 || additionalDiscountPercentage > 100)
                throw new ArgumentException("Discount percentage must be between 0 and 100");

            return CalculateTotal() * (additionalDiscountPercentage / 100);
        }

        /// <summary>
        /// Override Info - Thông tin chi tiết về combo
        /// </summary>
        public override string Info()
        {
            string info = $"Combo: {Name}\n";
            info += $"Mô tả: {(string.IsNullOrEmpty(description) ? "Không có" : description)}\n";
            info += $"Giảm giá combo: {discountPercentage}%\n";
            info += $"Số sản phẩm trong combo: {children.Count}\n";
            info += "Danh sách sản phẩm:\n";

            for (int i = 0; i < children.Count; i++)
            {
                info += $"  {i + 1}. {children[i].GetShortInfo()}\n";
            }

            info += $"Giá gốc: {GetOriginalPrice():C}\n";
            info += $"Giá sau giảm: {Price:C}";

            return info;
        }

        /// <summary>
        /// Override GetDisplayInfo
        /// </summary>
        public override string GetDisplayInfo()
        {
            return $"[COMBO] {Name} - {children.Count} sản phẩm - Giảm {discountPercentage}% - Giá: {Price:C}";
        }

        /// <summary>
        /// Override GetShortInfo
        /// </summary>
        public override string GetShortInfo()
        {
            return $"{Name} (Combo {children.Count} SP) - {Price:C}";
        }

        /// <summary>
        /// Lấy danh sách tất cả sản phẩm đơn lẻ trong combo (bao gồm cả nested)
        /// </summary>
        public List<Product> GetAllLeafProducts()
        {
            List<Product> leafProducts = new List<Product>();

            foreach (var child in children)
            {
                if (child.IsComposite())
                {
                    // Nếu là composite, đệ quy lấy các leaf
                    ComboProduct composite = child as ComboProduct;
                    if (composite != null)
                    {
                        leafProducts.AddRange(composite.GetAllLeafProducts());
                    }
                }
                else
                {
                    // Nếu là leaf, thêm vào danh sách
                    Product product = child as Product;
                    if (product != null)
                    {
                        leafProducts.Add(product);
                    }
                }
            }

            return leafProducts;
        }

        /// <summary>
        /// Override GetObjectData cho serialization
        /// </summary>
        public new void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Children", children);
            info.AddValue("DiscountPercentage", discountPercentage);
            info.AddValue("Description", description);
        }
    }
}
