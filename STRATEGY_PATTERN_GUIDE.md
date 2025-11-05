# 🎯 Hướng Dẫn Sử Dụng Strategy Pattern - Discount System

## 📋 Tổng Quan

Dự án đã được tích hợp **Strategy Pattern** để quản lý các chiến lược giảm giá khác nhau cho khách hàng. Pattern này cho phép thay đổi thuật toán giảm giá một cách linh hoạt mà không cần thay đổi code của các class sử dụng nó.

## 🏗️ Cấu Trúc Implementation

### 1. **IDiscountStrategy** (Strategy Interface)
- **Vị trí:** `Interfaces/IDiscountStrategy.cs`
- **Mục đích:** Định nghĩa contract chung cho tất cả các chiến lược giảm giá
- **Methods:**
  - `CalculateDiscount(decimal totalAmount)`: Tính số tiền giảm
  - `GetDiscountPercentage()`: Lấy % giảm giá
  - `GetStrategyName()`: Lấy tên strategy
  - `GetDescription()`: Lấy mô tả strategy

### 2. **RegularCustomerDiscountStrategy** (Concrete Strategy)
- **Vị trí:** `Strategies/RegularCustomerDiscountStrategy.cs`
- **Chức năng:** Giảm giá 10% cho khách hàng thường
- **Công thức:** `Discount = TotalAmount × 10%`

### 3. **VIPCustomerDiscountStrategy** (Concrete Strategy)
- **Vị trí:** `Strategies/VIPCustomerDiscountStrategy.cs`
- **Chức năng:** Giảm giá 30% cho khách hàng VIP
- **Công thức:** `Discount = TotalAmount × 30%`

### 4. **Customer** (Context - Cập nhật)
- **Vị trí:** `Base/Customer.cs`
- **Thay đổi:**
  - Thêm field `discountStrategy` để lưu strategy hiện tại
  - Thêm method `SetDiscountStrategy()` để thiết lập strategy
  - Thêm method `CalculateDiscount()` để tính giảm giá
  - Thêm method `GetDiscountPercentage()` để lấy % giảm
  - Thêm method `GetDiscountInfo()` để lấy thông tin

### 5. **RegularCustomer** (Cập nhật)
- **Vị trí:** `Customers/RegularCustomer.cs`
- **Thay đổi:** Tự động set `RegularCustomerDiscountStrategy` trong constructor

### 6. **VIPCustomer** (Cập nhật)
- **Vị trí:** `Customers/VIPCustomer.cs`
- **Thay đổi:** Tự động set `VIPCustomerDiscountStrategy` trong constructor

### 7. **Bill, Invoice, Order** (Cập nhật)
- **Vị trí:** `Base/Bill.cs`, `Base/Invoice.cs`, `Base/Order.cs`
- **Thêm Properties:**
  - `DiscountAmount`: Số tiền được giảm
  - `FinalPrice/FinalTotal`: Tổng tiền sau giảm giá
  - `DiscountPercentage`: % giảm giá

## 🎯 Strategy Pattern Structure

```
IDiscountStrategy (Strategy Interface)
    ├── RegularCustomerDiscountStrategy (10%)
    └── VIPCustomerDiscountStrategy (30%)

Customer (Context)
    ├── discountStrategy: IDiscountStrategy
    ├── SetDiscountStrategy()
    └── CalculateDiscount()

RegularCustomer → auto-set RegularCustomerDiscountStrategy
VIPCustomer → auto-set VIPCustomerDiscountStrategy
```

## 🚀 Cách Sử Dụng

### 1. Sử Dụng Cơ Bản

```csharp
// Tạo Regular Customer (tự động có 10% discount)
Customer regularCustomer = new RegularCustomer(
    "REG001", 
    "Nguyễn Văn A", 
    "Nam", 
    "0901234567", 
    "Hà Nội"
);

decimal orderAmount = 1000000m; // 1 triệu
decimal discount = regularCustomer.CalculateDiscount(orderAmount); // 100,000đ
decimal finalAmount = orderAmount - discount; // 900,000đ

Console.WriteLine($"Giảm giá: {discount:C}");
Console.WriteLine($"Phải trả: {finalAmount:C}");
```

### 2. VIP Customer

```csharp
// Tạo VIP Customer (tự động có 30% discount)
Customer vipCustomer = new VIPCustomer(
    "VIP001", 
    "Trần Thị B", 
    "Nữ", 
    "0907654321", 
    "TP.HCM"
);

decimal orderAmount = 1000000m; // 1 triệu
decimal discount = vipCustomer.CalculateDiscount(orderAmount); // 300,000đ
decimal finalAmount = orderAmount - discount; // 700,000đ

Console.WriteLine($"Giảm giá: {discount:C}");
Console.WriteLine($"Phải trả: {finalAmount:C}");
```

### 3. Thay Đổi Strategy Động

```csharp
// Tạo customer thường
Customer customer = new Customer("C001", "Lê Văn C", "Nam", "0909999999", "Đà Nẵng");

// Ban đầu không có discount
decimal discount1 = customer.CalculateDiscount(500000); // 0đ

// Set Regular strategy
customer.SetDiscountStrategy(new RegularCustomerDiscountStrategy());
decimal discount2 = customer.CalculateDiscount(500000); // 50,000đ

// Nâng cấp lên VIP strategy
customer.SetDiscountStrategy(new VIPCustomerDiscountStrategy());
decimal discount3 = customer.CalculateDiscount(500000); // 150,000đ
```

### 4. Sử Dụng với Bill

```csharp
// Tạo bill với Regular Customer
Bill bill = new Bill();
bill.Id = "BILL001";
bill.DateCreated = DateTime.Now;
bill.Customer = new RegularCustomer("REG001", "Nguyễn Văn A", "Nam", "0901234567", "Hà Nội");

// Thêm sản phẩm
bill.BillDetails.Add(new BillDetails 
{ 
    ProductID = "P001", 
    ProductName = "Sản phẩm 1", 
    Quantity = 2, 
    UnitPrice = 250000 
});

// Tự động tính discount
Console.WriteLine($"Tổng giá trị: {bill.TotalPrice:C}"); // 500,000đ
Console.WriteLine($"Giảm giá: {bill.DiscountAmount:C}"); // 50,000đ (10%)
Console.WriteLine($"Thành tiền: {bill.FinalPrice:C}"); // 450,000đ
```

### 5. Sử Dụng với Invoice

```csharp
Invoice invoice = new Invoice();
invoice.Id = "INV001";
invoice.DateCreated = DateTime.Now;
invoice.Customer = new VIPCustomer("VIP001", "Trần Thị B", "Nữ", "0907654321", "TP.HCM");

// Thêm items
invoice.InvoiceDetails.Add(new InvoiceDetails 
{ 
    ProductID = "P001", 
    ProductName = "Laptop", 
    Quantity = 1, 
    UnitPrice = 15000000 
});

// Tự động tính discount
Console.WriteLine($"Tổng: {invoice.SumTotal:C}"); // 15,000,000đ
Console.WriteLine($"Giảm giá: {invoice.DiscountAmount:C}"); // 4,500,000đ (30%)
Console.WriteLine($"Thanh toán: {invoice.FinalTotal:C}"); // 10,500,000đ
```

### 6. Sử Dụng với Order

```csharp
Order order = new Order();
order.OrderId = "ORD001";
order.OrderDate = DateTime.Now;
order.Customer = new RegularCustomer("REG001", "Nguyễn Văn A", "Nam", "0901234567", "Hà Nội");

// Thêm items
order.OrderDetails.Add(new OrderDetails 
{ 
    ProductID = "P001", 
    ProductName = "Tivi", 
    Quantity = 1, 
    UnitPrice = 8000000 
});

// Tự động tính discount
Console.WriteLine($"Tổng: {order.SumTotal:C}"); // 8,000,000đ
Console.WriteLine($"Giảm giá: {order.DiscountAmount:C}"); // 800,000đ (10%)
Console.WriteLine($"Thanh toán: {order.FinalTotal:C}"); // 7,200,000đ
```

## 📊 Bảng So Sánh

| Giá trị đơn hàng | Regular (10%) | VIP (30%) | Chênh lệch | % Tiết kiệm |
|------------------|---------------|-----------|------------|-------------|
| 100,000đ         | 90,000đ       | 70,000đ   | 20,000đ    | 20%         |
| 500,000đ         | 450,000đ      | 350,000đ  | 100,000đ   | 20%         |
| 1,000,000đ       | 900,000đ      | 700,000đ  | 200,000đ   | 20%         |
| 5,000,000đ       | 4,500,000đ    | 3,500,000đ| 1,000,000đ | 20%         |
| 10,000,000đ      | 9,000,000đ    | 7,000,000đ| 2,000,000đ | 20%         |

## 💡 Ví Dụ Thực Tế

### Scenario 1: Khách hàng mua sắm thường xuyên
```csharp
// Khách hàng thường mua 1 triệu
RegularCustomer customer = new RegularCustomer("REG001", "Nguyễn Văn A", ...);
Bill bill = new Bill { Customer = customer };
// ... thêm sản phẩm ...
// Tổng: 1,000,000đ → Giảm 100,000đ → Phải trả: 900,000đ
```

### Scenario 2: Nâng cấp khách hàng lên VIP
```csharp
// Khách hàng được nâng cấp lên VIP
Customer customer = ...; // customer hiện tại
customer.SetDiscountStrategy(new VIPCustomerDiscountStrategy());
// Từ giờ sẽ được giảm 30% thay vì 10%
```

### Scenario 3: Khuyến mãi đặc biệt
```csharp
// Có thể tạo strategy mới cho event đặc biệt
public class SpecialEventDiscountStrategy : IDiscountStrategy
{
    public decimal CalculateDiscount(decimal totalAmount)
    {
        return totalAmount * 0.50m; // Giảm 50%
    }
    // ... implement các method khác
}

// Áp dụng cho khách hàng trong sự kiện
customer.SetDiscountStrategy(new SpecialEventDiscountStrategy());
```

## 🎓 Design Pattern Principles

### Open/Closed Principle
- ✅ **Open for extension:** Dễ dàng thêm strategy mới (ví dụ: SeasonalDiscount, LoyaltyDiscount)
- ✅ **Closed for modification:** Không cần sửa code Customer, Bill, Invoice, Order

### Single Responsibility
- ✅ Mỗi strategy chỉ chịu trách nhiệm tính discount theo cách riêng
- ✅ Customer chỉ quản lý thông tin khách hàng và delegate việc tính discount

### Dependency Inversion
- ✅ Customer phụ thuộc vào abstraction (IDiscountStrategy)
- ✅ Không phụ thuộc vào concrete classes

### Liskov Substitution
- ✅ Tất cả concrete strategies có thể thay thế cho nhau
- ✅ Customer hoạt động đúng với bất kỳ strategy nào

## 🔧 Mở Rộng

### Thêm Strategy Mới

```csharp
// 1. Tạo class implement IDiscountStrategy
public class SeasonalDiscountStrategy : IDiscountStrategy
{
    private const decimal DISCOUNT_PERCENTAGE = 20m;

    public decimal CalculateDiscount(decimal totalAmount)
    {
        return totalAmount * (DISCOUNT_PERCENTAGE / 100);
    }

    public decimal GetDiscountPercentage()
    {
        return DISCOUNT_PERCENTAGE;
    }

    public string GetStrategyName()
    {
        return "Seasonal Discount";
    }

    public string GetDescription()
    {
        return $"Giảm giá theo mùa {DISCOUNT_PERCENTAGE}%";
    }
}

// 2. Sử dụng
customer.SetDiscountStrategy(new SeasonalDiscountStrategy());
```

### Tạo Loại Customer Mới

```csharp
public class PremiumCustomer : Customer
{
    public PremiumCustomer(string id, string name, string gender, 
                          string phoneNumber, string address) 
        : base(id, name, gender, phoneNumber, address)
    {
        // Set strategy riêng cho Premium (ví dụ 25%)
        SetDiscountStrategy(new PremiumCustomerDiscountStrategy());
    }
}
```

## 📝 Lưu Ý

1. **Automatic Strategy:** RegularCustomer và VIPCustomer tự động set strategy phù hợp
2. **Dynamic Change:** Có thể thay đổi strategy bất kỳ lúc nào bằng `SetDiscountStrategy()`
3. **Null Safety:** Nếu không có strategy, discount = 0
4. **Calculation:** Discount được tính tự động trong Bill/Invoice/Order
5. **Extensibility:** Dễ dàng thêm strategy mới mà không ảnh hưởng code cũ

## 🐛 Troubleshooting

**Lỗi: Discount = 0**
- Nguyên nhân: Chưa set strategy cho customer
- Giải pháp: Gọi `customer.SetDiscountStrategy(new ...Strategy())`

**Lỗi: NullReferenceException**
- Nguyên nhân: Customer = null trong Bill/Invoice/Order
- Giải pháp: Đảm bảo set Customer trước khi tính discount

**Lỗi: Discount không đúng**
- Nguyên nhân: Sử dụng sai strategy
- Giải pháp: Kiểm tra strategy bằng `customer.GetDiscountPercentage()`

## 📚 Tài Liệu Tham Khảo

- Design Patterns: Elements of Reusable Object-Oriented Software (Gang of Four)
- Strategy Pattern: https://refactoring.guru/design-patterns/strategy
- C# Design Patterns: https://www.dofactory.com/net/strategy-design-pattern

---

**Tác giả:** OOP Final Project Team  
**Ngày cập nhật:** 2025-10-18  
**Version:** 1.0
