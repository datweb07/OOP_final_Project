using System;
using System.Drawing;
using System.Security.Principal;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class MainFormCashier : Form
    {
        //private Form currentForm = null;
        //private Button currentActiveButton = null;

        //public MainFormCashier()
        //{
        //    InitializeComponent();
        //    SetupMenuEvents();
        //}

        //private void SetupMenuEvents()
        //{
        //    // Setup hover effects cho tất cả menu buttons trừ Exit
        //    foreach (Control ctrl in pnlMenuContainer.Controls)
        //    {
        //        if (ctrl is Button btn && btn != btnExit)
        //        {
        //            btn.MouseEnter += MenuButton_MouseEnter;
        //            btn.MouseLeave += MenuButton_MouseLeave;
        //        }
        //    }

        //    // Special hover effects cho Exit button
        //    btnExit.MouseEnter += ExitButton_MouseEnter;
        //    btnExit.MouseLeave += ExitButton_MouseLeave;
        //}

        //#region Menu Button Hover Effects
        //private void MenuButton_MouseEnter(object sender, EventArgs e)
        //{
        //    Button btn = sender as Button;
        //    if (btn != currentActiveButton)
        //        btn.BackColor = Color.FromArgb(24, 116, 205); // đậm hơn DodgerBlue
        //}

        //private void MenuButton_MouseLeave(object sender, EventArgs e)
        //{
        //    Button btn = sender as Button;
        //    if (btn != currentActiveButton)
        //        btn.BackColor = Color.DodgerBlue; // trở về màu nền chính
        //}

        //private void ExitButton_MouseEnter(object sender, EventArgs e)
        //{
        //    btnExit.BackColor = Color.FromArgb(192, 57, 43);
        //}

        //private void ExitButton_MouseLeave(object sender, EventArgs e)
        //{
        //    btnExit.BackColor = Color.FromArgb(231, 76, 60);
        //}
        //#endregion

        //#region Form Loading Methods
        //private void LoadForm(Form formToLoad, string title, Button clickedButton)
        //{
        //    if (formToLoad == null)
        //        return;

        //    // Đóng form hiện tại nếu có
        //    if (currentForm != null)
        //    {
        //        currentForm.Close();
        //        currentForm.Dispose();
        //    }

        //    // Reset active button
        //    if (currentActiveButton != null)
        //    {
        //        currentActiveButton.BackColor = Color.Transparent;
        //    }

        //    // Set active button
        //    currentActiveButton = clickedButton;
        //    currentActiveButton.BackColor = Color.FromArgb(41, 128, 185);

        //    // Load form mới vào panel
        //    currentForm = formToLoad;
        //    currentForm.TopLevel = false;
        //    currentForm.FormBorderStyle = FormBorderStyle.None;
        //    currentForm.Dock = DockStyle.Fill;

        //    // Clear panel và add form mới
        //    pnlContentArea.Controls.Clear();
        //    pnlContentArea.Controls.Add(currentForm);

        //    // Update header title
        //    lblWelcome.Text = title;

        //    // Update status
        //    lblStatus.Text = $"Đang làm việc với: {title}";

        //    currentForm.Show();
        //}

        //private void LoadDashboard()
        //{
        //    // Clear content area
        //    pnlContentArea.Controls.Clear();

        //    // Reset active button
        //    if (currentActiveButton != null)
        //    {
        //        currentActiveButton.BackColor = Color.Transparent;
        //        currentActiveButton = null;
        //    }

        //    // Create dashboard content
        //    CreateDashboardContent();

        //    // Update header
        //    lblWelcome.Text = "Dashboard - Tổng quan hệ thống";
        //    lblStatus.Text = "Đang xem Dashboard";
        //}

        //private void CreateDashboardContent()
        //{
        //    Panel dashboardPanel = new Panel
        //    {
        //        Dock = DockStyle.Fill,
        //        BackColor = Color.White,
        //        Padding = new Padding(30)
        //    };

        //    Label welcomeLabel = new Label
        //    {
        //        Text = "🏪 CHÀO MỪNG ĐÉN VỚI HỆ THỐNG QUẢN LÝ BÁN HÀNG SIÊU THỊ",
        //        Font = new Font("Segoe UI", 18, FontStyle.Bold),
        //        ForeColor = Color.FromArgb(52, 73, 94),
        //        AutoSize = false,
        //        Size = new Size(800, 60),
        //        Location = new Point(0, 20),
        //        TextAlign = ContentAlignment.MiddleCenter
        //    };

        //    Label instructionLabel = new Label
        //    {
        //        Text = "Chọn chức năng từ menu bên trái để bắt đầu làm việc",
        //        Font = new Font("Segoe UI", 14),
        //        ForeColor = Color.FromArgb(127, 140, 141),
        //        AutoSize = false,
        //        Size = new Size(600, 40),
        //        Location = new Point(100, 100),
        //        TextAlign = ContentAlignment.MiddleCenter
        //    };

        //    // Add some statistics cards (placeholder)
        //    Panel statsPanel = new Panel
        //    {
        //        Location = new Point(50, 180),
        //        Size = new Size(800, 200),
        //        BackColor = Color.Transparent
        //    };

        //    // Quick stats cards
        //    AddStatsCard(statsPanel, "👥 Khách Hàng", "1,234", Color.FromArgb(52, 152, 219), 0);
        //    AddStatsCard(statsPanel, "📦 Sản Phẩm", "567", Color.FromArgb(46, 204, 113), 200);
        //    AddStatsCard(statsPanel, "🛒 Đơn Hàng", "89", Color.FromArgb(241, 196, 15), 400);
        //    AddStatsCard(statsPanel, "💰 Doanh Thu", "1.2M", Color.FromArgb(231, 76, 60), 600);

        //    dashboardPanel.Controls.Add(welcomeLabel);
        //    dashboardPanel.Controls.Add(instructionLabel);
        //    dashboardPanel.Controls.Add(statsPanel);

        //    pnlContentArea.Controls.Add(dashboardPanel);
        //}

        //private void AddStatsCard(Panel parent, string title, string value, Color color, int x)
        //{
        //    Panel card = new Panel
        //    {
        //        Location = new Point(x, 0),
        //        Size = new Size(180, 120),
        //        BackColor = color,
        //        Margin = new Padding(10)
        //    };

        //    Label titleLabel = new Label
        //    {
        //        Text = title,
        //        Font = new Font("Segoe UI", 10, FontStyle.Bold),
        //        ForeColor = Color.White,
        //        Location = new Point(10, 15),
        //        AutoSize = true
        //    };

        //    Label valueLabel = new Label
        //    {
        //        Text = value,
        //        Font = new Font("Segoe UI", 24, FontStyle.Bold),
        //        ForeColor = Color.White,
        //        Location = new Point(10, 45),
        //        AutoSize = true
        //    };

        //    card.Controls.Add(titleLabel);
        //    card.Controls.Add(valueLabel);
        //    parent.Controls.Add(card);
        //}
        //#endregion

        //#region Event Handlers
        //private void FormMain_Load(object sender, EventArgs e)
        //{
        //    lblStatus.Text = "Hệ thống đã sẵn sàng";
        //    LoadDashboard(); // Load dashboard mặc định
        //}

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        //}

        //// Dashboard
        //private void btnDashboard_Click(object sender, EventArgs e)
        //{
        //    LoadDashboard();
        //}

        //// Danh sách hóa đơn
        //private void btnInvoiceList_Click(object sender, EventArgs e)
        //{
        //    LoadForm(new ListInvoiceForm(), "📋 Danh Sách Hóa Đơn", btnInvoiceList);
        //}

        //// Danh sách đơn hàng
        //private void btnOrderList_Click(object sender, EventArgs e)
        //{
        //    LoadForm(new ListOrderForm(), "📝 Danh Sách Đơn Hàng", btnOrderList);
        //}

        //// Tạo đơn hàng
        //private void btnOrder_Click(object sender, EventArgs e)
        //{
        //    LoadForm(new NewOrderForm(), "🛒 Tạo Đơn Hàng Mới", btnOrder);
        //}

        //// Thoát ứng dụng
        //private void btnExit_Click(object sender, EventArgs e)
        //{
        //    DialogResult result = MessageBox.Show(
        //        "Bạn có chắc chắn muốn thoát khỏi ứng dụng?",
        //        "Quản Lý Bán Hàng Siêu Thị - Xác Nhận Thoát",
        //        MessageBoxButtons.YesNo,
        //        MessageBoxIcon.Question,
        //        MessageBoxDefaultButton.Button2);

        //    if (result == DialogResult.Yes)
        //    {
        //        // Đóng tất cả forms con
        //        if (currentForm != null)
        //        {
        //            currentForm.Close();
        //            currentForm.Dispose();
        //        }

        //        Application.Exit();
        //    }
        //}
        //#endregion

        //#region Form Cleanup
        //protected override void OnFormClosing(FormClosingEventArgs e)
        //{
        //    if (e.CloseReason == CloseReason.UserClosing)
        //    {
        //        DialogResult result = MessageBox.Show(
        //            "Bạn có chắc chắn muốn thoát khỏi ứng dụng?",
        //            "Xác Nhận Thoát",
        //            MessageBoxButtons.YesNo,
        //            MessageBoxIcon.Question);

        //        if (result == DialogResult.No)
        //        {
        //            e.Cancel = true;
        //            return;
        //        }
        //    }

        //    // Cleanup
        //    if (currentForm != null)
        //    {
        //        currentForm.Close();
        //        currentForm.Dispose();
        //    }

        //    base.OnFormClosing(e);
        //}
        //#endregion

        private Form currentForm = null;
        private Button currentActiveButton = null;
        private DashboardForm dashboardForm = null;

        public MainFormCashier()
        {
            InitializeComponent();
            SetupMenuEvents();
            UpdateWelcomeMessage(); // Cập nhật message chào mừng với tên user
        }

        private void SetupMenuEvents()
        {
            // Setup hover effects cho tất cả menu buttons trừ Exit
            foreach (Control ctrl in pnlMenuContainer.Controls)
            {
                if (ctrl is Button btn && btn != btnExit)
                {
                    btn.MouseEnter += MenuButton_MouseEnter;
                    btn.MouseLeave += MenuButton_MouseLeave;
                }
            }

            // Special hover effects cho Exit button
            btnExit.MouseEnter += ExitButton_MouseEnter;
            btnExit.MouseLeave += ExitButton_MouseLeave;

            // Setup click events cho các buttons
            btnInvoiceList.Click += btnInvoiceList_Click;
            btnOrderList.Click += btnOrderList_Click;
            btnAccount.Click += btnAccount_Click; // Thêm sự kiện cho nút Account
            btnExit.Click += btnExit_Click;
        }

        private void UpdateWelcomeMessage()
        {
            if (UserSession.IsLoggedIn())
            {
                lblWelcome.Text = $"Chào mừng {UserSession.GetDisplayName()} ({UserSession.GetRoleDisplayName()})";
            }
            else
            {
                lblWelcome.Text = "Chào mừng đến với hệ thống quản lý bán hàng siêu thị";
            }
        }

        #region Menu Button Hover Effects
        private void MenuButton_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != currentActiveButton)
                btn.BackColor = Color.FromArgb(74, 98, 120);
        }

        private void MenuButton_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != currentActiveButton)
                btn.BackColor = Color.Transparent;
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.FromArgb(192, 57, 43);
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.FromArgb(231, 76, 60);
        }
        #endregion

        #region Form Loading Methods
        private void LoadForm(Form formToLoad, string title, Button clickedButton)
        {
            if (formToLoad == null)
                return;

            // Đóng form hiện tại nếu có
            if (currentForm != null)
            {
                currentForm.Close();
                currentForm.Dispose();
            }

            // Reset active button
            if (currentActiveButton != null)
            {
                currentActiveButton.BackColor = Color.Transparent;
            }

            // Set active button
            currentActiveButton = clickedButton;
            currentActiveButton.BackColor = Color.FromArgb(41, 128, 185);

            // Load form mới vào panel
            currentForm = formToLoad;
            currentForm.TopLevel = false;
            currentForm.FormBorderStyle = FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;

            // Clear panel và add form mới
            pnlContentArea.Controls.Clear();
            pnlContentArea.Controls.Add(currentForm);

            // Update header title
            lblWelcome.Text = title;

            // Update status
            lblStatus.Text = $"Đang làm việc với: {title}";

            currentForm.Show();
        }

        private void LoadDashboard()
        {
            // Clear content area
            pnlContentArea.Controls.Clear();

            // Reset active button
            if (currentActiveButton != null)
            {
                currentActiveButton.BackColor = Color.Transparent;
                currentActiveButton = null;
            }

            // Tạo hoặc sử dụng lại DashboardForm
            if (dashboardForm == null || dashboardForm.IsDisposed)
            {
                dashboardForm = new DashboardForm();
            }

            // Load dashboard form vào panel
            currentForm = dashboardForm;
            dashboardForm.TopLevel = false;
            dashboardForm.FormBorderStyle = FormBorderStyle.None;
            dashboardForm.Dock = DockStyle.Fill;

            pnlContentArea.Controls.Add(dashboardForm);

            // Update header
            UpdateWelcomeMessage(); // Sử dụng message chào mừng với tên user
            lblStatus.Text = "Đang xem Dashboard";

            dashboardForm.Show();
        }
        #endregion

        #region Event Handlers
        private void MainFormAdmin_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Hệ thống đã sẵn sàng";
            LoadDashboard(); // Load dashboard mặc định
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        // Dashboard
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        // Danh sách hóa đơn
        private void btnInvoiceList_Click(object sender, EventArgs e)
        {
            LoadForm(new ListInvoiceForm(), "📋 Danh Sách Hóa Đơn", btnInvoiceList);
        }

        // Danh sách đơn hàng
        private void btnOrderList_Click(object sender, EventArgs e)
        {
            LoadForm(new ListOrderForm(), "📝 Danh Sách Đơn Hàng", btnOrderList);
        }

        // Tạo đơn hàng
        private void btnOrder_Click(object sender, EventArgs e)
        {
            LoadForm(new NewOrderForm(), "🛒 Tạo Đơn Hàng Mới", btnOrder);
        }

        // Hiển thị thông tin tài khoản
        private void btnAccount_Click(object sender, EventArgs e)
        {
            if (!UserSession.IsLoggedIn())
            {
                MessageBox.Show("Không có thông tin người dùng đăng nhập!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadForm(new AccountForm(), "👤 Thông Tin Tài Khoản", btnAccount);
        }

        // Thoát ứng dụng
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát khỏi ứng dụng?",
                "Quản Lý Bán Hàng Siêu Thị - Xác Nhận Thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                // Clear user session
                UserSession.ClearUserInfo();

                // Đóng tất cả forms con
                if (currentForm != null)
                {
                    currentForm.Close();
                    currentForm.Dispose();
                }

                if (dashboardForm != null && !dashboardForm.IsDisposed)
                {
                    dashboardForm.Close();
                    dashboardForm.Dispose();
                }

                Application.Exit();
            }
        }
        #endregion

        #region Form Cleanup
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn thoát khỏi ứng dụng?",
                    "Xác Nhận Thoát",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            // Cleanup
            if (currentForm != null)
            {
                currentForm.Close();
                currentForm.Dispose();
            }

            base.OnFormClosing(e);
        }
        #endregion
    }
}
