using OOP_finalProject.EntityForm;
using System;
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
            UpdateWelcomeMessage(); // Cập nhật message chào mừng với tên user
            LoadDashboard(); // Tự động mở Dashboard sau khi đăng nhập
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
        }

        private void UpdateWelcomeMessage()
        {
            if (UserSession.Instance.IsLoggedIn())
            {
                lblWelcome.Text = $"Chào mừng {UserSession.Instance.GetDisplayName()} ({UserSession.Instance.GetRoleDisplayName()})";
            }
            else
            {
                lblWelcome.Text = "Dashboard";
            }
        }

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

        public void RefreshDashboardView()
        {
            if (dashboardForm != null && !dashboardForm.IsDisposed)
            {
                dashboardForm.RefreshDashboard();
            }
        }

        private void MainFormAdmin_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Hệ thống đã sẵn sàng";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        #region Entity Form

        // Dashboard
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        // Quản lý khách hàng
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            LoadForm(new CustomerForm(), "Khách Hàng", btnCustomer);
        }

        // Quản lý nhân viên quản lý
        private void btnManager_Click(object sender, EventArgs e)
        {
            LoadForm(new ManagerForm(), "Nhân Viên Quản Lý", btnManager);
        }

        // Quản lý nhân viên bán hàng
        private void btnSeller_Click(object sender, EventArgs e)
        {
            LoadForm(new CashierForm(), "Nhân Viên Bán Hàng", btnSeller);
        }

        // Quản lý sản phẩm
        private void btnProduct_Click(object sender, EventArgs e)
        {
            LoadForm(new ProductForm(), "Danh Sách Sản Phẩm", btnProduct);
        }

        // Quản lý đồ uống
        private void btnBeverage_Click(object sender, EventArgs e)
        {
            LoadForm(new DrinkProductForm(), "Đồ Uống", btnBeverage);
        }

        // Quản lý thực phẩm
        private void btnFood_Click(object sender, EventArgs e)
        {
            LoadForm(new FoodProductForm(), "Thực Phẩm", btnFood);
        }

        // Quản lý đồ gia dụng
        private void btnHouseHold_Click(object sender, EventArgs e)
        {
            LoadForm(new HouseholdProductForm(), "Đồ Gia Dụng", btnHouseHold);
        }

        // Danh sách hóa đơn
        private void btnInvoiceList_Click(object sender, EventArgs e)
        {
            LoadForm(new ListInvoiceForm(), "Danh Sách Hóa Đơn", btnInvoiceList);
        }

        // Danh sách đơn hàng
        private void btnOrderList_Click(object sender, EventArgs e)
        {
            LoadForm(new ListOrderForm(), "Danh Sách Đơn Hàng", btnOrderList);
        }

        private void btnElectronic_Click(object sender, EventArgs e)
        {
            LoadForm(new ElectronicProductForm(), "Đồ Điện Tử", btnElectronic);
        }

        private void btnClothing_Click(object sender, EventArgs e)
        {
            LoadForm(new ClothingProductForm(), "Đồ Thời Trang", btnClothing);
        }

        private void btnCombo_Click(object sender, EventArgs e)
        {
            LoadForm(new ComboProductForm(), "Combo Sản Phẩm", btnCombo);
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            LoadForm(new StoreForm(), "Thiết Lập Cửa Hàng", btnStore);
        }

        // Hiển thị thông tin tài khoản
        private void btnAccount_Click(object sender, EventArgs e)
        {
            if (!UserSession.Instance.IsLoggedIn())
            {
                MessageBox.Show("Không có thông tin người dùng đăng nhập!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadForm(new AccountForm(), "Thông tin tài khoản", btnAccount);
        }

        // Thoát ứng dụng
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi ứng dụng?", "Quản Lý Bán Hàng Siêu Thị - Xác Nhận Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                // Clear user session
                UserSession.Instance.ClearUserInfo();

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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi ứng dụng?", "Xác Nhận Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
    }
}