# Hướng Dẫn Sử Dụng Composite Pattern - CompositeProduct

## 📋 Tổng Quan

Dự án đã được tích hợp **Composite Pattern** để quản lý các combo/bundle sản phẩm trong hệ thống siêu thị. Pattern này cho phép bạn tạo các gói sản phẩm phức tạp từ nhiều sản phẩm đơn lẻ.

## 🏗️ Cấu Trúc Implementation

### 1. **IProductComponent** (Component Interface)
- **Vị trí:** `Interfaces/IProductComponent.cs`
- **Mục đích:** Định nghĩa interface chung cho cả sản phẩm đơn lẻ và composite
- **Phương thức chính:**
  - `IsComposite()`: Kiểm tra xem có phải composite không
  - `GetChildren()`: Lấy danh sách component con
  - `CalculateTotal()`: Tính tổng giá trị
  - `GetDisplayInfo()`: Lấy thông tin hiển thị

### 2. **Product** (Leaf - Cập nhật)
- **Vị trí:** `Base/Product.cs`
- **Thay đổi:** 
  - Implement `IProductComponent`
  - Thêm methods `IsComposite()` → trả về `false`
  - Thêm methods `GetChildren()` → trả về danh sách rỗng

### 3. **CompositeProduct** (Composite)
- **Vị trí:** `Products/CompositeProduct.cs`
- **Chức năng:**
  - Quản lý danh sách sản phẩm con (`List<IProductComponent>`)
  - Tự động tính giá dựa trên tổng giá các sản phẩm con
  - Hỗ trợ giảm giá cho combo
  - Có thể chứa sản phẩm đơn hoặc composite khác (nested)

**Thuộc tính:**
- `Id`: Mã combo
- `Name`: Tên combo
- `Description`: Mô tả combo
- `DiscountPercentage`: % giảm giá cho combo
- `Price`: Giá sau khi giảm (tự động tính)
- `GetOriginalPrice()`: Giá gốc (tổng giá các sản phẩm con)

**Phương thức:**
- `Add(IProductComponent)`: Thêm sản phẩm vào combo
- `Remove(IProductComponent)`: Xóa sản phẩm khỏi combo
- `GetAllLeafProducts()`: Lấy tất cả sản phẩm đơn lẻ (bao gồm nested)

### 4. **CompositeProductData** (Data Layer)
- **Vị trí:** `Data/CompositeProductData.cs`
- **Chức năng:** Quản lý lưu trữ và truy xuất dữ liệu CompositeProduct
- **Phương thức:**
  - `GetData()`: Lấy tất cả combo
  - `SaveData()`: Lưu danh sách combo
  - `AddCompositeProduct()`: Thêm combo mới
  - `UpdateCompositeProduct()`: Cập nhật combo
  - `DeleteCompositeProduct()`: Xóa combo
  - `FindById()`: Tìm combo theo ID
  - `SearchByName()`: Tìm kiếm theo tên

### 5. **CompositeProductForm** (UI Layer)
- **Vị trí:** `EntityForm/CompositeProductForm.cs`
- **Chức năng:** Giao diện quản lý combo sản phẩm

**Các thành phần UI:**
- **Danh sách Combo:** Hiển thị tất cả combo đã tạo
- **Thông tin Combo:** Form nhập/chỉnh sửa thông tin combo
- **Sản phẩm trong Combo:** Danh sách sản phẩm đã thêm vào combo
- **Sản phẩm có sẵn:** Danh sách sản phẩm để thêm vào combo

**Các nút chức năng:**
- `Tạo Combo Mới`: Tạo combo mới
- `Lưu Combo`: Lưu thông tin combo
- `Xóa Combo`: Xóa combo đã chọn
- `Thêm vào Combo`: Thêm sản phẩm vào combo
- `Xóa khỏi Combo`: Xóa sản phẩm khỏi combo
- `Xem chi tiết`: Xem thông tin chi tiết combo

## 🚀 Cách Sử Dụng

### Tạo Combo Mới

```csharp
// 1. Tạo composite product
CompositeProduct comboTet = new CompositeProduct(
    "COMBO001", 
    "Combo Tết 2025", 
    15, // Giảm giá 15%
    "Combo quà tết cao cấp"
);

// 2. Thêm sản phẩm vào combo
FoodProduct banhKeo = new FoodProduct("F001", "Bánh kẹo", 50000, 2, DateTime.Now.AddMonths(6));
DrinkProduct nuocNgot = new DrinkProduct("D001", "Nước ngọt", 15000, 6);
FoodProduct mut = new FoodProduct("F002", "Mứt", 80000, 1, DateTime.Now.AddMonths(3));

comboTet.Add(banhKeo);
comboTet.Add(nuocNgot);
comboTet.Add(mut);

// 3. Tính giá
decimal giaGoc = comboTet.GetOriginalPrice(); // 50000*2 + 15000*6 + 80000*1 = 270000
decimal giaSauGiam = comboTet.Price; // 270000 - 15% = 229500
decimal tietKiem = giaGoc - giaSauGiam; // 40500

// 4. Lưu vào database
CompositeProductData data = new CompositeProductData();
data.AddCompositeProduct(comboTet);
```

### Sử Dụng trong Form

1. **Mở CompositeProductForm:**
   - Từ menu chính, chọn "Quản lý Combo Sản phẩm"
   - Hoặc thêm button vào MainFormAdmin

2. **Tạo combo mới:**
   - Click "Tạo Combo Mới"
   - Nhập mã combo, tên, mô tả
   - Chọn % giảm giá
   - Chọn sản phẩm từ danh sách "Sản phẩm có sẵn"
   - Click "Thêm vào Combo"
   - Click "Lưu Combo"

3. **Chỉnh sửa combo:**
   - Chọn combo từ danh sách
   - Thông tin sẽ hiển thị tự động
   - Chỉnh sửa thông tin
   - Thêm/xóa sản phẩm
   - Click "Lưu Combo"

4. **Xóa combo:**
   - Chọn combo cần xóa
   - Click "Xóa Combo"
   - Xác nhận xóa

### Tích Hợp vào MainFormAdmin

Thêm code sau vào `MainFormAdmin.cs`:

```csharp
// Trong SetupMenuEvents()
btnCombo.Click += btnCombo_Click;

// Thêm event handler
private void btnCombo_Click(object sender, EventArgs e)
{
    LoadForm(new CompositeProductForm(), "🎁 Quản Lý Combo Sản Phẩm", btnCombo);
}
```

Thêm button trong `MainFormAdmin.Designer.cs`:

```csharp
private System.Windows.Forms.Button btnCombo;

// Trong InitializeComponent()
this.btnCombo = new System.Windows.Forms.Button();
this.btnCombo.Text = "🎁 Combo Sản Phẩm";
this.btnCombo.Size = new System.Drawing.Size(200, 45);
// ... các thuộc tính khác tương tự các button khác
```

## 📊 Ví Dụ Thực Tế

### Combo Tết
```csharp
CompositeProduct comboTet = new CompositeProduct("CB001", "Combo Tết Nguyên Đán", 20);
comboTet.Add(new FoodProduct("F001", "Bánh chưng", 150000, 2, ...));
comboTet.Add(new FoodProduct("F002", "Mứt tết", 80000, 3, ...));
comboTet.Add(new DrinkProduct("D001", "Rượu vang", 500000, 1));
// Giá gốc: 890000, Giá sau giảm 20%: 712000
```

### Combo Sinh Nhật
```csharp
CompositeProduct comboSinhNhat = new CompositeProduct("CB002", "Combo Sinh Nhật", 15);
comboSinhNhat.Add(new FoodProduct("F003", "Bánh sinh nhật", 300000, 1, ...));
comboSinhNhat.Add(new DrinkProduct("D002", "Nước ngọt", 15000, 12));
comboSinhNhat.Add(new HouseholdProduct("H001", "Nến sinh nhật", 20000, 1));
// Giá gốc: 500000, Giá sau giảm 15%: 425000
```

### Nested Composite (Combo trong Combo)
```csharp
CompositeProduct comboLon = new CompositeProduct("CB003", "Combo Tiệc Lớn", 25);
comboLon.Add(comboSinhNhat); // Thêm combo sinh nhật
comboLon.Add(new FoodProduct("F004", "Đồ ăn nhẹ", 200000, 5, ...));
// Tự động tính giá từ tất cả sản phẩm con (bao gồm cả nested)
```

## 🎯 Lợi Ích

1. **Tính linh hoạt:** Dễ dàng tạo combo phức tạp từ các sản phẩm đơn giản
2. **Tái sử dụng:** Combo có thể chứa combo khác (nested)
3. **Tự động tính giá:** Giá combo được tính tự động từ các sản phẩm con
4. **Quản lý tập trung:** Tất cả logic combo được quản lý ở một nơi
5. **Mở rộng dễ dàng:** Dễ dàng thêm tính năng mới cho combo

## 🔧 Cấu Trúc File

```
OOP_finalProject/
├── Interfaces/
│   └── IProductComponent.cs          # Component interface
├── Base/
│   └── Product.cs                    # Leaf (đã cập nhật)
├── Products/
│   ├── FoodProduct.cs               # Leaf
│   ├── DrinkProduct.cs              # Leaf
│   ├── ...                          # Các Leaf khác
│   └── CompositeProduct.cs          # Composite ⭐
├── Data/
│   └── CompositeProductData.cs      # Data layer ⭐
└── EntityForm/
    ├── CompositeProductForm.cs      # UI ⭐
    ├── CompositeProductForm.Designer.cs
    └── CompositeProductForm.resx
```

## 📝 Lưu Ý

1. **Serialization:** CompositeProduct sử dụng DataContract serialization để lưu trữ
2. **Validation:** Không cho phép thêm chính nó vào danh sách con (tránh vòng lặp vô hạn)
3. **Giá:** Giá của CompositeProduct là read-only, được tính tự động
4. **Nested:** Hỗ trợ nested composite (combo trong combo)
5. **Data persistence:** Dữ liệu được lưu trong file XML tại thư mục Data

## 🐛 Troubleshooting

**Lỗi: "Cannot add composite to itself"**
- Nguyên nhân: Cố gắng thêm composite vào chính nó
- Giải pháp: Kiểm tra logic thêm sản phẩm

**Lỗi: Giá không cập nhật**
- Nguyên nhân: Chưa gọi UpdatePriceDisplay()
- Giải pháp: Gọi method này sau khi thay đổi sản phẩm trong combo

**Lỗi: Không lưu được combo**
- Nguyên nhân: Trùng ID hoặc combo rỗng
- Giải pháp: Kiểm tra ID unique và combo phải có ít nhất 1 sản phẩm

## 📚 Tài Liệu Tham Khảo

- Design Patterns: Elements of Reusable Object-Oriented Software (Gang of Four)
- Composite Pattern: https://refactoring.guru/design-patterns/composite
- C# Design Patterns: https://www.dofactory.com/net/composite-design-pattern

---

**Tác giả:** OOP Final Project Team  
**Ngày cập nhật:** 2025-10-17  
**Version:** 1.0
