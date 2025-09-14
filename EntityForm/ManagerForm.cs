using OOP_finalProject.Employees;
using System;
using System.Collections.Generic;
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

        BindingSource _src = new BindingSource();
        private void FormManager_Load(object sender, EventArgs e)
        {
            gridData.DataSource = _src;
            gridData.AllowUserToAddRows = false;
            gridData.ReadOnly = true;

            rdoMale.Checked = true;
            rdoFemale.Checked = false;
            _Managers = _ManagerDAL.GetData();
            DisplayInGrid();
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
            rdoMale.Checked = true;
            rdoFemale.Checked = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Mã quản lý không được để trống !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Tên khách hàng không được để trống !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Manager Manager = null;

            for (int i = 0; i < _Managers.Count; i++)
            {
                if (_Managers[i].Id.ToLower() == txtCode.Text.ToLower())
                {
                    Manager = _Managers[i];
                    break;
                }
            }

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

            DisplayInGrid();

            // save data in database
            _ManagerDAL.SaveData(_Managers);

            MessageBox.Show("Cập nhật thông tin quản lý thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Manager Manager = null;

            for (int i = 0; i < _Managers.Count; i++)
            {
                if (_Managers[i].Id.ToLower() == txtCode.Text.ToLower())
                {
                    Manager = _Managers[i];
                    break;
                }
            }

            if (Manager != null)
            {
                _Managers.Remove(Manager);
            }

            DisplayInGrid();

            _ManagerDAL.SaveData(_Managers);


            MessageBox.Show("Xoá thông tin quản lý thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void gridData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            Manager Manager = gridData.CurrentRow.DataBoundItem as Manager;

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
