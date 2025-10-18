# 🎨 Hướng Dẫn Tích Hợp Strategy Pattern vào Forms

## 📋 Tổng Quan

Document này hướng dẫn cách hiển thị thông tin discount (Strategy Pattern) trong các form của ứng dụng.

## ✅ Đã Cập Nhật

### 1. **InvoiceForm** ✔️
- **File:** `EntityForm/InvoiceForm.cs`
- **Cập nhật:** Hiển thị discount amount và final total trong `lblSumTotal`
- **Code:**
```csharp
// Hiển thị thông tin discount (Strategy Pattern)
lblSumTotal.Text = _invoice.SumTotal.ToString("#,###");

// Hiển thị discount nếu có
if (_invoice.DiscountPercentage > 0)
{
    lblSumTotal.Text += $"\nGiảm giá ({_invoice.DiscountPercentage}%): -{_invoice.DiscountAmount.ToString("#,###")}";
    lblSumTotal.Text += $"\nThành tiền: {_invoice.FinalTotal.ToString("#,###")}";
}
```

## 📝 Cần Cập Nhật

### 2. **ListInvoiceForm**
- **File:** `EntityForm/ListInvoiceForm.cs` & `.Designer.cs`
- **Mục đích:** Hiển thị discount info trong DataGridView
- **Cách thực hiện:**

#### Option 1: Thêm cột mới (Khuyến nghị)
```csharp
// Trong Designer.cs, thêm 2 cột mới:
private DataGridViewTextBoxColumn Column6; // Discount %
private DataGridViewTextBoxColumn Column7; // Final Total

// Cấu hình columns:
Column6.DataPropertyName = "DiscountPercentage";
Column6.HeaderText = "Giảm giá (%)";
Column6.DefaultCellStyle.Format = "0.##";

Column7.DataPropertyName = "FinalTotal";
Column7.HeaderText = "Thành tiền";
Column7.DefaultCellStyle.Format = "#,###";
```

#### Option 2: Tooltip (Đơn giản hơn)
```csharp
// Trong FormInvoiceList_Load hoặc LoadGrid
gridData.CellFormatting += (sender, e) =>
{
    if (e.RowIndex >= 0 && gridData.Columns[e.ColumnIndex].Name == "Column5")
    {
        Invoice invoice = gridData.Rows[e.RowIndex].DataBoundItem as Invoice;
        if (invoice != null && invoice.DiscountPercentage > 0)
        {
            gridData.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = 
                $"Giảm giá: {invoice.DiscountPercentage}%\n" +
                $"Số tiền giảm: {invoice.DiscountAmount:#,###}\n" +
                $"Thành tiền: {invoice.FinalTotal:#,###}";
        }
    }
};
```

### 3. **OrderForm**
- **File:** `EntityForm/OrderForm.cs` & `.Designer.cs`
- **Mục đích:** Hiển thị discount khi tạo/sửa order
- **Cách thực hiện:**

#### Thêm Labels để hiển thị discount
```csharp
// Trong Designer.cs, thêm các controls:
private Label lblSubTotal;      // Tổng chưa giảm
private Label lblDiscount;      // Số tiền giảm
private Label lblFinalTotal;    // Tổng sau giảm
private Label lblCustomerType;  // Loại khách hàng

// Trong OrderForm.cs, thêm method UpdateTotalDisplay:
private void UpdateTotalDisplay()
{
    if (_order == null || _order.Customer == null)
        return;

    decimal subTotal = _order.SumTotal;
    decimal discount = _order.DiscountAmount;
    decimal finalTotal = _order.FinalTotal;
    decimal discountPercent = _order.DiscountPercentage;

    lblSubTotal.Text = $"Tổng: {subTotal:#,###}đ";
    
    if (discountPercent > 0)
    {
        lblDiscount.Text = $"Giảm giá ({discountPercent}%): -{discount:#,###}đ";
        lblDiscount.ForeColor = Color.Red;
        lblFinalTotal.Text = $"Thành tiền: {finalTotal:#,###}đ";
        lblFinalTotal.Font = new Font(lblFinalTotal.Font, FontStyle.Bold);
    }
    else
    {
        lblDiscount.Text = "Không có giảm giá";
        lblFinalTotal.Text = $"Thành tiền: {subTotal:#,###}đ";
    }
}

// Gọi UpdateTotalDisplay khi:
// - Load form
// - Thay đổi customer (cboCustomer_SelectedIndexChanged)
// - Thêm/xóa sản phẩm
```

#### Hiển thị loại khách hàng
```csharp
private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
{
    Customer customer = cboCustomer.SelectedItem as Customer;
    if (customer != null)
    {
        string customerType = customer.GetType().Name;
        string discountInfo = customer.GetDiscountInfo();
        
        lblCustomerType.Text = $"Loại: {customerType}\n{discountInfo}";
        
        // Highlight VIP customers
        if (customer is VIPCustomer)
        {
            lblCustomerType.ForeColor = Color.Gold;
            lblCustomerType.Font = new Font(lblCustomerType.Font, FontStyle.Bold);
        }
        else
        {
            lblCustomerType.ForeColor = Color.Black;
            lblCustomerType.Font = new Font(lblCustomerType.Font, FontStyle.Regular);
        }
        
        UpdateTotalDisplay();
    }
}
```

### 4. **ListOrderForm**
- **File:** `EntityForm/ListOrderForm.cs` & `.Designer.cs`
- **Mục đích:** Hiển thị discount trong danh sách orders
- **Cách thực hiện:** Tương tự ListInvoiceForm

#### Thêm cột discount
```csharp
// Trong Designer.cs
private DataGridViewTextBoxColumn ColumnDiscount;
private DataGridViewTextBoxColumn ColumnFinalTotal;

// Cấu hình
ColumnDiscount.DataPropertyName = "DiscountPercentage";
ColumnDiscount.HeaderText = "Giảm giá (%)";

ColumnFinalTotal.DataPropertyName = "FinalTotal";
ColumnFinalTotal.HeaderText = "Thành tiền";
ColumnFinalTotal.DefaultCellStyle.Format = "#,###";
```

### 5. **CustomerForm**
- **File:** `EntityForm/CustomerForm.cs`
- **Mục đích:** Hiển thị loại khách hàng và discount info
- **Cách thực hiện:**

#### Thêm RadioButton để chọn loại customer
```csharp
// Trong Designer.cs
private RadioButton rbRegular;
private RadioButton rbVIP;
private Label lblDiscountInfo;

// Trong CustomerForm.cs
private void rbRegular_CheckedChanged(object sender, EventArgs e)
{
    if (rbRegular.Checked)
    {
        lblDiscountInfo.Text = "Giảm giá: 10% trên tổng đơn hàng";
        lblDiscountInfo.ForeColor = Color.Blue;
    }
}

private void rbVIP_CheckedChanged(object sender, EventArgs e)
{
    if (rbVIP.Checked)
    {
        lblDiscountInfo.Text = "Giảm giá: 30% trên tổng đơn hàng";
        lblDiscountInfo.ForeColor = Color.Gold;
    }
}

// Khi lưu customer
private void btnSave_Click(object sender, EventArgs e)
{
    Customer customer;
    
    if (rbVIP.Checked)
    {
        customer = new VIPCustomer(
            txtId.Text,
            txtName.Text,
            cboGender.Text,
            txtPhone.Text,
            txtAddress.Text
        );
    }
    else
    {
        customer = new RegularCustomer(
            txtId.Text,
            txtName.Text,
            cboGender.Text,
            txtPhone.Text,
            txtAddress.Text
        );
    }
    
    // ... save logic
}
```

#### Hiển thị loại customer trong grid
```csharp
// Thêm cột CustomerType trong DataGridView
private DataGridViewTextBoxColumn ColumnCustomerType;

// Sử dụng CellFormatting để hiển thị
gridData.CellFormatting += (sender, e) =>
{
    if (gridData.Columns[e.ColumnIndex].Name == "ColumnCustomerType")
    {
        Customer customer = gridData.Rows[e.RowIndex].DataBoundItem as Customer;
        if (customer != null)
        {
            if (customer is VIPCustomer)
            {
                e.Value = "VIP (30%)";
                e.CellStyle.ForeColor = Color.Gold;
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
            }
            else if (customer is RegularCustomer)
            {
                e.Value = "Regular (10%)";
                e.CellStyle.ForeColor = Color.Blue;
            }
            else
            {
                e.Value = "Standard (0%)";
            }
        }
    }
};
```

### 6. **NewOrderForm**
- **File:** `EntityForm/NewOrderForm.cs`
- **Hiện tại:** Form rỗng
- **Cần implement:** Tương tự OrderForm nếu được sử dụng

## 🎨 UI Design Guidelines

### Colors
- **Regular Customer:** Blue (`Color.Blue` hoặc `#0066CC`)
- **VIP Customer:** Gold (`Color.Gold` hoặc `#FFD700`)
- **Discount Amount:** Red (`Color.Red` hoặc `#FF0000`)
- **Final Total:** Green (`Color.Green` hoặc `#008000`)

### Font Styles
- **VIP Customer:** Bold
- **Final Total:** Bold
- **Discount Info:** Regular, slightly smaller

### Layout Example (OrderForm)
```
┌─────────────────────────────────────────────┐
│ Thông tin đơn hàng                          │
├─────────────────────────────────────────────┤
│ Khách hàng: [Dropdown] ▼                    │
│ Loại: VIP Customer (Giảm giá 30%)          │
│                                             │
│ [Danh sách sản phẩm]                        │
│                                             │
│ ─────────────────────────────────────────── │
│ Tổng giá trị:           1,000,000đ         │
│ Giảm giá (30%):          -300,000đ         │
│ ─────────────────────────────────────────── │
│ THÀNH TIỀN:              700,000đ          │
└─────────────────────────────────────────────┘
```

## 📊 Example Implementation

### Complete Example: OrderForm với Discount Display

```csharp
public partial class OrderForm : Form
{
    private Order _order;
    
    // ... existing code ...
    
    private void FormOrder_Load(object sender, EventArgs e)
    {
        // ... existing load code ...
        
        // Setup event handlers
        cboCustomer.SelectedIndexChanged += cboCustomer_SelectedIndexChanged;
        
        // Initial display
        UpdateCustomerInfo();
        UpdateTotalDisplay();
    }
    
    private void UpdateCustomerInfo()
    {
        Customer customer = cboCustomer.SelectedItem as Customer;
        if (customer == null) return;
        
        // Hiển thị loại khách hàng
        string customerType = customer is VIPCustomer ? "VIP" : "Regular";
        string discountInfo = customer.GetDiscountInfo();
        
        lblCustomerType.Text = $"{customerType} Customer";
        lblDiscountInfo.Text = discountInfo;
        
        // Styling
        if (customer is VIPCustomer)
        {
            lblCustomerType.ForeColor = Color.Gold;
            lblCustomerType.Font = new Font(lblCustomerType.Font, FontStyle.Bold);
        }
        else
        {
            lblCustomerType.ForeColor = Color.Blue;
            lblCustomerType.Font = new Font(lblCustomerType.Font, FontStyle.Regular);
        }
    }
    
    private void UpdateTotalDisplay()
    {
        if (_order == null) return;
        
        // Gán customer từ combobox vào order
        _order.Customer = cboCustomer.SelectedItem as Customer;
        
        decimal subTotal = _order.SumTotal;
        decimal discount = _order.DiscountAmount;
        decimal finalTotal = _order.FinalTotal;
        decimal discountPercent = _order.DiscountPercentage;
        
        // Hiển thị
        lblSubTotal.Text = $"{subTotal:#,###}đ";
        
        if (discountPercent > 0)
        {
            lblDiscount.Text = $"-{discount:#,###}đ ({discountPercent}%)";
            lblDiscount.ForeColor = Color.Red;
            lblDiscount.Visible = true;
        }
        else
        {
            lblDiscount.Visible = false;
        }
        
        lblFinalTotal.Text = $"{finalTotal:#,###}đ";
        lblFinalTotal.Font = new Font(lblFinalTotal.Font, FontStyle.Bold);
        lblFinalTotal.ForeColor = Color.Green;
    }
    
    private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateCustomerInfo();
        UpdateTotalDisplay();
    }
    
    private void btnAddProduct_Click(object sender, EventArgs e)
    {
        // ... add product logic ...
        
        // Update display after adding product
        UpdateTotalDisplay();
    }
    
    private void btnRemoveProduct_Click(object sender, EventArgs e)
    {
        // ... remove product logic ...
        
        // Update display after removing product
        UpdateTotalDisplay();
    }
}
```

## 🔧 Testing Checklist

### InvoiceForm
- [ ] Hiển thị đúng discount cho Regular Customer (10%)
- [ ] Hiển thị đúng discount cho VIP Customer (30%)
- [ ] Hiển thị đúng final total
- [ ] Không hiển thị discount nếu customer không có strategy

### OrderForm
- [ ] Hiển thị loại customer khi chọn từ dropdown
- [ ] Cập nhật discount khi thay đổi customer
- [ ] Cập nhật total khi thêm/xóa sản phẩm
- [ ] Styling đúng cho VIP customer (gold, bold)

### CustomerForm
- [ ] Có thể chọn loại customer (Regular/VIP)
- [ ] Hiển thị discount info tương ứng
- [ ] Lưu đúng loại customer vào database
- [ ] Hiển thị loại customer trong grid

### ListInvoiceForm & ListOrderForm
- [ ] Hiển thị discount percentage trong grid
- [ ] Hiển thị final total trong grid
- [ ] Tooltip hiển thị chi tiết discount (nếu dùng option 2)

## 📝 Notes

1. **Backward Compatibility:** Các invoice/order cũ không có customer strategy sẽ có discount = 0
2. **Null Safety:** Luôn kiểm tra customer != null trước khi gọi discount methods
3. **Performance:** Discount được tính real-time, không cần lưu vào database
4. **UI Responsiveness:** Gọi `UpdateTotalDisplay()` mỗi khi có thay đổi
5. **Localization:** Format số theo culture (VN: #,### hoặc N0)

## 🎯 Priority Order

1. **High Priority:**
   - ✅ InvoiceForm (Đã hoàn thành)
   - OrderForm (Quan trọng nhất cho user experience)
   - CustomerForm (Cần để phân biệt Regular/VIP)

2. **Medium Priority:**
   - ListInvoiceForm (Hiển thị tổng quan)
   - ListOrderForm (Hiển thị tổng quan)

3. **Low Priority:**
   - NewOrderForm (Nếu được sử dụng)

---

**Tác giả:** OOP Final Project Team  
**Ngày cập nhật:** 2025-10-18  
**Version:** 1.0
