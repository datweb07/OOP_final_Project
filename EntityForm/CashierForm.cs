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
            //if (gridData.Columns["DaysWorked"] == null)
            //{
            //    var col = new DataGridViewTextBoxColumn();
            //    col.Name = "DaysWorked";
            //    col.HeaderText = "Số ngày làm";
            //    col.DataPropertyName = "DaysWorked";
            //    gridData.Columns.Add(col);
            //}

            // auto tìm kiếm khi gõ
            //txtSearch.TextChanged += (s, _) => btnSearch_Click(null, null);
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

            txtSearch.Text = "";
            statusLabel.Text = "Đã làm mới dữ liệu";
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

            Console.WriteLine(cashier.Id);
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
    }
}
