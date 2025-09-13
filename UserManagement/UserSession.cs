using System;

namespace OOP_finalProject
{
    public static class UserSession
    {
        public static string Username { get; set; }
        public static string Role { get; set; }
        public static DateTime LoginTime { get; set; }
        public static string Email { get; set; }

        public static void SetUserInfo(string username, string role, string fullName = "", string email = "")
        {
            Username = username;
            Role = role;
            Email = email;
            LoginTime = DateTime.Now;
        }

        // clear thông tin khi đăng xuất
        public static void ClearUserInfo()
        {
            Username = string.Empty;
            Role = string.Empty;
            Email = string.Empty;
            LoginTime = DateTime.MinValue;
        }

        // kiểm tra user có đăng nhập không
        public static bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Role);
        }

        public static string GetDisplayName()
        {
            return Username;
        }

        // role
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