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
            UpdateWelcomeMessage(); // cập nhật message chào mừng với tên user
        }

        private void SetupMenuEvents()
        {
            // thiết lập hiệu ứng hover cho tất cả menu buttons trừ Exit
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
                lblWelcome.Text = "Chào mừng đến với hệ thống quản lý bán hàng siêu thị";
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

            // đóng form hiện tại nếu có
            if (currentForm != null)
            {
                currentForm.Close();
                currentForm.Dispose();
            }

            if (currentActiveButton != null)
            {
                currentActiveButton.BackColor = Color.Transparent;
            }

            currentActiveButton = clickedButton;
            currentActiveButton.BackColor = Color.FromArgb(41, 128, 185);

            // load form mới vào panel
            currentForm = formToLoad;
            currentForm.TopLevel = false;
            currentForm.FormBorderStyle = FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;

            // xóa panel và add form mới
            pnlContentArea.Controls.Clear();
            pnlContentArea.Controls.Add(currentForm);

            // cập nhật tiêu đề và trạng thái
            lblWelcome.Text = title;
            lblStatus.Text = $"Đang làm việc với: {title}";

            currentForm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        #region Entity Form

        // danh sách hóa đơn
        private void btnInvoiceList_Click(object sender, EventArgs e)
        {
            LoadForm(new ListInvoiceForm(), "Danh Sách Hóa Đơn", btnInvoiceList);
        }

        // danh sách đơn hàng
        private void btnOrderList_Click(object sender, EventArgs e)
        {
            LoadForm(new ListOrderForm(), "Danh Sách Đơn Hàng", btnOrderList);
        }

        // danh sách sản phẩm
        private void btnProduct_Click(object sender, EventArgs e)
        {
            LoadForm(new ProductForm(), "Danh Sách Sản Phẩm", btnProduct);
        }

        // tạo đơn hàng mới
        private void btnOrder_Click(object sender, EventArgs e)
        {
            LoadForm(new OrderForm(), "Tạo Đơn Hàng Mới", btnOrder);
        }

        // hiển thị thông tin tài khoản
        private void btnAccount_Click(object sender, EventArgs e)
        {
            if (!UserSession.Instance.IsLoggedIn())
            {
                MessageBox.Show("Không có thông tin người dùng đăng nhập!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadForm(new AccountForm(), "Thông Tin Tài Khoản", btnAccount);
        }

        // thoát ứng dụng
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
                // xóa phiên đăng nhập
                UserSession.Instance.ClearUserInfo();

                // đóng tất cả forms con
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

            // xóa các form con nếu có
            if (currentForm != null)
            {
                currentForm.Close();
                currentForm.Dispose();
            }

            base.OnFormClosing(e);
        }
    }
}
