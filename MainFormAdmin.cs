using OOP_finalProject;
using OOP_finalProject.Products;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class MainFormAdmin : Form
    {
        private Form currentForm = null;
        private Button currentActiveButton = null;
        private DashboardForm dashboardForm = null;

        public MainFormAdmin()
        {
            InitializeComponent();
            SetupMenuEvents();
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
            lblWelcome.Text = "Dashboard - Tổng quan hệ thống";
            lblStatus.Text = "Đang xem Dashboard";

            dashboardForm.Show();
        }
        #endregion

        #region Event Handlers
        private void FormMain_Load(object sender, EventArgs e)
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

        // Quản lý cửa hàng
        private void btnStore_Click(object sender, EventArgs e)
        {
            LoadForm(new StoreForm(), "🏪 Quản Lý Cửa Hàng", btnStore);
        }

        // Quản lý khách hàng
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            LoadForm(new CustomerForm(), "👥 Quản Lý Khách Hàng", btnCustomer);
        }

        // Quản lý nhân viên quản lý
        private void btnManager_Click(object sender, EventArgs e)
        {
            LoadForm(new ManagerForm(), "👨‍💼 Quản Lý Nhân Viên Quản Lý", btnManager);
        }

        // Quản lý nhân viên bán hàng
        private void btnSeller_Click(object sender, EventArgs e)
        {
            LoadForm(new CashierForm(), "👨‍💻 Quản Lý Nhân Viên Bán Hàng", btnSeller);
        }

        // Quản lý sản phẩm
        private void btnProduct_Click(object sender, EventArgs e)
        {
            LoadForm(new ProductForm(), "📦 Quản Lý Sản Phẩm", btnProduct);
        }

        // Quản lý đồ uống
        private void btnBeverage_Click(object sender, EventArgs e)
        {
            LoadForm(new BeverageForm(), "🥤 Quản Lý Đồ Uống", btnBeverage);
        }

        // Quản lý thực phẩm
        private void btnFood_Click(object sender, EventArgs e)
        {
            LoadForm(new FoodForm(), "🍔 Quản Lý Thực Phẩm", btnFood);
        }

        // Quản lý đồ gia dụng
        private void btnHouseHold_Click(object sender, EventArgs e)
        {
            LoadForm(new HouseholdProductForm(), "🏠 Quản Lý Đồ Gia Dụng", btnHouseHold);
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

            if (dashboardForm != null && !dashboardForm.IsDisposed)
            {
                dashboardForm.Close();
                dashboardForm.Dispose();
            }

            base.OnFormClosing(e);
        }
        #endregion

        private void btnDashboard_Click_1(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        // Method để refresh dashboard từ bên ngoài
        public void RefreshDashboard()
        {
            if (dashboardForm != null && !dashboardForm.IsDisposed)
            {
                dashboardForm.RefreshDashboard();
            }
        }

        // Method để update thống kê dashboard
        public void UpdateDashboardStats(int customerCount, int productCount, int orderCount, string revenue)
        {
            if (dashboardForm != null && !dashboardForm.IsDisposed)
            {
                dashboardForm.UpdateStatistics(customerCount, productCount, orderCount, revenue);
            }
        }
    }
}