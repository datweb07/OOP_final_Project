//using OOP_finalProject.Base;
//using OOP_finalProject.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Runtime.Serialization;

//namespace OOP_finalProject.Products
//{
//    /// <summary>
//    /// CompositeProduct - Composite Pattern
//    /// Đại diện cho một nhóm sản phẩm (combo/bundle)
//    /// Có thể chứa nhiều sản phẩm đơn lẻ hoặc composite khác
//    /// </summary>
//    [Serializable]
//    public class ComboProduct : Product, ISerializable
//    {
//        private List<IProductComponent> children = new List<IProductComponent>();

//        private decimal discountPercentage = 0; // Giảm giá cho combo

//        private string description; // Mô tả combo

//        public ComboProduct() : base()
//        {
//        }

//        public ComboProduct(string id, string name, decimal discountPercentage = 0, string description = "")
//            : base(id, name, 0, 1) // Price sẽ được tính tự động, Quantity mặc định là 1
//        {
//            this.discountPercentage = discountPercentage;
//            this.description = description;
//        }

//        public ComboProduct(SerializationInfo info, StreamingContext context)
//            : base(info, context)
//        {
//            try
//            {
//                children = (List<IProductComponent>)info.GetValue("Children", typeof(List<IProductComponent>));
//                discountPercentage = info.GetDecimal("DiscountPercentage");
//                description = info.GetString("Description");
//            }
//            catch
//            {
//                children = new List<IProductComponent>();
//                discountPercentage = 0;
//                description = "";
//            }
//        }

//        public decimal DiscountPercentage
//        {
//            get { return discountPercentage; }
//            set
//            {
//                if (value < 0 || value > 100)
//                    throw new ArgumentException("Discount percentage must be between 0 and 100");
//                discountPercentage = value;
//            }
//        }

//        public string Description
//        {
//            get { return description; }
//            set { description = value; }
//        }

//        /// <summary>
//        /// Thêm sản phẩm vào combo
//        /// </summary>
//        public void Add(IProductComponent component)
//        {
//            if (component == null)
//                throw new ArgumentNullException(nameof(component));

//            // Kiểm tra không thêm chính nó vào
//            if (component == this)
//                throw new InvalidOperationException("Cannot add composite to itself");

//            children.Add(component);
//        }

//        /// <summary>
//        /// Xóa sản phẩm khỏi combo
//        /// </summary>
//        public void Remove(IProductComponent component)
//        {
//            children.Remove(component);
//        }

//        /// <summary>
//        /// Xóa sản phẩm theo ID
//        /// </summary>
//        public void RemoveById(string productId)
//        {
//            children.RemoveAll(c => c.Id == productId);
//        }

//        /// <summary>
//        /// Lấy sản phẩm con theo index
//        /// </summary>
//        public IProductComponent GetChild(int index)
//        {
//            if (index < 0 || index >= children.Count)
//                throw new ArgumentOutOfRangeException(nameof(index));

//            return children[index];
//        }

//        /// <summary>
//        /// Đếm số lượng sản phẩm con
//        /// </summary>
//        public int GetChildCount()
//        {
//            return children.Count;
//        }

//        /// <summary>
//        /// Override IsComposite - trả về true
//        /// </summary>
//        public override bool IsComposite()
//        {
//            return true;
//        }

//        /// <summary>
//        /// Override GetChildren - trả về danh sách con
//        /// </summary>
//        public override List<IProductComponent> GetChildren()
//        {
//            return new List<IProductComponent>(children);
//        }

//        /// <summary>
//        /// Tính tổng giá gốc của combo (tổng giá các sản phẩm con)
//        /// </summary>
//        public decimal GetOriginalPrice()
//        {
//            decimal total = 0;
//            foreach (var child in children)
//            {
//                total += child.CalculateTotal();
//            }
//            return total;
//        }

//        /// <summary>
//        /// Override Price - Giá combo sau khi giảm
//        /// </summary>
//        public override decimal Price
//        {
//            get
//            {
//                decimal originalPrice = GetOriginalPrice();
//                decimal discount = originalPrice * (discountPercentage / 100);
//                return originalPrice - discount;
//            }
//            set
//            {
//                // Không cho phép set giá trực tiếp cho composite
//                // Giá được tính tự động từ các sản phẩm con
//            }
//        }

//        /// <summary>
//        /// Override CalculateTotal - Tính tổng giá trị combo
//        /// </summary>
//        public override decimal CalculateTotal()
//        {
//            return Price * Quantity;
//        }

//        /// <summary>
//        /// Override CalculateDiscount
//        /// </summary>
//        public override decimal CalculateDiscount(decimal additionalDiscountPercentage)
//        {
//            if (additionalDiscountPercentage < 0 || additionalDiscountPercentage > 100)
//                throw new ArgumentException("Discount percentage must be between 0 and 100");

//            return CalculateTotal() * (additionalDiscountPercentage / 100);
//        }

//        /// <summary>
//        /// Override Info - Thông tin chi tiết về combo
//        /// </summary>
//        public override string Info()
//        {
//            string info = $"Combo: {Name}\n";
//            info += $"Mô tả: {(string.IsNullOrEmpty(description) ? "Không có" : description)}\n";
//            info += $"Giảm giá combo: {discountPercentage}%\n";
//            info += $"Số sản phẩm trong combo: {children.Count}\n";
//            info += "Danh sách sản phẩm:\n";

//            for (int i = 0; i < children.Count; i++)
//            {
//                info += $"  {i + 1}. {children[i].GetShortInfo()}\n";
//            }

//            info += $"Giá gốc: {GetOriginalPrice():C}\n";
//            info += $"Giá sau giảm: {Price:C}";

//            return info;
//        }

//        /// <summary>
//        /// Override GetDisplayInfo
//        /// </summary>
//        public override string GetDisplayInfo()
//        {
//            return $"[COMBO] {Name} - {children.Count} sản phẩm - Giảm {discountPercentage}% - Giá: {Price:C}";
//        }

//        /// <summary>
//        /// Override GetShortInfo
//        /// </summary>
//        public override string GetShortInfo()
//        {
//            return $"{Name} (Combo {children.Count} SP) - {Price:C}";
//        }

//        /// <summary>
//        /// Lấy danh sách tất cả sản phẩm đơn lẻ trong combo (bao gồm cả nested)
//        /// </summary>
//        public List<Product> GetAllLeafProducts()
//        {
//            List<Product> leafProducts = new List<Product>();

//            foreach (var child in children)
//            {
//                if (child.IsComposite())
//                {
//                    // Nếu là composite, đệ quy lấy các leaf
//                    ComboProduct composite = child as ComboProduct;
//                    if (composite != null)
//                    {
//                        leafProducts.AddRange(composite.GetAllLeafProducts());
//                    }
//                }
//                else
//                {
//                    // Nếu là leaf, thêm vào danh sách
//                    Product product = child as Product;
//                    if (product != null)
//                    {
//                        leafProducts.Add(product);
//                    }
//                }
//            }

//            return leafProducts;
//        }

//        /// <summary>
//        /// Override GetObjectData cho serialization
//        /// </summary>
//        public new void GetObjectData(SerializationInfo info, StreamingContext context)
//        {
//            base.GetObjectData(info, context);
//            info.AddValue("Children", children);
//            info.AddValue("DiscountPercentage", discountPercentage);
//            info.AddValue("Description", description);
//        }
//    }
//}



//using OOP_finalProject.Base;
//using OOP_finalProject.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Runtime.Serialization;

//namespace OOP_finalProject.Products
//{
//    [Serializable]
//    public class ComboProduct : Product, ISerializable
//    {
//        private List<IProductComponent> children = new List<IProductComponent>();
//        private decimal discountPercentage = 0;
//        private string description;
//        private decimal _price; // Thêm field backup cho price

//        public ComboProduct() : base()
//        {
//            Quantity = 1;
//        }

//        public ComboProduct(string id, string name, decimal discountPercentage = 0, string description = "")
//            : base(id, name, 0, 1)
//        {
//            this.discountPercentage = discountPercentage;
//            this.description = description;
//            this.Quantity = 1;
//        }

//        // Constructor đặc biệt cho deserialization
//        protected ComboProduct(SerializationInfo info, StreamingContext context)
//            : base(info, context)
//        {
//            try
//            {
//                children = (List<IProductComponent>)info.GetValue("Children", typeof(List<IProductComponent>));
//                discountPercentage = info.GetDecimal("DiscountPercentage");
//                description = info.GetString("Description");

//                // Đọc giá trị price từ serialization mà không kích hoạt exception
//                _price = info.GetDecimal("Price");

//                if (Quantity < 0)
//                    Quantity = 0;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Lỗi deserialization ComboProduct: {ex.Message}");
//                children = new List<IProductComponent>();
//                discountPercentage = 0;
//                description = "";
//                Quantity = 1;
//                _price = 0;
//            }
//        }

//        public decimal DiscountPercentage
//        {
//            get { return discountPercentage; }
//            set
//            {
//                if (value < 0 || value > 100)
//                    throw new ArgumentException("Discount percentage must be between 0 and 100");
//                discountPercentage = value;
//            }
//        }

//        public string Description
//        {
//            get { return description; }
//            set { description = value; }
//        }

//        public override decimal Quantity
//        {
//            get { return base.Quantity; }
//            set
//            {
//                if (value < 0)
//                    throw new ArgumentException("Quantity cannot be negative");
//                base.Quantity = value;
//            }
//        }

//        /// <summary>
//        /// Override Price - Giá combo sau khi giảm
//        /// Cho phép set trong nội bộ class để hỗ trợ serialization
//        /// </summary>
//        public override decimal Price
//        {
//            get
//            {
//                // Nếu có children, tính toán giá từ children
//                if (children != null && children.Count > 0)
//                {
//                    decimal originalPrice = GetOriginalPrice();
//                    decimal discount = originalPrice * (discountPercentage / 100);
//                    return originalPrice - discount;
//                }
//                // Nếu không có children, trả về giá đã lưu (cho deserialization)
//                return _price;
//            }
//            set
//            {
//                // Cho phép set trong nội bộ class, nhưng không cho phép từ bên ngoài
//                if (IsSettingPriceAllowed())
//                {
//                    _price = value;
//                }
//                else
//                {
//                    throw new InvalidOperationException("Cannot set price directly for composite product. Price is calculated automatically.");
//                }
//            }
//        }

//        /// <summary>
//        /// Kiểm tra xem có cho phép set price không
//        /// Cho phép trong deserialization và internal operations
//        /// </summary>
//        private bool IsSettingPriceAllowed()
//        {
//            // Cho phép set price khi:
//            // 1. Đang trong quá trình deserialization
//            // 2. Không có children (combo mới tạo)
//            // 3. Internal operations
//            return children == null || children.Count == 0;
//        }

//        public void Add(IProductComponent component)
//        {
//            if (component == null)
//                throw new ArgumentNullException(nameof(component));

//            if (component == this)
//                throw new InvalidOperationException("Cannot add composite to itself");

//            children.Add(component);
//        }

//        public void Remove(IProductComponent component)
//        {
//            children.Remove(component);
//        }

//        public void RemoveById(string productId)
//        {
//            children.RemoveAll(c => c.Id == productId);
//        }

//        public IProductComponent GetChild(int index)
//        {
//            if (index < 0 || index >= children.Count)
//                throw new ArgumentOutOfRangeException(nameof(index));

//            return children[index];
//        }

//        public int GetChildCount()
//        {
//            return children?.Count ?? 0;
//        }

//        public int ChildCount => children?.Count ?? 0;

//        public override bool IsComposite()
//        {
//            return true;
//        }

//        public override List<IProductComponent> GetChildren()
//        {
//            return new List<IProductComponent>(children ?? new List<IProductComponent>());
//        }

//        public decimal GetOriginalPrice()
//        {
//            if (children == null) return 0;

//            decimal total = 0;
//            foreach (var child in children)
//            {
//                total += child.CalculateTotal();
//            }
//            return total;
//        }

//        public override decimal CalculateTotal()
//        {
//            return Price * Quantity;
//        }

//        public decimal GetInventoryValue()
//        {
//            return Price * Quantity;
//        }

//        public override decimal CalculateDiscount(decimal additionalDiscountPercentage)
//        {
//            if (additionalDiscountPercentage < 0 || additionalDiscountPercentage > 100)
//                throw new ArgumentException("Discount percentage must be between 0 and 100");

//            return CalculateTotal() * (additionalDiscountPercentage / 100);
//        }

//        public override string Info()
//        {
//            string info = $"Combo: {Name}\n";
//            info += $"Mã Combo: {Id}\n";
//            info += $"Số lượng tồn: {Quantity}\n";
//            info += $"Mô tả: {(string.IsNullOrEmpty(description) ? "Không có" : description)}\n";
//            info += $"Giảm giá combo: {discountPercentage}%\n";
//            info += $"Số sản phẩm trong combo: {GetChildCount()}\n";

//            if (children != null && children.Count > 0)
//            {
//                info += "Danh sách sản phẩm:\n";
//                for (int i = 0; i < children.Count; i++)
//                {
//                    info += $"  {i + 1}. {children[i].GetShortInfo()}\n";
//                }
//            }

//            decimal originalPrice = GetOriginalPrice();
//            decimal finalPrice = Price;
//            decimal savings = originalPrice - finalPrice;

//            info += $"Giá gốc: {originalPrice:N0} đ\n";
//            info += $"Giá sau giảm: {finalPrice:N0} đ\n";
//            info += $"Tiết kiệm: {savings:N0} đ\n";
//            info += $"Tổng giá trị tồn kho: {GetInventoryValue():N0} đ";

//            return info;
//        }

//        public override string GetDisplayInfo()
//        {
//            return $"[COMBO] {Name} - {GetChildCount()} sản phẩm - SL: {Quantity} - Giảm {discountPercentage}% - Giá: {Price:N0} đ";
//        }

//        public override string GetShortInfo()
//        {
//            return $"{Name} (Combo {GetChildCount()} SP) - SL: {Quantity} - {Price:N0} đ";
//        }

//        public string GetGridInfo()
//        {
//            return $"{Name} ({GetChildCount()} SP) - SL: {Quantity}";
//        }

//        public List<Product> GetAllLeafProducts()
//        {
//            List<Product> leafProducts = new List<Product>();

//            if (children == null) return leafProducts;

//            foreach (var child in children)
//            {
//                if (child.IsComposite())
//                {
//                    ComboProduct composite = child as ComboProduct;
//                    if (composite != null)
//                    {
//                        leafProducts.AddRange(composite.GetAllLeafProducts());
//                    }
//                }
//                else
//                {
//                    Product product = child as Product;
//                    if (product != null)
//                    {
//                        leafProducts.Add(product);
//                    }
//                }
//            }

//            return leafProducts;
//        }

//        public bool CanCreateMore(int requestedQuantity)
//        {
//            if (requestedQuantity <= 0)
//                return false;

//            var leafProducts = GetAllLeafProducts();
//            foreach (var product in leafProducts)
//            {
//                if (product.Quantity < (product.Quantity * requestedQuantity))
//                {
//                    return false;
//                }
//            }
//            return true;
//        }

//        public new void GetObjectData(SerializationInfo info, StreamingContext context)
//        {
//            base.GetObjectData(info, context);
//            info.AddValue("Children", children);
//            info.AddValue("DiscountPercentage", discountPercentage);
//            info.AddValue("Description", description);
//            // Lưu giá tính toán được để phục vụ deserialization
//            info.AddValue("Price", this.Price);
//        }

//        public ComboProduct CloneWithQuantity(int newQuantity)
//        {
//            var cloned = new ComboProduct(this.Id, this.Name, this.discountPercentage, this.description)
//            {
//                Quantity = newQuantity
//            };

//            if (children != null)
//            {
//                foreach (var child in children)
//                {
//                    if (child is Product product)
//                    {
//                        Product clonedProduct = CloneProduct(product);
//                        if (clonedProduct != null)
//                        {
//                            cloned.Add(clonedProduct);
//                        }
//                    }
//                }
//            }

//            return cloned;
//        }

//        private Product CloneProduct(Product original)
//        {
//            if (original is DrinkProduct drink)
//                return new DrinkProduct(drink.Id, drink.Name, drink.Price, drink.Quantity, drink.Carbonated);
//            else if (original is FoodProduct food)
//                return new FoodProduct(food.Id, food.Name, food.Price, food.Quantity, food.ExpirationDate);
//            else if (original is HouseholdProduct household)
//                return new HouseholdProduct(household.Id, household.Name, household.Price, household.Quantity, household.Brand);
//            else if (original is ElectronicProduct electronic)
//                return new ElectronicProduct(electronic.Id, electronic.Name, electronic.Price, electronic.Quantity, electronic.WarrantyPeriod);
//            else if (original is ClothingProduct clothing)
//                return new ClothingProduct(clothing.Id, clothing.Name, clothing.Price, clothing.Quantity, clothing.Size);
//            else
//                return null;
//        }
//    }
//}

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

        // Có thể xóa nếu không dùng sau này
        //public void RemoveById(string productId)
        //{
        //    children?.RemoveAll(c => c.Id == productId);
        //}

        // Có thể xóa nếu không dùng sau này
        //public IProductComponent GetChild(int index)
        //{
        //    if (index < 0 || index >= (children?.Count ?? 0))
        //        throw new ArgumentOutOfRangeException(nameof(index));
        //
        //    return children[index];
        //}

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

        // Có thể xóa nếu không dùng sau này
        //public bool CanCreateMore(int requestedQuantity)
        //{
        //    if (requestedQuantity <= 0)
        //        return false;
        //
        //    var leafProducts = GetAllLeafProducts();
        //    foreach (var product in leafProducts)
        //    {
        //        if (product.Quantity < (product.Quantity * requestedQuantity))
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        /// <summary>
        /// Serialization - CHỈ serialized các properties cần thiết
        /// KHÔNG gọi base.GetObjectData() để tránh trùng lặp
        /// </summary>
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

        // Có thể xóa nếu không dùng sau này
        //public ComboProduct CloneWithQuantity(int newQuantity)
        //{
        //    var cloned = new ComboProduct(this.Id, this.Name, this.discountPercentage, this.description)
        //    {
        //        Quantity = newQuantity
        //    };
        //
        //    if (children != null)
        //    {
        //        foreach (var child in children)
        //        {
        //            if (child is Product product)
        //            {
        //                Product clonedProduct = CloneProduct(product);
        //                if (clonedProduct != null)
        //                {
        //                    cloned.Add(clonedProduct);
        //                }
        //            }
        //        }
        //    }
        //
        //    return cloned;
        //}
        //
        //private Product CloneProduct(Product original)
        //{
        //    if (original is DrinkProduct drink)
        //        return new DrinkProduct(drink.Id, drink.Name, drink.Price, drink.Quantity, drink.Carbonated);
        //    else if (original is FoodProduct food)
        //        return new FoodProduct(food.Id, food.Name, food.Price, food.Quantity, food.ExpirationDate);
        //    else if (original is HouseholdProduct household)
        //        return new HouseholdProduct(household.Id, household.Name, household.Price, household.Quantity, household.Brand);
        //    else if (original is ElectronicProduct electronic)
        //        return new ElectronicProduct(electronic.Id, electronic.Name, electronic.Price, electronic.Quantity, electronic.WarrantyPeriod);
        //    else if (original is ClothingProduct clothing)
        //        return new ClothingProduct(clothing.Id, clothing.Name, clothing.Price, clothing.Quantity, clothing.Size);
        //    else
        //        return original;
        //}
    }
}