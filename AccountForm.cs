using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class AccountForm : Form
    {
        public AccountForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadAccountInfo();
        }

        private void InitializeCustomComponents()
        {
            this.SuspendLayout();

            // Form properties
            this.BackColor = Color.White;
            this.ClientSize = new Size(800, 600);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "AccountForm";
            this.Text = "Thông Tin Tài Khoản";

            CreateAccountControls();

            this.ResumeLayout(false);
        }

        private void CreateAccountControls()
        {
            // Main container
            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(40)
            };

            // Title
            Label titleLabel = new Label
            {
                Text = "THÔNG TIN TÀI KHOẢN",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                AutoSize = true,
                Location = new Point(40, 40)
            };

            // Account info container
            Panel infoContainer = new Panel
            {
                Location = new Point(40, 100),
                Size = new Size(720, 400),
                BackColor = Color.FromArgb(248, 249, 250),
                BorderStyle = BorderStyle.FixedSingle
            };

            // User avatar (placeholder)
            Panel avatarPanel = new Panel
            {
                Location = new Point(50, 50),
                Size = new Size(120, 120),
                BackColor = Color.FromArgb(52, 152, 219),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label avatarLabel = new Label
            {
                Text = "👤",
                Font = new Font("Segoe UI", 48),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            avatarPanel.Controls.Add(avatarLabel);

            // User info labels
            int startY = 50;
            int labelSpacing = 45;
            int leftMargin = 200;

            // Username
            CreateInfoRow(infoContainer, "Tên đăng nhập:", UserSession.Username, leftMargin, startY);

            // Full name
            CreateInfoRow(infoContainer, "Họ và tên:", UserSession.GetDisplayName(), leftMargin, startY + labelSpacing);

            // Role
            CreateInfoRow(infoContainer, "Vai trò:", UserSession.GetRoleDisplayName(), leftMargin, startY + labelSpacing * 2);

            // Login time
            CreateInfoRow(infoContainer, "Thời gian đăng nhập:", UserSession.LoginTime.ToString("dd/MM/yyyy HH:mm:ss"), leftMargin, startY + labelSpacing * 3);

            // Session duration
            TimeSpan sessionDuration = DateTime.Now - UserSession.LoginTime;
            string durationText = $"{sessionDuration.Hours:D2}:{sessionDuration.Minutes:D2}:{sessionDuration.Seconds:D2}";
            CreateInfoRow(infoContainer, "Thời gian hoạt động:", durationText, leftMargin, startY + labelSpacing * 4);

            // Action buttons
            Panel buttonPanel = new Panel
            {
                Location = new Point(40, 520),
                Size = new Size(720, 60),
                BackColor = Color.Transparent
            };

            Button btnChangePassword = new Button
            {
                Text = "🔒 Đổi mật khẩu",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(52, 152, 219),
                Location = new Point(0, 10),
                Size = new Size(160, 40),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnChangePassword.FlatAppearance.BorderSize = 0;
            btnChangePassword.Click += BtnChangePassword_Click;

            Button btnLogout = new Button
            {
                Text = "🚪 Đăng xuất",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(231, 76, 60),
                Location = new Point(180, 10),
                Size = new Size(140, 40),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Click += BtnLogout_Click;

            Button btnRefresh = new Button
            {
                Text = "🔄 Làm mới",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(46, 204, 113),
                Location = new Point(340, 10),
                Size = new Size(140, 40),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Click += BtnRefresh_Click;

            // Add hover effects
            AddButtonHoverEffect(btnChangePassword, Color.FromArgb(52, 152, 219));
            AddButtonHoverEffect(btnLogout, Color.FromArgb(231, 76, 60));
            AddButtonHoverEffect(btnRefresh, Color.FromArgb(46, 204, 113));

            // Add controls to containers
            infoContainer.Controls.Add(avatarPanel);
            buttonPanel.Controls.Add(btnChangePassword);
            buttonPanel.Controls.Add(btnLogout);
            buttonPanel.Controls.Add(btnRefresh);

            mainPanel.Controls.Add(titleLabel);
            mainPanel.Controls.Add(infoContainer);
            mainPanel.Controls.Add(buttonPanel);

            this.Controls.Add(mainPanel);
        }

        private void CreateInfoRow(Panel container, string label, string value, int x, int y)
        {
            Label lblTitle = new Label
            {
                Text = label,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                Location = new Point(x, y),
                Size = new Size(150, 25),
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label lblValue = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 12),
                ForeColor = Color.FromArgb(85, 85, 85),
                Location = new Point(x + 160, y),
                Size = new Size(300, 25),
                TextAlign = ContentAlignment.MiddleLeft
            };

            container.Controls.Add(lblTitle);
            container.Controls.Add(lblValue);
        }

        private void AddButtonHoverEffect(Button button, Color originalColor)
        {
            button.MouseEnter += (s, e) => button.BackColor = ControlPaint.Light(originalColor, 0.2f);
            button.MouseLeave += (s, e) => button.BackColor = originalColor;
        }

        private void LoadAccountInfo()
        {
            if (!UserSession.IsLoggedIn())
            {
                MessageBox.Show("Không có thông tin người dùng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            // Mở form đổi mật khẩu (có thể tạo sau)
            MessageBox.Show("Chức năng đổi mật khẩu sẽ được triển khai trong tương lai!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Clear user session
                UserSession.ClearUserInfo();

                // Đóng tất cả forms và quay về form đăng nhập
                foreach (Form form in Application.OpenForms.Cast<Form>().ToArray())
                {
                    if (form.Name != "LoginForm") // Giả sử form đăng nhập có tên là LoginForm
                    {
                        form.Hide();
                    }
                }

                // Hiển thị form đăng nhập (bạn cần tạo instance mới hoặc show form có sẵn)
                MessageBox.Show("Đăng xuất thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Application.Exit(); // Hoặc có thể thoát ứng dụng
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            // Refresh lại thông tin hiển thị
            this.Controls.Clear();
            CreateAccountControls();
            MessageBox.Show("Thông tin đã được làm mới!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Timer để cập nhật thời gian hoạt động (optional)
        private Timer sessionTimer;

        private void StartSessionTimer()
        {
            sessionTimer = new Timer();
            sessionTimer.Interval = 1000; // Cập nhật mỗi giây
            sessionTimer.Tick += (s, e) => RefreshSessionDuration();
            sessionTimer.Start();
        }

        private void RefreshSessionDuration()
        {
            // Cập nhật thời gian hoạt động trong session
            TimeSpan sessionDuration = DateTime.Now - UserSession.LoginTime;
            string durationText = $"{sessionDuration.Hours:D2}:{sessionDuration.Minutes:D2}:{sessionDuration.Seconds:D2}";

            // Tìm và cập nhật label thời gian hoạt động
            foreach (Control control in this.Controls)
            {
                if (control is Panel mainPanel)
                {
                    foreach (Control subControl in mainPanel.Controls)
                    {
                        if (subControl is Panel infoContainer)
                        {
                            // Tìm label thời gian hoạt động và cập nhật
                            // Logic cập nhật có thể được triển khai ở đây
                        }
                    }
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            sessionTimer?.Stop();
            sessionTimer?.Dispose();
            base.OnFormClosing(e);
        }
    }
}