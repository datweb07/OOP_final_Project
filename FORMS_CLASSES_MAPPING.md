# 📋 Forms-Classes Mapping Analysis

## 🎯 Mục Đích
Document này phân tích mapping giữa Forms (UI) và Classes (Logic) trong dự án, và đề xuất các cập nhật cần thiết.

---

## 📊 Current Mapping

### ✅ Product Classes & Forms

| Class | Form | Status | Notes |
|-------|------|--------|-------|
| **Product** (Abstract) | ProductForm.cs | ⚠️ Generic | Base form |
| **DrinkProduct** | DrinkProductForm.cs | ✅ | Specific form |
| **FoodProduct** | FoodProductForm.cs | ✅ | Specific form |
| **ElectronicProduct** | ElectronicProductForm.cs | ✅ | Specific form |
| **HouseholdProduct** | HouseholdProductForm.cs | ✅ | Specific form |
| **ClothingProduct** | ❌ NO FORM | ❌ Missing | Need to create |
| **CompositeProduct** | CompositeProductForm.cs | ✅ | Composite pattern form |

### ⚠️ Customer Classes & Forms

| Class | Form | Status | Issue |
|-------|------|--------|-------|
| **Customer** (Base) | CustomerForm.cs | ⚠️ | Only creates base Customer |
| **RegularCustomer** | ❌ NO FORM | ❌ | Not used in form |
| **VIPCustomer** | ❌ NO FORM | ❌ | Not used in form |

**PROBLEM:** CustomerForm chỉ tạo `new Customer()` thay vì `RegularCustomer` hoặc `VIPCustomer`
- ❌ Không có UI để chọn loại customer
- ❌ Không tận dụng Strategy Pattern (discount)
- ❌ Không hiển thị discount info

### ✅ Employee Classes & Forms

| Class | Form | Status | Notes |
|-------|------|--------|-------|
| **Employee** (Base) | ❌ NO FORM | ✅ | Base class only |
| **Manager** | ManagerForm.cs | ✅ | Specific form |
| **Cashier** | CashierForm.cs | ✅ | Specific form |

### ✅ Business Objects & Forms

| Class | Form | Status | Notes |
|-------|------|--------|-------|
| **Order** | OrderForm.cs | ✅ Updated | Has discount display |
| **Order** (List) | ListOrderForm.cs | ⚠️ | No discount columns |
| **Invoice** | InvoiceForm.cs | ✅ Updated | Has discount display |
| **Invoice** (List) | ListInvoiceForm.cs | ⚠️ | No discount columns |
| **Bill** | ❌ NO FORM | ⚠️ | Not used in UI |
| **Store** | StoreForm.cs | ✅ | Has form |

### 📝 Other Forms

| Form | Purpose | Status |
|------|---------|--------|
| AccountForm.cs | User accounts | ✅ |
| DashboardForm.cs | Dashboard | ✅ |
| NewOrderForm.cs | New order (alternative) | ⚠️ Empty/unused |

---

## 🔧 Required Updates

### 🔴 CRITICAL: CustomerForm

**Current Issue:**
```csharp
// Line 164: Tạo Customer thông thường
customer = new Customer();

// Line 93-94: Sample data cũng là Customer thông thường
new Customer("KH001", "Nguyễn Văn A", "Nam", "0901234567", "123 Lê Lợi, Q1, TP.HCM"),
new Customer("KH002", "Trần Thị B", "Nữ", "0912345678", "456 Nguyễn Huệ, Q3, TP.HCM"),
```

**Required Changes:**
1. ✅ Thêm RadioButton hoặc ComboBox để chọn loại customer (Regular/VIP)
2. ✅ Tạo `RegularCustomer` hoặc `VIPCustomer` thay vì `Customer`
3. ✅ Hiển thị discount info tương ứng
4. ✅ Update sample data để có cả Regular và VIP

**Proposed UI:**
```
┌─────────────────────────────────────────┐
│ Thông tin khách hàng                    │
├─────────────────────────────────────────┤
│ Mã KH: [________]                       │
│ Tên:   [________]                       │
│ Giới tính: ○ Nam  ○ Nữ                 │
│                                         │
│ Loại khách hàng:                        │
│ ○ Regular (Giảm giá 10%)               │
│ ○ VIP (Giảm giá 30%)                   │
│                                         │
│ Thông tin giảm giá: [Label hiển thị]   │
└─────────────────────────────────────────┘
```

### 🟡 MEDIUM: ListOrderForm & ListInvoiceForm

**Current Issue:**
- Không hiển thị discount columns trong DataGridView
- Chỉ hiển thị SumTotal, không có DiscountAmount và FinalTotal

**Required Changes:**
1. ✅ Thêm column "Giảm giá (%)"
2. ✅ Thêm column "Số tiền giảm"
3. ✅ Thêm column "Thành tiền" (sau giảm)
4. ✅ Hoặc dùng tooltip để hiển thị discount info

### 🟢 LOW: ClothingProduct Form

**Current Issue:**
- ClothingProduct class tồn tại nhưng không có form riêng

**Options:**
1. Tạo ClothingProductForm.cs mới
2. Hoặc dùng ProductForm.cs generic (nếu không cần specific fields)

### 🟢 LOW: NewOrderForm

**Current Issue:**
- File tồn tại nhưng có vẻ empty/unused

**Options:**
1. Implement nếu cần
2. Hoặc xóa nếu không dùng

---

## 📝 Implementation Plan

### Phase 1: CRITICAL - CustomerForm ✅ PRIORITY

#### Step 1: Update Designer
```csharp
// Add to CustomerForm.Designer.cs
private RadioButton rbRegular;
private RadioButton rbVIP;
private Label lblCustomerType;
private Label lblDiscountInfo;
private GroupBox groupBoxCustomerType;
```

#### Step 2: Update Form Logic
```csharp
// CustomerForm.cs - btnSave_Click
Customer customer = null;

// Determine customer type based on radio button
if (rbVIP.Checked)
{
    customer = new VIPCustomer(
        txtCode.Text,
        txtName.Text,
        rdoMale.Checked ? "Nam" : "Nữ",
        txtPhone.Text,
        txtAddress.Text
    );
}
else
{
    customer = new RegularCustomer(
        txtCode.Text,
        txtName.Text,
        rdoMale.Checked ? "Nam" : "Nữ",
        txtPhone.Text,
        txtAddress.Text
    );
}

// Display discount info
lblDiscountInfo.Text = customer.GetDiscountInfo();
```

#### Step 3: Update Display Method
```csharp
public void Display(Customer customer)
{
    txtCode.Text = customer.Id;
    txtName.Text = customer.Name;
    rdoMale.Checked = customer.Gender == "Nam";
    rdoFemale.Checked = customer.Gender != "Nam";
    txtAddress.Text = customer.Address;
    txtPhone.Text = customer.PhoneNumber;
    
    // Determine customer type
    if (customer is VIPCustomer)
    {
        rbVIP.Checked = true;
        lblCustomerType.Text = "VIP Customer";
        lblCustomerType.ForeColor = Color.Gold;
    }
    else if (customer is RegularCustomer)
    {
        rbRegular.Checked = true;
        lblCustomerType.Text = "Regular Customer";
        lblCustomerType.ForeColor = Color.Blue;
    }
    else
    {
        rbRegular.Checked = true; // Default
        lblCustomerType.Text = "Standard Customer";
    }
    
    // Display discount info
    lblDiscountInfo.Text = customer.GetDiscountInfo();
}
```

#### Step 4: Update Sample Data
```csharp
private void CreateSampleData()
{
    string filePath = Path.Combine(GetPath.path, nameof(Customer) + ".dat");
    if (!File.Exists(filePath))
    {
        List<Customer> customers = new List<Customer>()
        {
            new RegularCustomer("KH001", "Nguyễn Văn A", "Nam", "0901234567", "123 Lê Lợi, Q1, TP.HCM"),
            new VIPCustomer("KH002", "Trần Thị B", "Nữ", "0912345678", "456 Nguyễn Huệ, Q3, TP.HCM"),
            new RegularCustomer("KH003", "Lê Văn C", "Nam", "0923456789", "789 Trần Hưng Đạo, Q5, TP.HCM"),
            new VIPCustomer("KH004", "Phạm Thị D", "Nữ", "0934567890", "321 Võ Văn Tần, Q3, TP.HCM"),
        };
        
        // Save...
    }
}
```

#### Step 5: Add Event Handlers
```csharp
private void rbRegular_CheckedChanged(object sender, EventArgs e)
{
    if (rbRegular.Checked)
    {
        lblDiscountInfo.Text = "Giảm giá 10% trên tổng đơn hàng";
        lblDiscountInfo.ForeColor = Color.Blue;
        lblCustomerType.Text = "Regular Customer";
        lblCustomerType.ForeColor = Color.Blue;
    }
}

private void rbVIP_CheckedChanged(object sender, EventArgs e)
{
    if (rbVIP.Checked)
    {
        lblDiscountInfo.Text = "Giảm giá 30% trên tổng đơn hàng";
        lblDiscountInfo.ForeColor = Color.Gold;
        lblCustomerType.Text = "VIP Customer";
        lblCustomerType.ForeColor = Color.Gold;
        lblCustomerType.Font = new Font(lblCustomerType.Font, FontStyle.Bold);
    }
}
```

### Phase 2: MEDIUM - List Forms

#### ListInvoiceForm - Add Discount Columns
```csharp
// Designer.cs - Add columns
private DataGridViewTextBoxColumn ColumnDiscountPercent;
private DataGridViewTextBoxColumn ColumnDiscountAmount;
private DataGridViewTextBoxColumn ColumnFinalTotal;

// Configure columns
ColumnDiscountPercent.DataPropertyName = "DiscountPercentage";
ColumnDiscountPercent.HeaderText = "Giảm giá (%)";
ColumnDiscountPercent.DefaultCellStyle.Format = "0.##";

ColumnDiscountAmount.DataPropertyName = "DiscountAmount";
ColumnDiscountAmount.HeaderText = "Số tiền giảm";
ColumnDiscountAmount.DefaultCellStyle.Format = "#,###";

ColumnFinalTotal.DataPropertyName = "FinalTotal";
ColumnFinalTotal.HeaderText = "Thành tiền";
ColumnFinalTotal.DefaultCellStyle.Format = "#,###";
```

#### ListOrderForm - Same as above

### Phase 3: LOW - ClothingProduct Form

**Option 1:** Create new form (if needed specific fields like Size, Material, etc.)
**Option 2:** Use generic ProductForm (if no specific requirements)

---

## 📊 Summary

### Forms Needing Updates

| Form | Priority | Status | Action |
|------|----------|--------|--------|
| CustomerForm.cs | 🔴 CRITICAL | ❌ | Add Regular/VIP selection |
| ListInvoiceForm.cs | 🟡 MEDIUM | ⚠️ | Add discount columns |
| ListOrderForm.cs | 🟡 MEDIUM | ⚠️ | Add discount columns |
| ClothingProductForm.cs | 🟢 LOW | ❌ | Create or use generic |
| NewOrderForm.cs | 🟢 LOW | ⚠️ | Implement or remove |

### Classes Without Forms (OK)

| Class | Reason | Status |
|-------|--------|--------|
| Customer (base) | Abstract concept | ✅ OK |
| Employee (base) | Abstract concept | ✅ OK |
| Product (base) | Abstract class | ✅ OK |
| Bill | Not used in UI | ✅ OK |
| BillDetails | Not used in UI | ✅ OK |
| OrderDetails | Embedded in OrderForm | ✅ OK |
| InvoiceDetails | Embedded in InvoiceForm | ✅ OK |

---

## ✅ Verification Checklist

After updates, verify:

- [ ] CustomerForm có thể tạo RegularCustomer
- [ ] CustomerForm có thể tạo VIPCustomer
- [ ] CustomerForm hiển thị discount info
- [ ] ListInvoiceForm hiển thị discount columns
- [ ] ListOrderForm hiển thị discount columns
- [ ] OrderForm hiển thị discount (✅ Already done)
- [ ] InvoiceForm hiển thị discount (✅ Already done)
- [ ] Tất cả forms save/load data đúng
- [ ] UI/UX consistent và professional

---

**Version:** 1.0  
**Date:** 2025-10-19  
**Status:** 📋 ANALYSIS COMPLETE - READY FOR IMPLEMENTATION
