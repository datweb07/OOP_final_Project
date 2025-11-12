using OOP_finalProject.Employees;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
        }

        private ManagerData managerData = new ManagerData();
        private List<Manager> managers = new List<Manager>();
        private CashierData cashierData = new CashierData();
        private List<Cashier> cashiers = new List<Cashier>();
        private Store Store = new Store();

        BindingSource _src = new BindingSource();

        private void ManagerForm_Load(object sender, EventArgs e)
        {
            ManagerData.CreateSampleData();

            gridData.DataSource = _src;
            gridData.AllowUserToAddRows = false;
            gridData.ReadOnly = true;

            // tùy chỉnh giao diện DataGridView
            gridData.BorderStyle = BorderStyle.None;
            gridData.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 245);
            gridData.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridData.DefaultCellStyle.SelectionBackColor = Color.FromArgb(65, 105, 225);
            gridData.DefaultCellStyle.SelectionForeColor = Color.White;
            gridData.BackgroundColor = Color.White;
            gridData.EnableHeadersVisualStyles = false;
            gridData.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridData.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(65, 105, 225);
            gridData.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridData.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            rdoMale.Checked = true;
            rdoFemale.Checked = false;
            managers = managerData.GetData();
            cashiers = cashierData.GetData();
            UpdateAllTeamSizes();
            DisplayInGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                List<Manager> filteredManagers = new List<Manager>();
                string searchText = txtSearch.Text.ToLower();

                for (int i = 0; i < managers.Count; i++)
                {
                    Manager manager = managers[i];
                    if (manager.Id.ToLower().Contains(searchText) ||
                        manager.Name.ToLower().Contains(searchText) ||
                        manager.PhoneNumber.Contains(txtSearch.Text))
                    {
                        filteredManagers.Add(manager);
                    }
                }

                _src.DataSource = filteredManagers;
                _src.ResetBindings(true);

                statusLabel.Text = "Tìm thấy " + filteredManagers.Count + " kết quả";
            }
            else
            {
                DisplayInGrid();
                statusLabel.Text = "Sẵn sàng";
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
            txtCode.Focus();
            statusLabel.Text = "Nhập thông tin nhân viên mới";
        }

        private void DisplayInGrid()
        {
            _src.DataSource = managers;
            _src.ResetBindings(true);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtTeamSize.Text = "0";
            rdoMale.Checked = true;
            rdoFemale.Checked = false;
            statusLabel.Text = "Sẵn sàng";

            txtSearch.Text = "";
            statusLabel.Text = "Đã làm mới dữ liệu";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Mã quản lý không được để trống !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCode.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Tên quản lý không được để trống !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhone.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddress.Focus();
                return;
            }

            Manager manager = null;

            for (int i = 0; i < managers.Count; i++)
            {
                if (managers[i].Id.ToLower() == txtCode.Text.ToLower())
                {
                    manager = managers[i];
                    break;
                }
            }

            if (manager == null)
            {
                manager = new Manager(txtCode.Text, txtName.Text, rdoMale.Checked ? "Nam" : "Nữ", txtPhone.Text, txtAddress.Text, "Không có cửa hàng");
                managers.Add(manager);
            }
            else
            {
                manager.Name = txtName.Text;
                manager.Gender = rdoMale.Checked ? "Nam" : "Nữ";
                manager.PhoneNumber = txtPhone.Text;
                manager.Address = txtAddress.Text;
            }

            DisplayInGrid();

            // save data in database
            managerData.SaveData(managers);

            // cập nhật team size sau khi lưu
            UpdateAllTeamSizes();
            DisplayInGrid();

            MessageBox.Show("Cập nhật thông tin quản lý thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Vui lòng chọn quản lý cần xóa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa quản lý '" + txtName.Text + "'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            Manager manager = null;

            for (int i = 0; i < managers.Count; i++)
            {
                if (managers[i].Id.ToLower() == txtCode.Text.ToLower())
                {
                    manager = managers[i];
                    break;
                }
            }

            if (manager != null)
            {
                managers.Remove(manager);
                DisplayInGrid();
                managerData.SaveData(managers);

                // cập nhật team size sau khi xóa
                UpdateAllTeamSizes();
                DisplayInGrid();

                MessageBox.Show("Xoá thông tin quản lý thành công !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnRefresh_Click(null, null);
            }
        }

        private void gridData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            Manager manager = gridData.CurrentRow.DataBoundItem as Manager;

            if (manager == null)
                return;

            Display(manager);
        }

        public void Display(Manager manager)
        {
            txtCode.Text = manager.Id;
            txtName.Text = manager.Name;
            rdoMale.Checked = manager.Gender == "Nam";
            rdoFemale.Checked = manager.Gender != "Nam";
            txtAddress.Text = manager.Address;
            txtPhone.Text = manager.PhoneNumber;
            txtTeamSize.Text = manager.TeamSize.ToString();
        }

        private void UpdateAllTeamSizes()
        {
            // load lại cashier data để có dữ liệu mới nhất
            cashiers = cashierData.GetData();

            for (int i = 0; i < managers.Count; i++)
            {
                managers[i].UpdateTeamSizeFromCashiers(cashiers);
            }
        }
    }
}