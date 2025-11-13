using System;

namespace OOP_finalProject
{
    public sealed class UserSession
    {
        private static readonly Lazy<UserSession> _instance = new Lazy<UserSession>(() => new UserSession());
        private static readonly object _lock = new object();

        public string Username { get; set; }
        public string Role { get; set; }
        public DateTime LoginTime { get; set; }
        public string Email { get; set; }

        // private constructor để ngăn việc tạo instance từ bên ngoài
        private UserSession()
        {
            Username = string.Empty;
            Role = string.Empty;
            Email = string.Empty;
            LoginTime = DateTime.MinValue;
        }

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
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Role);
        }

        public string GetDisplayName()
        {
            return Username;
        }

        // role
        public string GetRoleDisplayName()
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