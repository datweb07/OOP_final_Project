using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
<<<<<<< HEAD
=======
using System.Runtime.Remoting.Contexts;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
using System.Windows.Forms;

namespace OOP_finalProject.LoginForm
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
<<<<<<< HEAD
            //SetPlaceholder(txtUserNameSignIn, "Nhập tên của bạn");
            //SetPlaceholder(txtPasswordSignIn, "Nhập mật khẩu");
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;

            textBox.Enter += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;

                    // Nếu là ô mật khẩu
                    if (textBox == txtPasswordSignIn)
                        textBox.UseSystemPasswordChar = true;
                }
            };

            textBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;

                    if (textBox == txtPasswordSignIn)
                        textBox.UseSystemPasswordChar = false;
                }
            };
        }

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MY LENOVO\Downloads\OOP_final_Project-main\OOP_final_Project-main\Data.mdf;Integrated Security=True;Connect Timeout=30");
=======
        }

        SqlConnection sqlConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\THANH DAT\source\repos\OOP_finalProject\Data.mdf;Integrated Security = True; Connect Timeout = 30");
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        //SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\signInData.mdf;Integrated Security=True;Connect Timeout=30");

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (txtUserNameSignIn.Text == "" || txtPasswordSignIn.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (sqlConnection.State != ConnectionState.Open)
                {
                    try
                    {
                        sqlConnection.Open();

                        // Lấy thêm thông tin user từ database
                        String selectData = "SELECT role, username, email FROM users WHERE username = @username AND password = @password";
                        using (SqlCommand cmd = new SqlCommand(selectData, sqlConnection))
                        {
                            cmd.Parameters.AddWithValue("@username", txtUserNameSignIn.Text);
                            cmd.Parameters.AddWithValue("@password", txtPasswordSignIn.Text);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string role = reader["role"].ToString();
                                    string email = reader["email"]?.ToString() ?? "";

                                    // Lưu thông tin user vào session
<<<<<<< HEAD
                                    UserSession.Instance.SetUserInfo(txtUserNameSignIn.Text, role, email);
=======
                                    UserSession.SetUserInfo(txtUserNameSignIn.Text, role, email);
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7

                                    if (role == "admin")
                                    {
                                        MessageBox.Show("Đăng nhập thành công với quyền Admin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        MainFormAdmin mainFormAdmin = new MainFormAdmin();
                                        mainFormAdmin.Show();
                                    }
                                    else if (role == "seller")
                                    {
                                        MessageBox.Show("Đăng nhập thành công với quyền Seller", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        MainFormCashier mainFormSeller = new MainFormCashier();
                                        mainFormSeller.Show();
                                    }
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Tên người dùng hoặc mật khẩu không chính xác", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi kết nối tới cơ sở dữ liệu: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            SignUp frmSignUp = new SignUp();
            frmSignUp.Show();
            this.Hide();
        }

        private void lblCloseSignIn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkShowPassword_SignIn_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword_SignIn.Checked)
            {
                txtPasswordSignIn.UseSystemPasswordChar = true;
            }
            else txtPasswordSignIn.UseSystemPasswordChar = false;
        }

        // Các phương thức mới được thêm vào
        private void lblSignUp_MouseEnter(object sender, EventArgs e)
        {
            lblSignUp.ForeColor = Color.FromArgb(52, 152, 219);
        }

        private void lblSignUp_MouseLeave(object sender, EventArgs e)
        {
            lblSignUp.ForeColor = Color.FromArgb(41, 128, 185);
        }

        private void txtUserNameSignIn_Enter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(52, 152, 219);
        }

        private void txtUserNameSignIn_Leave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(41, 128, 185);
        }

        private void txtPasswordSignIn_Enter(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(52, 152, 219);
        }

        private void txtPasswordSignIn_Leave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(41, 128, 185);
        }

        private void btnSignIn_MouseEnter(object sender, EventArgs e)
        {
            btnSignIn.BackColor = Color.FromArgb(52, 152, 219);
        }

        private void btnSignIn_MouseLeave(object sender, EventArgs e)
        {
            btnSignIn.BackColor = Color.FromArgb(41, 128, 185);
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}