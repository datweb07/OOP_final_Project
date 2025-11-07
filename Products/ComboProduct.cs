using OOP_finalProject.Base;
using OOP_finalProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace OOP_finalProject.Products
{
    [Serializable]
    public class ComboProduct : Product, ISerializable
    {
        private List<IProductComponent> children = new List<IProductComponent>();
        private decimal discountPercentage = 0;
        private string description;
        private bool _isDeserializing = false;

        public ComboProduct() : base()
        {
            Quantity = 1;
        }

        public ComboProduct(string id, string name, decimal discountPercentage = 0, string description = "")
            : base(id, name, 0, 1)
        {
            this.discountPercentage = discountPercentage;
            this.description = description;
            this.Quantity = 1;
        }

        // Constructor cho deserialization
        protected ComboProduct(SerializationInfo info, StreamingContext context)
        {
            _isDeserializing = true;

            try
            {
                // Deserialize các properties cơ bản
                Id = info.GetString("Id");
                Name = info.GetString("Name");
                Quantity = info.GetInt32("Quantity");

                // Deserialize các properties đặc thù của ComboProduct
                children = (List<IProductComponent>)info.GetValue("Children", typeof(List<IProductComponent>));
                discountPercentage = info.GetDecimal("DiscountPercentage");
                description = info.GetString("Description");

                // Đảm bảo giá trị hợp lệ
                if (Quantity < 0) Quantity = 0;
                if (discountPercentage < 0) discountPercentage = 0;
                if (discountPercentage > 100) discountPercentage = 100;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi deserialization ComboProduct: {ex.Message}");
                // Khởi tạo giá trị mặc định nếu có lỗi
                children = new List<IProductComponent>();
                discountPercentage = 0;
                description = "";
                Quantity = 1;
            }
            finally
            {
                _isDeserializing = false;
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

        public override decimal Quantity
        {
            get { return base.Quantity; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Quantity cannot be negative");
                base.Quantity = value;
            }
        }

        /// <summary>
        /// Override Price - Giá combo sau khi giảm
        /// Cho phép set trong quá trình deserialization
        /// </summary>
        public override decimal Price
        {
            get
            {
                if (children != null && children.Count > 0)
                {
                    decimal originalPrice = GetOriginalPrice();
                    decimal discount = originalPrice * (discountPercentage / 100);
                    return originalPrice - discount;
                }
                return 0; // Combo không có sản phẩm thì giá = 0
            }
            set
            {
                // Chỉ cho phép set giá khi đang deserializing
                if (_isDeserializing)
                {
                    // Không làm gì cả, vì giá được tính tự động
                    // Property này chỉ để tránh exception trong deserialization
                }
                else
                {
                    throw new InvalidOperationException("Cannot set price directly for composite product. Price is calculated automatically.");
                }
            }
        }

        public void Add(IProductComponent component)
        {
            if (component == null)
                throw new ArgumentNullException(nameof(component));

            if (component == this)
                throw new InvalidOperationException("Cannot add composite to itself");

            children.Add(component);
        }

        public void Remove(IProductComponent component)
        {
            children.Remove(component);
        }

        public int GetChildCount()
        {
            return children?.Count ?? 0;
        }

        public int ChildCount => children?.Count ?? 0;

        public override bool IsComposite()
        {
            return true;
        }

        public override List<IProductComponent> GetChildren()
        {
            return children?.ToList() ?? new List<IProductComponent>();
        }

        public decimal GetOriginalPrice()
        {
            if (children == null || children.Count == 0)
                return 0;

            decimal total = 0;
            foreach (var child in children)
            {
                total += child.CalculateTotal();
            }
            return total;
        }

        public override decimal CalculateTotal()
        {
            return Price * Quantity;
        }

        public decimal GetInventoryValue()
        {
            return Price * Quantity;
        }

        public override decimal CalculateDiscount(decimal additionalDiscountPercentage)
        {
            if (additionalDiscountPercentage < 0 || additionalDiscountPercentage > 100)
                throw new ArgumentException("Discount percentage must be between 0 and 100");

            return CalculateTotal() * (additionalDiscountPercentage / 100);
        }

        public override string Info()
        {
            string info = $"Combo: {Name}\n";
            info += $"Mã Combo: {Id}\n";
            info += $"Số lượng tồn: {Quantity}\n";
            info += $"Mô tả: {(string.IsNullOrEmpty(description) ? "Không có" : description)}\n";
            info += $"Giảm giá combo: {discountPercentage}%\n";
            info += $"Số sản phẩm trong combo: {GetChildCount()}\n";

            if (children != null && children.Count > 0)
            {
                info += "Danh sách sản phẩm:\n";
                for (int i = 0; i < children.Count; i++)
                {
                    info += $"  {i + 1}. {children[i].GetShortInfo()}\n";
                }
            }

            decimal originalPrice = GetOriginalPrice();
            decimal finalPrice = Price;
            decimal savings = originalPrice - finalPrice;

            info += $"Giá gốc: {originalPrice:N0} đ\n";
            info += $"Giá sau giảm: {finalPrice:N0} đ\n";
            info += $"Tiết kiệm: {savings:N0} đ\n";
            info += $"Tổng giá trị tồn kho: {GetInventoryValue():N0} đ";

            return info;
        }

        public override string GetDisplayInfo()
        {
            return $"[COMBO] {Name} - {GetChildCount()} sản phẩm - SL: {Quantity} - Giảm {discountPercentage}% - Giá: {Price:N0} đ";
        }

        public override string GetShortInfo()
        {
            return $"{Name} (Combo {GetChildCount()} SP) - SL: {Quantity} - {Price:N0} đ";
        }

        public List<Product> GetAllLeafProducts()
        {
            List<Product> leafProducts = new List<Product>();

            if (children == null) return leafProducts;

            foreach (var child in children)
            {
                if (child.IsComposite())
                {
                    ComboProduct composite = child as ComboProduct;
                    if (composite != null)
                    {
                        leafProducts.AddRange(composite.GetAllLeafProducts());
                    }
                }
                else
                {
                    Product product = child as Product;
                    if (product != null)
                    {
                        leafProducts.Add(product);
                    }
                }
            }

            return leafProducts;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            try
            {
                info.AddValue("Id", Id);
                info.AddValue("Name", Name);
                info.AddValue("Quantity", Quantity);
                info.AddValue("Children", children);
                info.AddValue("DiscountPercentage", discountPercentage);
                info.AddValue("Description", description);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi serialization ComboProduct: {ex.Message}");
                throw;
            }
        }
    }
}