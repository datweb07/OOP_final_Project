using System.Windows.Forms;
using System.Collections.Generic;
using OOP_finalProject.Base;
using System;

namespace OOP_finalProject
{
    public partial class CustomerForm : Form
    {
        //private CustomerData customerData = new CustomerData();
        //private List<Customer> customers = new List<Customer>();

        //BindingSource source = new BindingSource();

        //public CustomerForm()
        //{
        //    InitializeComponent();
        //}

        //private void CustomerForm_Load(object sender, System.EventArgs e)
        //{
        //    gridData.DataSource = source;
        //    gridData.AllowUserToAddRows = false;
        //    gridData.ReadOnly = true;

        //    rdoFemale.Checked = false;
        //    rdoMale.Checked = true;
        //    customers = customerData.GetData();
        //    DisplayGrid();
        //}

        //private void DisplayGrid()
        //{
        //    source.DataSource = customers;
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
        //    //string id = txtCode.Text.Trim();
        //    //string name = txtName.Text.Trim();
        //    //string phone = txtPhone.Text.Trim();
        //    //string address = txtAddress.Text.Trim();
        //    //string type = rdoMale.Checked ? "Nam" : "Nữ";
        //    //if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name))
        //    //{
        //    //    MessageBox.Show("Mã và Tên không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    //    return;
        //    //}
        //    //Customer existingCustomer = customers.Find(c => c.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        //    //if (existingCustomer != null)
        //    //{
        //    //    existingCustomer.Name = name;
        //    //    existingCustomer.PhoneNumber = phone;
        //    //    existingCustomer.Address = address;
        //    //    existingCustomer.Type = type;
        //    //}
        //    //else
        //    //{
        //    //    Customer newCustomer = new Customer(id, name, phone, address, type);
        //    //    customers.Add(newCustomer);
        //    //}
        //    //customerData.SaveData(customers);
        //    //DisplayGrid();
        //    //MessageBox.Show("Lưu thông tin khách hàng thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);


        //}

        //private void btnDelete_Click(object sender, System.EventArgs e)
        //{
        //    if (gridData.CurrentRow != null)
        //    {
        //        string id = gridData.CurrentRow.Cells["Id"].Value.ToString();
        //        Customer customerToRemove = customers.Find(c => c.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        //        if (customerToRemove != null)
        //        {
        //            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //            if (confirmResult == DialogResult.Yes)
        //            {
        //                customers.Remove(customerToRemove);
        //                customerData.SaveData(customers);
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

        //private void gridData_SelectionChanged(object sender, DataGridViewCellEventArgs d)
        //{
        //    if (gridData.CurrentRow != null || gridData.CurrentRow.IsNewRow)
        //    {
        //        return;
        //    }

        //    Customer customer = (Customer)gridData.CurrentRow.DataBoundItem;
        //    if (customer != null)
        //    {
        //        return;
        //    }
        //    DisplayCustomer(customer);

        //}

        //private void DisplayCustomer(Customer customer)
        //{
        //    txtCode.Text = customer.Id;
        //    txtName.Text = customer.Name;
        //    rdoMale.Checked = customer.Gender == "Nam" ? true : false;
        //    rdoFemale.Checked = customer.Gender != "Nam" ? true : false;
        //    txtPhone.Text = customer.PhoneNumber;
        //    txtAddress.Text = customer.Address;
        //}

        public CustomerForm()
        {
            InitializeComponent();
        }

        private CustomerData customerData = new CustomerData();
        private List<Customer> customers = new List<Customer>();

        BindingSource _src = new BindingSource();
        private void FormCustomer_Load(object sender, EventArgs e)
        {
            gridData.DataSource = _src;
            gridData.AllowUserToAddRows = false;
            gridData.ReadOnly = true;

            rdoMale.Checked = true;
            rdoFemale.Checked = false;
            customers = customerData.GetData();
            DisplayInGrid();
        }

        private void DisplayInGrid()
        {
            _src.DataSource = customers;
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
                MessageBox.Show("Mã khách hàng không được để trống !"
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

            Customer customer = null;

            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].Id.ToLower() == txtCode.Text.ToLower())
                {
                    customer = customers[i];
                    break;
                }
            }

            if (customer == null)
            {
                customer = new Customer();
                customers.Add(customer);
            }

            customer.Id = txtCode.Text;
            customer.PhoneNumber = txtPhone.Text;
            customer.Address = txtAddress.Text;
            customer.Name = txtName.Text;
            customer.Gender = rdoMale.Checked ? "Nam" : "Nữ";

            DisplayInGrid();

            // save data in database
            customerData.SaveData(customers);

            MessageBox.Show("Cập nhật thông tin khách hàng thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Customer customer = null;

            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].Id.ToLower() == txtCode.Text.ToLower())
                {
                    customer = customers[i];
                    break;
                }
            }

            if (customer != null)
            {
                customers.Remove(customer);
            }

            DisplayInGrid();

            customerData.SaveData(customers);


            MessageBox.Show("Xoá thông tin khách hàng thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void gridData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            Customer customer = gridData.CurrentRow.DataBoundItem as Customer;

            if (customer == null)
                return;

            Display(customer);
        }

        public void Display(Customer customer)
        {
            txtCode.Text = customer.Id;
            txtName.Text = customer.Name;
            rdoMale.Checked = customer.Gender == "Nam" ? true : false;
            rdoFemale.Checked = customer.Gender != "Nam" ? true : false;
            txtAddress.Text = customer.Address;
            txtPhone.Text = customer.PhoneNumber;
        }
    }
}
