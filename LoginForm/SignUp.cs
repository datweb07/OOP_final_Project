using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_finalProject.LoginForm
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|data.mdf;Integrated Security=True;Connect Timeout=30");

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPasswordSignUp.Checked)
            {
                txtPasswordSignUp.UseSystemPasswordChar = true;
            }
            else txtPasswordSignUp.UseSystemPasswordChar = false;
        }

        private void lblSignIn_Click(object sender, EventArgs e)
        {
            SignIn frmSignIn = new SignIn();
            frmSignIn.Show();
            this.Hide();
        }

        private void lblCloseSignUp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                try
                {
                    sqlConnection.Open();
                    String checkUserName = "SELECT * FROM users WHERE username = @username";

                    using (SqlCommand sqlCommand = new SqlCommand(checkUserName, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@username", txtNameSignUp.Text.Trim());

                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count >= 1)
                        {
                            MessageBox.Show("Tên người dùng đã tồn tại, chọn tên khác", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (txtNameSignUp.Text == "" || txtPasswordSignUp.Text == "" || txtEmailSignUp.Text == "" || cboRole.SelectedIndex == -1)
                            {
                                MessageBox.Show("Vui lòng điền đầy đủ thông tin và chọn role", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                string insertData = "INSERT INTO users (email, username, password, role, date_created) " +
                                                    "VALUES (@email, @username, @password, @role, @date)";
                                DateTime date = DateTime.Today;

                                using (SqlCommand sqlCommand1 = new SqlCommand(insertData, sqlConnection))
                                {
                                    sqlCommand1.Parameters.AddWithValue("@email", txtEmailSignUp.Text.Trim());
                                    sqlCommand1.Parameters.AddWithValue("@username", txtNameSignUp.Text.Trim());
                                    sqlCommand1.Parameters.AddWithValue("@password", txtPasswordSignUp.Text.Trim());
                                    sqlCommand1.Parameters.AddWithValue("@role", cboRole.SelectedItem.ToString());
                                    sqlCommand1.Parameters.AddWithValue("@date", date);

                                    sqlCommand1.ExecuteNonQuery();
                                    MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Chuyển về form đăng nhập
                                    SignIn frmSignIn = new SignIn();
                                    frmSignIn.Show();
                                    this.Hide();
                                }
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


        // Các phương thức mới được thêm vào
        private void lblSignIn_MouseEnter(object sender, EventArgs e)
        {
            lblSignIn.ForeColor = Color.FromArgb(52, 152, 219);
        }

        private void lblSignIn_MouseLeave(object sender, EventArgs e)
        {
            lblSignIn.ForeColor = Color.FromArgb(41, 128, 185);
        }

        private void txtNameSignUp_Enter(object sender, EventArgs e)
        {
            panelNameLine.BackColor = Color.FromArgb(52, 152, 219);
        }

        private void txtNameSignUp_Leave(object sender, EventArgs e)
        {
            panelNameLine.BackColor = Color.FromArgb(41, 128, 185);
        }

        private void txtEmailSignUp_Enter(object sender, EventArgs e)
        {
            panelEmailLine.BackColor = Color.FromArgb(52, 152, 219);
        }

        private void txtEmailSignUp_Leave(object sender, EventArgs e)
        {
            panelEmailLine.BackColor = Color.FromArgb(41, 128, 185);
        }

        private void txtPasswordSignUp_Enter(object sender, EventArgs e)
        {
            panelPasswordLine.BackColor = Color.FromArgb(52, 152, 219);
        }

        private void txtPasswordSignUp_Leave(object sender, EventArgs e)
        {
            panelPasswordLine.BackColor = Color.FromArgb(41, 128, 185);
        }

        private void btnSignUp_MouseEnter(object sender, EventArgs e)
        {
            btnSignUp.BackColor = Color.FromArgb(52, 152, 219);
        }

        private void btnSignUp_MouseLeave(object sender, EventArgs e)
        {
            btnSignUp.BackColor = Color.FromArgb(41, 128, 185);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}