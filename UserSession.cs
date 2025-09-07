using System;

namespace OOP_finalProject
{
    public static class UserSession
    {
        public static string Username { get; set; }
        public static string Role { get; set; }
        public static DateTime LoginTime { get; set; }
        public static string Email { get; set; }

        // Method để set thông tin user khi đăng nhập thành công
        public static void SetUserInfo(string username, string role, string fullName = "", string email = "")
        {
            Username = username;
            Role = role;
            Email = email;
            LoginTime = DateTime.Now;
        }

        // Method để clear thông tin khi đăng xuất
        public static void ClearUserInfo()
        {
            Username = string.Empty;
            Role = string.Empty;
            Email = string.Empty;
            LoginTime = DateTime.MinValue;
        }

        // Method để kiểm tra user có đăng nhập không
        public static bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Role);
        }

        // Method để lấy tên hiển thị
        public static string GetDisplayName()
        {
            return Username;
        }

        // Method để lấy role hiển thị bằng tiếng Việt
        public static string GetRoleDisplayName()
        {
            switch (Role?.ToLower())
            {
                case "admin":
                    return "Quản trị viên";
                case "seller":
                    return "Nhân viên bán hàng";
                case "manager":
                    return "Quản lý";   // Có thể không cần
                default:
                    return Role ?? "Không xác định";
            }
        }
    }
}