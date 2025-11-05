using OOP_finalProject.Employees;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
        }

        private ManagerData _ManagerDAL = new ManagerData();
        private List<Manager> _Managers = new List<Manager>();
        private CashierData _CashierDAL = new CashierData();
        private List<Cashier> _Cashiers = new List<Cashier>();
        private Store Store = new Store();

        BindingSource _src = new BindingSource();

        private void ManagerForm_Load(object sender, EventArgs e)
        {
            ManagerData.CreateSampleData();
            gridData.DataSource = _src;
            gridData.AllowUserToAddRows = false;
            gridData.ReadOnly = true;

            // Tùy chỉnh giao diện DataGridView
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
            _Managers = _ManagerDAL.GetData();
            _Cashiers = _CashierDAL.GetData();
            UpdateAllTeamSizes();
            DisplayInGrid();
            //if (gridData.Columns["DaysWorked"] == null)
            //{
            //    var col = new DataGridViewTextBoxColumn();
            //    col.Name = "DaysWorked";
            //    col.HeaderText = "Số ngày làm";
            //    col.DataPropertyName = "DaysWorked";
            //    gridData.Columns.Add(col);
            //}
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                var filteredManagers = _Managers.Where(m =>
                    m.Id.ToLower().Contains(txtSearch.Text.ToLower()) ||
                    m.Name.ToLower().Contains(txtSearch.Text.ToLower()) ||
                    m.PhoneNumber.Contains(txtSearch.Text)).ToList();

                _src.DataSource = filteredManagers;
                _src.ResetBindings(true);

                statusLabel.Text = $"Tìm thấy {filteredManagers.Count} kết quả";
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
            _src.DataSource = _Managers;
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

            for (int i = 0; i < _Managers.Count; i++)
            {
                if (_Managers[i].Id.ToLower() == txtCode.Text.ToLower())
                {
                    manager = _Managers[i];
                    break;
                }
            }

            if (manager == null)
            {
                manager = new Manager(txtCode.Text, txtName.Text, rdoMale.Checked ? "Nam" : "Nữ", txtPhone.Text, txtAddress.Text, "Không có cửa hàng");
                _Managers.Add(manager);
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
            _ManagerDAL.SaveData(_Managers);

            // Cập nhật team size sau khi lưu
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
                $"Bạn có chắc chắn muốn xóa quản lý '{txtName.Text}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            Manager manager = null;

            for (int i = 0; i < _Managers.Count; i++)
            {
                if (_Managers[i].Id.ToLower() == txtCode.Text.ToLower())
                {
                    manager = _Managers[i];
                    break;
                }
            }

            if (manager != null)
            {
                _Managers.Remove(manager);
                DisplayInGrid();
                _ManagerDAL.SaveData(_Managers);

                // Cập nhật team size sau khi xóa
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
            _Cashiers = _CashierDAL.GetData();

            foreach (Manager manager in _Managers)
            {
                manager.UpdateTeamSizeFromCashiers(_Cashiers);
            }
        }
    }
}


