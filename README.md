### Supermarket Sales Management

A Windows Forms App (.NET Framework) in C# for managing supermarket sales with a simple and user-friendly interface.  
This project applies **Object-Oriented Programming (OOP)** principles.

---

### Features
- Manage products, customers, and invoices  
- Apply OOP principles: Encapsulation, Abstraction, Inheritance, and Polymorphism   
- Menu-driven interface with WinForms   

---

### Technologies
- C# – Windows Forms App (.NET Framework)  
- Object-Oriented Programming (OOP)

---

### Project Structure
```
datweb07-oop_final_project/
├── README.md
├── App.config
├── ClassDiagram1.cd
├── OOP_finalProject.csproj
├── OOP_finalProject.sln
├── packages.config
├── Program.cs
├── users.sql
├── Base/
│ ├── Bill.cs
│ ├── BillDetails.cs
│ ├── Customer.cs
│ ├── Employee.cs
│ ├── Invoice.cs
│ ├── InvoiceDetails.cs
│ ├── Order.cs
│ ├── OrderDetails.cs
│ └── Product.cs
├── CornerRadiusForm/
│ ├── Design.cs
│ └── EllipseControl.cs
├── Customers/
│ ├── RegularCustomer.cs
│ └── VIPCustomer.cs
├── Data/
│ ├── BillData.cs
│ ├── CashierData.cs
│ ├── ClothingProductData.cs
│ ├── CustomerData.cs
│ ├── DrinkProductData.cs
│ ├── ElectronicProductData.cs
│ ├── FoodProductData.cs
│ ├── HouseholdProductData.cs
│ ├── InvoiceData.cs
│ ├── ManagerData.cs
│ └── OrderData.cs
├── Employees/
│ ├── Cashier.cs
│ ├── Manager.cs
│ └── Stocker.cs
├── EntityForm/
│ ├── AccountForm.cs
│ ├── AccountForm.Designer.cs
│ ├── AccountForm.resx
│ ├── CashierForm.cs
│ ├── CashierForm.Designer.cs
│ ├── CustomerForm.cs
│ ├── CustomerForm.Designer.cs
│ ├── CustomerForm.resx
│ ├── DashboardForm.cs
│ ├── DashboardForm.Designer.cs
│ ├── DashboardForm.resx
│ ├── DrinkForm.cs
│ ├── DrinkForm.Designer.cs
│ ├── FoodForm.cs
│ ├── FoodForm.Designer.cs
│ ├── HouseholdProductForm.cs
│ ├── HouseholdProductForm.Designer.cs
│ ├── InvoiceForm.cs
│ ├── InvoiceForm.Designer.cs
│ ├── ListInvoiceForm.cs
│ ├── ListInvoiceForm.Designer.cs
│ ├── ListOrderForm.cs
│ ├── ListOrderForm.Designer.cs
│ ├── MainInterface.cs
│ ├── MainInterface.Designer.cs
│ ├── ManagerForm.cs
│ ├── ManagerForm.Designer.cs
│ ├── NewOrderForm.cs
│ ├── NewOrderForm.Designer.cs
│ ├── OrderForm.cs
│ ├── OrderForm.Designer.cs
│ ├── ProductForm.cs
│ └── ProductForm.Designer.cs
├── GetPath/
│ └── GetPath.cs
├── LoginForm/
│ ├── SignIn.cs
│ ├── SignIn.Designer.cs
│ ├── SignUp.cs
│ └── SignUp.Designer.cs
├── MainForm/
│ ├── MainFormAdmin.cs
│ ├── MainFormAdmin.Designer.cs
│ ├── MainFormAdmin.resx
│ ├── MainFormCashier.cs
│ ├── MainFormCashier.Designer.cs
│ └── MainFormCashier.resx
├── packages/
│ ├── Microsoft.Bcl.AsyncInterfaces.9.0.9/...
│ ├── System.Buffers.4.5.1/...
│ ├── System.IO.Pipelines.9.0.9/...
│ ├── System.Memory.4.5.5/...
│ ├── System.Numerics.Vectors.4.5.0/...
│ ├── System.Runtime.CompilerServices.Unsafe.6.0.0/...
│ ├── System.Text.Encodings.Web.9.0.9/...
│ ├── System.Text.Json.9.0.9/...
│ ├── System.Threading.Tasks.Extensions.4.5.4/...
│ └── System.ValueTuple.4.5.0/...
├── Products/
│ ├── ClothingProduct.cs
│ ├── DrinkProduct.cs
│ ├── ElectronicProduct.cs
│ ├── FoodProduct.cs
│ └── HouseholdProduct.cs
├── Properties/
│ ├── AssemblyInfo.cs
│ ├── Resources.Designer.cs
│ ├── Resources.resx
│ ├── Settings.Designer.cs
│ └── Settings.settings
├── UserManagement/
│ └── UserSession.cs
└── .config/
└── dotnet-tools.json
```
---
## Hướng dẫn chạy dự án
### Bước 1: Download Data storage and processing trong Visual Studio Installer
<img width="421" height="127" alt="image" src="https://github.com/user-attachments/assets/cd012e13-d656-4eed-a86c-8e464db92c4c" />

### Bước 2: Clone dự án về máy
```bash
git clone https://github.com/datweb07/OOP_final_Project.git
```
### Bước 3: Cấu hình file Data.mdf
-  Trong Visual Studio 2022 --> View --> Server Explorer.
-  Chuột phải vào Data Connections, chọn Add Connection...
-  Chọn file Data.mdf trong Browse..., chọn Test Connection để kiểm tra kết nối và nhấn OK.

<img width="565" height="528" alt="image" src="https://github.com/user-attachments/assets/5ea024a0-3429-4eb0-a20c-544768fc81b9" />

### Bước 4: Chạy file querry để tạo bảng, lưu trữ dữ liệu
-  Chuột phải vào file Data.mdf, chọn New Querry.
-  Vào File Explorer, tìm đến file users.sql (mở bằng Visual Studio Code), copy toàn bộ code rồi paste vào cửa sổ sql trong Visual Studio 2022 và nhấn Execute.

<img width="579" height="263" alt="image" src="https://github.com/user-attachments/assets/9b718fce-461d-40f3-b669-fc66b61f3c66" />
