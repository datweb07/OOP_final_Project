## Quản lý bán hàng siêu thị

Ứng dụng Windows Forms (.NET Framework) trong C# để quản lý doanh số bán hàng siêu thị với giao diện đơn giản và thân thiện với người dùng. Dự án này áp dụng các nguyên tắc **Lập trình hướng đối tượng (OOP)**.

## Chức năng
- Quản lý sản phẩm, khách hàng và hóa đơn
- Áp dụng các nguyên tắc OOP: Đóng gói, Trừu tượng, Kế thừa và Đa hình
- Giao diện menu với WinForms  

## Yêu cầu
Dự án này chạy trên nền **.NET Framework 4.7.2** and sử dụng **NetDataContractSerializer** để serialization/deserialization.

## Hướng dẫn chạy dự án
### Bước 1: Cài Đặt Môi Trường

#### 1.1. Cài đặt Visual Studio
1. Tải [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)
2. Trong **Visual Studio Installer**, chọn:
   - **.NET desktop development**
   - **Data storage and processing**

<div align="center">
<img src="https://github.com/user-attachments/assets/cd012e13-d656-4eed-a86c-8e464db92c4c" alt="Visual Studio Installer" width="600"/>
</div>

#### 1.2. Cài đặt SQL Server LocalDB
```bash
# Kiểm tra đã cài đặt chưa
sqllocaldb info

# Nếu chưa có, tải từ Microsoft SQL Server Express
```



### Bước 2: Clone Dự Án

#### Cách 1: Sử dụng Git (Khuyến nghị)
```bash
git clone https://github.com/datweb07/OOP_final_Project.git
cd OOP_final_Project
```

#### Cách 2: Download ZIP
1. Vào [repository](https://github.com/datweb07/OOP_final_Project)
2. Click **Code** → **Download ZIP**

<div align="center">
<img src="https://github.com/user-attachments/assets/714b60e0-c90c-40b3-b766-275843229325" alt="Download ZIP" width="600"/>
</div>

3. Giải nén folder `OOP_final_Project-main`
4. Mở file `OOP_finalProject.sln` bằng Visual Studio



### Bước 3: Cấu Hình Database

#### 3.1. Thêm Database Connection
1. Trong Visual Studio: **View** → **Server Explorer**
2. Chuột phải vào **Data Connections** → **Add Connection...**
3. Click **Browse...** → Chọn file `Data.mdf` trong thư mục dự án
4. Click **Test Connection** để kiểm tra
5. Click **OK** để hoàn tất

<div align="center">
<img src="https://github.com/user-attachments/assets/5ea024a0-3429-4eb0-a20c-544768fc81b9" alt="Add Connection" width="500"/>
</div>

#### 3.2. Tạo Bảng Users
1. Chuột phải vào `Data.mdf` → **New Query**
2. Copy và chạy script sau:

```sql
-- Tạo bảng users
CREATE TABLE [dbo].[users] (
    [id]           INT IDENTITY (1,1) NOT NULL,
    [email]        VARCHAR(255) NOT NULL UNIQUE,
    [username]     VARCHAR(100) NOT NULL UNIQUE,
    [password]     VARCHAR(255) NOT NULL,
    [role]         VARCHAR(20) NOT NULL DEFAULT 'seller',
    [date_created] DATETIME DEFAULT GETDATE(),
    [last_login]   DATETIME NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

-- Thêm dữ liệu mẫu
INSERT INTO [dbo].[users] ([email], [username], [password], [role]) VALUES 
('admin01@gmail.com', 'admin01', '123456', 'admin'),
('admin02@gmail.com', 'admin02', '123456', 'admin'),
('seller01@gmail.com', 'seller01', 'seller123', 'seller'),
('seller02@gmail.com', 'seller02', 'seller123', 'seller');

-- Kiểm tra dữ liệu
SELECT * FROM [dbo].[users] ORDER BY [role], [username];
```

3. Click **Execute** (hoặc F5)

<div align="center">
<img src="https://github.com/user-attachments/assets/9b718fce-461d-40f3-b669-fc66b61f3c66" alt="Database Created" width="600"/>
</div>

#### 3.3. Cấu Hình Connection String
1. Trong **Server Explorer**, chuột phải vào `Data.mdf` → **Properties**
2. Copy giá trị của **Connection String**
3. Mở file `LoginForm/SignIn.cs`, tìm dòng:
```csharp
SqlConnection conn = new SqlConnection(@"");
```
4. Thay thế bằng Connection String vừa copy
5. Làm tương tự với `LoginForm/SignUp.cs`

<div align="center">
<img src="https://github.com/user-attachments/assets/2a3fb3b9-61d4-41dd-be02-77ba43486e31" alt="Connection String" width="700"/>
</div>



### Bước 4: Build & Run

1. **Rebuild Solution**: 
   - Chuột phải vào Solution → **Rebuild Solution**

2. **Chạy ứng dụng**:
   - Nhấn **F5** hoặc click **Start**
   - Ứng dụng sẽ mở màn hình đăng nhập

---


### Một vài lỗi thường gặp (Updating)

![z7177214442760_5085ced100eae0a45e510aed40cb8a4e](https://github.com/user-attachments/assets/917dc997-6271-45aa-98f6-7568e748f903)

Lỗi này xuất hiện vì Windowns chặn các file ```.resx``` (download từ Internet như Github,... và bị đánh dấu là không an toàn) nên cần phải unblock như sau:
-  Trong Visual Studio 2022, vào ```View```, chọn ```Terminal```, cửa số Developer PowerShell sẽ hiện lên, nhập câu lệnh này vào và nhấn Enter:
```bash
Get-ChildItem -Recurse | Unblock-File
```
<br>

![z7228885679135_e959e715ce93ede36a75be09a2ce99e3](https://github.com/user-attachments/assets/036d51ec-2e6a-4a0b-9984-5022f482a3b1)

Lỗi màn hình hiển thị không hết Form giao diện, fix như sau:
- Vào Settings, chọn System -> Display -> chọn Scale bằng 100%

## Nhóm Phát Triển

| Thành viên | Vai trò |
|------------|---------|
| Truong Thanh Dat | Team Leader | 
| Phan Khac Anh Tuan | Member |
| Nguyen Phuong Chinh | Member |
| Nguyen Tan Khiem | Member |

<br>

*Cập nhật lần cuối: October 2025*
