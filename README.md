## Quản lý bán hàng siêu thị

Ứng dụng Windows Forms (.NET Framework) trong C# để quản lý doanh số bán hàng siêu thị với giao diện đơn giản và thân thiện với người dùng. Dự án này áp dụng các nguyên tắc **Lập trình hướng đối tượng (OOP)**.

## Chức năng
- Quản lý sản phẩm, khách hàng và hóa đơn
- Áp dụng các nguyên tắc OOP: Đóng gói, Trừu tượng, Kế thừa và Đa hình
- Giao diện menu với WinForms  

## Yêu cầu
Dự án này chạy trên nền **.NET Framework 4.7.2** and sử dụng **NetDataContractSerializer** để serialization/deserialization.

## Hướng dẫn chạy dự án
### Bước 1: Download Data storage and processing trong Visual Studio Installer
<img width="421" height="127" alt="image" src="https://github.com/user-attachments/assets/cd012e13-d656-4eed-a86c-8e464db92c4c" />

### Bước 2: Clone dự án về máy
```bash
git clone https://github.com/datweb07/OOP_final_Project.git
```
### Bước 3: Cấu hình file Data.mdf
-  Trong Visual Studio 2022 --> ```View``` --> ```Server Explorer```.
-  Chuột phải vào ```Data Connections```, chọn ```Add Connection...```
-  Chọn file ```Data.mdf``` trong ```Browse...```, chọn ```Test Connection``` để kiểm tra kết nối và nhấn ```OK```.

<img width="565" height="528" alt="image" src="https://github.com/user-attachments/assets/5ea024a0-3429-4eb0-a20c-544768fc81b9" />

### Bước 4: Chạy file querry để tạo bảng, lưu trữ dữ liệu
-  Chuột phải vào file ```Data.mdf```, chọn ```New Querry```.
-  Vào ```File Explorer```, tìm đến file ```users.sql``` (mở bằng Visual Studio Code), copy toàn bộ code rồi paste vào cửa sổ sql trong Visual Studio 2022 và nhấn ```Execute```.
-  Hoặc copy đoạn code tạo database sau:
```sql
CREATE TABLE [dbo].[users] (
    [id]           INT IDENTITY (1,1) NOT NULL,
    [email]        VARCHAR(255) NOT NULL,
    [username]     VARCHAR(100) NOT NULL,
    [password]     VARCHAR(255) NOT NULL,
    [role]         VARCHAR(20) NOT NULL DEFAULT 'seller', -- admin / seller
    [date_created] DATE DEFAULT GETDATE(),
    PRIMARY KEY CLUSTERED ([id] ASC)
);

INSERT INTO [dbo].[users] ([email], [username], [password], [role]) VALUES 
('admin01@gmail.com', 'admin01', '123456', 'admin'),
('admin02@gmail.com', 'admin02', '123456', 'admin');


INSERT INTO [dbo].[users] ([email], [username], [password], [role]) VALUES 
('seller01@gmail.com', 'seller01', 'seller123', 'seller'),
('seller02@gmail.com', 'seller02', 'seller123', 'seller');

SELECT * FROM [dbo].[users] ORDER BY [role], [username];

SELECT [role], COUNT(*) as [count] 
FROM [dbo].[users] 
GROUP BY [role];
```
-  Tạo database thành công:
<img width="579" height="263" alt="image" src="https://github.com/user-attachments/assets/9b718fce-461d-40f3-b669-fc66b61f3c66" />

-  Trường hợp đã có database trong ```Data.mdf``` thì không cần chạy phải querry để tạo nữa.
### Bước 5: Chỉnh lại địa chỉ Connection string trong file SignIn.cs và SignUp.cs
-  Chọn ```View``` -> ```Server Explorer``` -> Chuột phải vào file ```Data.mdf``` -> Chọn ```Properties```.
-  Copy đường dẫn trong ```Connect String```.
-  Vào thư mục ```LoginForm```, chọn ```SignIn.cs``` (View Code), paste đường dẫn đó vào ```SqlConnection```.

<img width="1112" height="330" alt="code" src="https://github.com/user-attachments/assets/2a3fb3b9-61d4-41dd-be02-77ba43486e31" />

-  Làm tương tự với ```SignUp.cs```.

### Bước 6: Hoàn thành
-  Có thể kiểm soát phiên đăng nhập bằng cách sau: chọn ```View``` -> ```Server Explorer``` -> Chọn ```Data.mdf``` -> ```Tables``` -> Chuột phải vào ```users``` -> Chọn ```Show Table Data```.
-  Nhấn F5 để chạy chương trình.

*Cập nhật lần cuối: October 2025*
