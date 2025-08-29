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

        private void lblCloseSignIn_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnEmployee_Click_1(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
        }
    }
}