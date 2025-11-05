using System;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class MainFormCashier : Form
    {
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

            // thiết lập sự kiện (hiển thị form)
            btnOrder.Click += btnOrder_Click;
            btnInvoiceList.Click += btnInvoiceList_Click;
            btnOrderList.Click += btnOrderList_Click;
            btnAccount.Click += btnAccount_Click;
            btnExit.Click += btnExit_Click;
        }

        private void UpdateWelcomeMessage()
        {
            if (UserSession.Instance.IsLoggedIn())
            {
                lblWelcome.Text = $"Chào mừng {UserSession.Instance.GetDisplayName()} ({UserSession.Instance.GetRoleDisplayName()})";
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


        #endregion

        #region Event Handlers

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
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
        //private void btnOrder_Click(object sender, EventArgs e)
        //{
        //    LoadForm(new NewOrderForm(), "🛒 Tạo Đơn Hàng Mới", btnOrder);
        //}

        private void btnOrder_Click(object sender, EventArgs e)
        {
            LoadForm(new OrderForm(), "🛒 Tạo Đơn Hàng Mới", btnOrder);
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

        private void btnProduct_Click(object sender, EventArgs e)
        {
            LoadForm(new ProductForm(), "📦 Quản Lý Sản Phẩm", btnProduct);
        }
    }
}
