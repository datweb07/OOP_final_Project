using System;

namespace OOP_finalProject
{
<<<<<<< HEAD
    public sealed class UserSession
    {
        private static readonly Lazy<UserSession> _instance = new Lazy<UserSession>(() => new UserSession());
        private static readonly object _lock = new object();

        public string Username { get; set; }
        public string Role { get; set; }
        public DateTime LoginTime { get; set; }
        public string Email { get; set; }

        // Private constructor để ngăn việc tạo instance từ bên ngoài
        private UserSession()
=======
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
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        {
            Username = string.Empty;
            Role = string.Empty;
            Email = string.Empty;
            LoginTime = DateTime.MinValue;
        }

<<<<<<< HEAD
        // Property để truy cập instance duy nhất
        public static UserSession Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public void SetUserInfo(string username, string role, string fullName = "", string email = "")
        {
            lock (_lock)
            {
                Username = username;
                Role = role;
                Email = email;
                LoginTime = DateTime.Now;
            }
        }

        // clear thông tin khi đăng xuất
        public void ClearUserInfo()
        {
            lock (_lock)
            {
                Username = string.Empty;
                Role = string.Empty;
                Email = string.Empty;
                LoginTime = DateTime.MinValue;
            }
        }

        // kiểm tra user có đăng nhập không
        public bool IsLoggedIn()
=======
        // kiểm tra user có đăng nhập không
        public static bool IsLoggedIn()
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Role);
        }

<<<<<<< HEAD
        public string GetDisplayName()
=======
        public static string GetDisplayName()
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        {
            return Username;
        }

        // role
<<<<<<< HEAD
        public string GetRoleDisplayName()
=======
        public static string GetRoleDisplayName()
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
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