using OOP_finalProject.Employees;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class CashierForm : Form
    {
        public CashierForm()
        {
            InitializeComponent();
        }

        private CashierData cashierData = new CashierData();
        private List<Cashier> cashiers = new List<Cashier>();

        BindingSource _src = new BindingSource();
        private void FormSeller_Load(object sender, EventArgs e)
        {
            gridData.DataSource = _src;
            gridData.AllowUserToAddRows = false;
            gridData.ReadOnly = true;

            rdoMale.Checked = true;
            rdoFemale.Checked = false;
            cashiers = cashierData.GetData();
            DisplayInGrid();
        }

        private void DisplayInGrid()
        {
            _src.DataSource = cashiers;
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
                MessageBox.Show("Mã nhân viên bán hàng không được để trống !"
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

            Cashier cashier = null;

            for (int i = 0; i < cashiers.Count; i++)
            {
                if (cashiers[i].Id.ToLower() == txtCode.Text.ToLower())
                {
                    cashier = cashiers[i];
                    break;
                }
            }

            if (cashier == null)
            {
                cashier = new Cashier();
                cashiers.Add(cashier);
            }

            cashier.Id = txtCode.Text;
            cashier.PhoneNumber = txtPhone.Text;
            cashier.Address = txtAddress.Text;
            cashier.Name = txtName.Text;
            cashier.Gender = rdoMale.Checked ? "Nam" : "Nữ";

            DisplayInGrid();

            // save data in database
            cashierData.SaveData(cashiers);

            MessageBox.Show("Cập nhật thông tin nhân viên bán hàng thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Cashier cashier = null;

            for (int i = 0; i < cashiers.Count; i++)
            {
                if (cashiers[i].Id.ToLower() == txtCode.Text.ToLower())
                {
                    cashier = cashiers[i];
                    break;
                }
            }

            if (cashier != null)
            {
                cashiers.Remove(cashier);
            }

            DisplayInGrid();

            cashierData.SaveData(cashiers);


            MessageBox.Show("Xoá thông tin nhân viên bán hàng thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void gridData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            Cashier cashier = (Cashier)gridData.CurrentRow.DataBoundItem;

            if (cashier == null)
                return;

            Display(cashier);
        }

        public void Display(Cashier cashier)
        {
            txtCode.Text = cashier.Id;
            txtName.Text = cashier.Name;
            rdoMale.Checked = cashier.Gender == "Nam" ? true : false;
            rdoFemale.Checked = cashier.Gender != "Nam" ? true : false;
            txtAddress.Text = cashier.Address;
            txtPhone.Text = cashier.PhoneNumber;
        }
    }
}
