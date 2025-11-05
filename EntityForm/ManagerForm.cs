<<<<<<< HEAD
using OOP_finalProject.Employees;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
=======
﻿using OOP_finalProject.Employees;
using System;
using System.Collections.Generic;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
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
<<<<<<< HEAD
        private CashierData _CashierDAL = new CashierData();
        private List<Cashier> _Cashiers = new List<Cashier>();
        private Store Store = new Store();

        BindingSource _src = new BindingSource();

        private void ManagerForm_Load(object sender, EventArgs e)
        {
            ManagerData.CreateSampleData();
=======

        BindingSource _src = new BindingSource();
        private void FormManager_Load(object sender, EventArgs e)
        {
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            gridData.DataSource = _src;
            gridData.AllowUserToAddRows = false;
            gridData.ReadOnly = true;

<<<<<<< HEAD
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
=======
            rdoMale.Checked = true;
            rdoFemale.Checked = false;
            _Managers = _ManagerDAL.GetData();
            DisplayInGrid();
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
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
<<<<<<< HEAD
            txtTeamSize.Text = "0";
            rdoMale.Checked = true;
            rdoFemale.Checked = false;
            statusLabel.Text = "Sẵn sàng";

            txtSearch.Text = "";
            statusLabel.Text = "Đã làm mới dữ liệu";
=======
            rdoMale.Checked = true;
            rdoFemale.Checked = false;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Mã quản lý không được để trống !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
<<<<<<< HEAD
                txtCode.Focus();
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
                return;
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
<<<<<<< HEAD
                MessageBox.Show("Tên quản lý không được để trống !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
=======
                MessageBox.Show("Tên khách hàng không được để trống !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
                return;
            }

            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
<<<<<<< HEAD
                txtPhone.Focus();
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
                return;
            }

            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
<<<<<<< HEAD
                txtAddress.Focus();
                return;
            }

            Manager manager = null;
=======
                return;
            }

            Manager Manager = null;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7

            for (int i = 0; i < _Managers.Count; i++)
            {
                if (_Managers[i].Id.ToLower() == txtCode.Text.ToLower())
                {
<<<<<<< HEAD
                    manager = _Managers[i];
=======
                    Manager = _Managers[i];
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
                    break;
                }
            }

<<<<<<< HEAD
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

=======
            if (Manager == null)
            {
                Manager = new Manager();
                _Managers.Add(Manager);
            }

            Manager.Id = txtCode.Text;
            Manager.PhoneNumber = txtPhone.Text;
            Manager.Address = txtAddress.Text;
            Manager.Name = txtName.Text;
            Manager.Gender = rdoMale.Checked ? "Nam" : "Nữ";

>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            DisplayInGrid();

            // save data in database
            _ManagerDAL.SaveData(_Managers);

<<<<<<< HEAD
            // Cập nhật team size sau khi lưu
            UpdateAllTeamSizes();
            DisplayInGrid();

            MessageBox.Show("Cập nhật thông tin quản lý thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
=======
            MessageBox.Show("Cập nhật thông tin quản lý thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
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
=======
            Manager Manager = null;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7

            for (int i = 0; i < _Managers.Count; i++)
            {
                if (_Managers[i].Id.ToLower() == txtCode.Text.ToLower())
                {
<<<<<<< HEAD
                    manager = _Managers[i];
=======
                    Manager = _Managers[i];
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
                    break;
                }
            }

<<<<<<< HEAD
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
=======
            if (Manager != null)
            {
                _Managers.Remove(Manager);
            }

            DisplayInGrid();

            _ManagerDAL.SaveData(_Managers);


            MessageBox.Show("Xoá thông tin quản lý thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        }

        private void gridData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

<<<<<<< HEAD
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


=======
            Manager Manager = (Manager)gridData.CurrentRow.DataBoundItem;

            if (Manager == null)
                return;

            Display(Manager);
        }

        public void Display(Manager Manager)
        {
            txtCode.Text = Manager.Id;
            txtName.Text = Manager.Name;
            rdoMale.Checked = Manager.Gender == "Nam" ? true : false;
            rdoFemale.Checked = Manager.Gender != "Nam" ? true : false;
            txtAddress.Text = Manager.Address;
            txtPhone.Text = Manager.PhoneNumber;
        }
    }
}
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
