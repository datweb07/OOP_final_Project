using OOP_finalProject.LoginForm;
using System;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class MainInterface : Form
    {
        public MainInterface()
        {
            InitializeComponent();
        }

        private void BtnAdmin_Click(object sender, EventArgs e)
        {
            // Mở form đăng nhập Admin
            SignInAdmin signInAdmin = new SignInAdmin();
            signInAdmin.Show();
            this.Hide(); // Ẩn form hiện tại
        }

        private void BtnEmployee_Click(object sender, EventArgs e)
        {
            // Mở form đăng nhập Employee
            SignInEmployee signInEmployee = new SignInEmployee();
            signInEmployee.Show();
            this.Hide(); // Ẩn form hiện tại
        }

        private void lblCloseSignIn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Có thể thêm chức năng hiển thị thông tin về ứng dụng
            MessageBox.Show("G_D - General Development\nHệ thống quản lý", "Thông tin",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Phương thức để hiển thị lại MainInterface khi người dùng đóng form đăng nhập
        public void ShowMainInterface()
        {
            this.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdmin_Click_1(object sender, EventArgs e)
        {
            SignIn signIn = new SignIn();
            signIn.Show();
        }
    }
}