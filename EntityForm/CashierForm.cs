using OOP_finalProject.Employees;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
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
        private ManagerData managerData = new ManagerData();
        private List<Manager> managers = new List<Manager>();

        BindingSource _src = new BindingSource();
        // Thêm sự kiện cho các nút mới
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                var filteredCashiers = cashiers.Where(c =>
                    c.Id.ToLower().Contains(txtSearch.Text.ToLower()) ||
                    c.Name.ToLower().Contains(txtSearch.Text.ToLower()) ||
                    c.PhoneNumber.Contains(txtSearch.Text)).ToList();

                _src.DataSource = filteredCashiers;
                _src.ResetBindings(true);

                statusLabel.Text = $"Tìm thấy {filteredCashiers.Count} kết quả";
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

        // Cập nhật FormSeller_Load
        private void FormSeller_Load(object sender, EventArgs e)
        {
            CashierData.CreateSampleData();

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
            cashiers = cashierData.GetData();
            managers = managerData.GetData();
            LoadManagersToComboBox();
            DisplayInGrid();

            // Đăng ký sự kiện mới
            btnSearch.Click += btnSearch_Click;
            btnAddNew.Click += btnAddNew_Click;
            txtSearch.TextChanged += (s, _) => btnSearch_Click(null, null);
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
            cmbManager.SelectedIndex = -1;
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

            if (cmbManager.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn quản lý !"
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
            cashier.Role = "Cashier";
            cashier.ManagerName = cmbManager.SelectedItem.ToString();

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

            Cashier cashier = gridData.CurrentRow.DataBoundItem as Cashier;

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

            // Tìm và chọn manager trong ComboBox
            for (int i = 0; i < cmbManager.Items.Count; i++)
            {
                if (cmbManager.Items[i].ToString() == cashier.ManagerName)
                {
                    cmbManager.SelectedIndex = i;
                    break;
                }
            }
        }

        /// <summary>
        /// Load danh sách managers vào ComboBox
        /// </summary>
        private void LoadManagersToComboBox()
        {
            cmbManager.Items.Clear();
            foreach (Manager manager in managers)
            {
                cmbManager.Items.Add(manager.Name);
            }
        }


        //private CashierData cashierData = new CashierData();
        //private List<Cashier> cashiers = new List<Cashier>();

        //BindingSource source = new BindingSource();

        //public CashierForm()
        //{
        //    InitializeComponent();
        //}

        //private void FormSeller_Load(object sender, System.EventArgs e)
        //{
        //    gridData.DataSource = source;
        //    gridData.AllowUserToAddRows = false;
        //    gridData.ReadOnly = true;

        //    rdoFemale.Checked = false;
        //    rdoMale.Checked = true;
        //    cashiers = cashierData.GetData();
        //    DisplayGrid();
        //}

        //private void DisplayGrid()
        //{
        //    source.DataSource = cashiers;
        //    source.ResetBindings(true);
        //}

        //private void btnRefresh_Click(object sender, System.EventArgs e)
        //{
        //    //txtCode.Clear();
        //    //txtName.Clear();
        //    //txtPhone.Clear();
        //    //txtAddress.Clear();
        //    //rdoFemale.Checked = false;
        //    //rdoMale.Checked = true;
        //    txtCode.Text = "";
        //    txtName.Text = "";
        //    txtPhone.Text = "";
        //    txtAddress.Text = "";
        //    rdoMale.Checked = true;
        //    rdoFemale.Checked = false;
        //}

        //private void btnSave_Click(object sender, System.EventArgs e)
        //{
        //    string id = txtCode.Text.Trim();
        //    string name = txtName.Text.Trim();
        //    string phone = txtPhone.Text.Trim();
        //    string address = txtAddress.Text.Trim();
        //    string gender = rdoMale.Checked ? "Nam" : "Nữ";
        //    if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name))
        //    {
        //        MessageBox.Show("Mã và Tên không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    Cashier existingCustomer = cashiers.Find(c => c.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        //    if (existingCustomer != null)
        //    {
        //        existingCustomer.Name = name;
        //        existingCustomer.PhoneNumber = phone;
        //        existingCustomer.Address = address;
        //        existingCustomer.Gender = gender;
        //    }
        //    else
        //    {
        //        Cashier newCustomer = new Cashier(id, name, phone, address, gender);
        //        cashiers.Add(newCustomer);
        //    }
        //    cashierData.SaveData(cashiers);
        //    DisplayGrid();
        //    MessageBox.Show("Lưu thông tin khách hàng thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);


        //}

        //private void btnDelete_Click(object sender, System.EventArgs e)
        //{
        //    if (gridData.CurrentRow != null)
        //    {
        //        string id = gridData.CurrentRow.Cells["Id"].Value.ToString();
        //        Cashier customerToRemove = cashiers.Find(c => c.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        //        if (customerToRemove != null)
        //        {
        //            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //            if (confirmResult == DialogResult.Yes)
        //            {
        //                cashiers.Remove(customerToRemove);
        //                cashierData.SaveData(cashiers);
        //                DisplayGrid();
        //                MessageBox.Show("Xóa khách hàng thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Vui lòng chọn khách hàng để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void gridData_CellEnter(object sender, DataGridViewCellEventArgs d)
        //{
        //    if (gridData.CurrentRow != null || gridData.CurrentRow.IsNewRow)
        //    {
        //        return;
        //    }

        //    Cashier customer = (Cashier)gridData.CurrentRow.DataBoundItem;
        //    if (customer != null)
        //    {
        //        return;
        //    }
        //    DisplayCustomer(customer);

        //}

        //private void DisplayCustomer(Cashier customer)
        //{
        //    txtCode.Text = customer.Id;
        //    txtName.Text = customer.Name;
        //    rdoMale.Checked = customer.Gender == "Nam" ? true : false;
        //    rdoFemale.Checked = customer.Gender != "Nam" ? true : false;
        //    txtPhone.Text = customer.PhoneNumber;
        //    txtAddress.Text = customer.Address;
        //}

    }
}
