<<<<<<< HEAD
using OOP_finalProject.Base;
using OOP_finalProject.Customers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml.Serialization;
=======
﻿using System.Windows.Forms;
using System.Collections.Generic;
using OOP_finalProject.Base;
using System;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7

namespace OOP_finalProject
{
    public partial class CustomerForm : Form
    {
<<<<<<< HEAD
        private CustomerData customerData = new CustomerData();
        private List<Customer> customers = new List<Customer>();
        private BindingSource _src = new BindingSource();
=======
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
        //    Customer existingCustomer = customers.Find(c => c.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        //    if (existingCustomer != null)
        //    {
        //        existingCustomer.Name = name;
        //        existingCustomer.PhoneNumber = phone;
        //        existingCustomer.Address = address;
        //        existingCustomer.Gender = gender;
        //    }
        //    else
        //    {
        //        Customer newCustomer = new Customer(id, name, phone, address, gender);
        //        customers.Add(newCustomer);
        //    }
        //    customerData.SaveData(customers);
        //    DisplayGrid();
        //    MessageBox.Show("Lưu thông tin khách hàng thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);


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
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7

        public CustomerForm()
        {
            InitializeComponent();
<<<<<<< HEAD

            // Wire filter button events ngay trong constructor
            btnShowAll.Click += btnShowAll_Click;
            btnShowRegular.Click += btnShowRegular_Click;
            btnShowVIP.Click += btnShowVIP_Click;

            // Wire radio button events
            rbRegular.CheckedChanged += (s, e) => UpdateDiscountLabelForSelection();
            rbVIP.CheckedChanged += (s, e) => UpdateDiscountLabelForSelection();
        }

        private void FormCustomer_Load(object sender, EventArgs e)
        {
            CustomerData.CreateSampleData();

=======
        }

        private CustomerData customerData = new CustomerData();
        private List<Customer> customers = new List<Customer>();

        BindingSource _src = new BindingSource();
        private void FormCustomer_Load(object sender, EventArgs e)
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

            customers = customerData.GetData();
            DisplayInGrid();

            UpdateDiscountLabelForSelection();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                var filteredCustomers = customers.Where(c =>
                    c.Id.ToLower().Contains(txtSearch.Text.ToLower()) ||
                    c.Name.ToLower().Contains(txtSearch.Text.ToLower()) ||
                    c.PhoneNumber.Contains(txtSearch.Text)).ToList();

                _src.DataSource = filteredCustomers;
                _src.ResetBindings(true);

                statusLabel.Text = $"Tìm thấy {filteredCustomers.Count} kết quả";
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
            statusLabel.Text = "Nhập thông tin khách hàng mới";
        }

        

        #region Display Methods
=======
            rdoMale.Checked = true;
            rdoFemale.Checked = false;
            customers = customerData.GetData();
            DisplayInGrid();
        }

>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        private void DisplayInGrid()
        {
            _src.DataSource = customers;
            _src.ResetBindings(true);
        }

<<<<<<< HEAD
        private void DisplayFilteredByType(Type customerType)
        {
            List<Customer> filtered = new List<Customer>();

            foreach (Customer c in customers)
            {
                if (customerType == typeof(RegularCustomer) && c is RegularCustomer)
                {
                    filtered.Add(c);
                }
                else if (customerType == typeof(VIPCustomer) && c is VIPCustomer)
                {
                    filtered.Add(c);
                }
            }

            _src.DataSource = filtered;
            _src.ResetBindings(true);
        }

        private void UpdateDiscountLabelForSelection()
        {
            if (lblDiscountInfo == null) return;

            if (rbVIP != null && rbVIP.Checked)
            {
                lblDiscountInfo.Text = "Khách VIP: Giảm 30%";
                lblDiscountInfo.ForeColor = Color.Blue;
            }
            else
            {
                lblDiscountInfo.Text = "Khách Regular: Giảm 10%";
                lblDiscountInfo.ForeColor = Color.Blue;
            }
        }

        public void Display(Customer customer)
        {
            txtCode.Text = customer.Id;
            txtName.Text = customer.Name;
            rdoMale.Checked = customer.Gender == "Nam";
            rdoFemale.Checked = customer.Gender != "Nam";
            txtAddress.Text = customer.Address;
            txtPhone.Text = customer.PhoneNumber;

            // Display customer type and discount info
            if (customer is VIPCustomer)
            {
                rbVIP.Checked = true;
                lblDiscountInfo.Text = customer.GetDiscountInfo();
                lblDiscountInfo.ForeColor = Color.Blue;
            }
            else if (customer is RegularCustomer)
            {
                rbRegular.Checked = true;
                lblDiscountInfo.Text = customer.GetDiscountInfo();
                lblDiscountInfo.ForeColor = Color.Blue;
            }
            else
            {
                rbRegular.Checked = true;
                lblDiscountInfo.Text = "Không có giảm giá";
                lblDiscountInfo.ForeColor = Color.Black;
            }
        }
        #endregion

        #region Button Events
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            rdoMale.Checked = true;
            rdoFemale.Checked = false;
<<<<<<< HEAD
            rbRegular.Checked = true;
            UpdateDiscountLabelForSelection();

            txtSearch.Text = "";
            statusLabel.Text = "Đã làm mới dữ liệu";
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            // Validate
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Mã khách hàng không được để trống!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên khách hàng không được để trống!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhone.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddress.Focus();
=======
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
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
                return;
            }

            Customer customer = null;

<<<<<<< HEAD
            // Tìm customer có sẵn
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].Id.ToLower() == txtCode.Text.ToLower())
                {
                    customer = customers[i];
                    break;
                }
            }

<<<<<<< HEAD
            string gender = rdoMale.Checked ? "Nam" : "Nữ";

            if (customer == null)
            {
                // Tạo customer mới
                if (rbVIP.Checked)
                {
                    customer = new VIPCustomer(txtCode.Text, txtName.Text, gender, txtPhone.Text, txtAddress.Text);
                }
                else
                {
                    customer = new RegularCustomer(txtCode.Text, txtName.Text, gender, txtPhone.Text, txtAddress.Text);
                }
                customers.Add(customer);
            }
            else
            {
                // Update customer hiện tại
                customer.Name = txtName.Text;
                customer.Gender = gender;
                customer.PhoneNumber = txtPhone.Text;
                customer.Address = txtAddress.Text;

                // Nếu thay đổi loại customer, cần tạo mới
                bool needReplace = false;
                Customer newCustomer = null;

                if (rbVIP.Checked && !(customer is VIPCustomer))
                {
                    newCustomer = new VIPCustomer(customer.Id, customer.Name, customer.Gender,
                        customer.PhoneNumber, customer.Address);
                    needReplace = true;
                }
                else if (rbRegular.Checked && !(customer is RegularCustomer))
                {
                    newCustomer = new RegularCustomer(customer.Id, customer.Name, customer.Gender,
                        customer.PhoneNumber, customer.Address);
                    needReplace = true;
                }

                if (needReplace)
                {
                    int index = customers.IndexOf(customer);
                    customers[index] = newCustomer;
                }
            }

            DisplayInGrid();
            customerData.SaveData(customers);

            MessageBox.Show("Cập nhật thông tin khách hàng thành công!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
=======
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
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa khách hàng '{txtName.Text}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
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
<<<<<<< HEAD
                DisplayInGrid();
                customerData.SaveData(customers);

                MessageBox.Show("Xóa thông tin khách hàng thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnRefresh_Click(null, null);
            }
        }

        // Filter button events
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            DisplayInGrid();
        }

        private void btnShowRegular_Click(object sender, EventArgs e)
        {
            DisplayFilteredByType(typeof(RegularCustomer));
        }

        private void btnShowVIP_Click(object sender, EventArgs e)
        {
            DisplayFilteredByType(typeof(VIPCustomer));
        }
        #endregion

        #region Grid Events
=======
            }

            DisplayInGrid();

            customerData.SaveData(customers);


            MessageBox.Show("Xoá thông tin khách hàng thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        private void gridData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            Customer customer = gridData.CurrentRow.DataBoundItem as Customer;

            if (customer == null)
                return;

            Display(customer);
        }
<<<<<<< HEAD
        #endregion
    }
}
=======

        public void Display(Customer customer)
        {
            txtCode.Text = customer.Id;
            txtName.Text = customer.Name;
            rdoMale.Checked = customer.Gender == "Nam" ? true : false;
            rdoFemale.Checked = customer.Gender != "Nam" ? true : false;
            txtAddress.Text = customer.Address;
            txtPhone.Text = customer.PhoneNumber;
        }

        //public CustomerForm()
        //{
        //    InitializeComponent();
        //}

        //private CustomerData customerData = new CustomerData();
        //private List<Customer> customers = new List<Customer>();
        //private BindingSource _src = new BindingSource(); // Thêm private modifier

        //private void FormCustomer_Load(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Setup DataGridView
        //        gridData.DataSource = _src;
        //        gridData.AllowUserToAddRows = false;
        //        gridData.ReadOnly = true;
        //        gridData.AutoGenerateColumns = true; // Đảm bảo auto generate columns
        //        gridData.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Chọn cả row

        //        // Setup radio buttons
        //        rdoMale.Checked = true;
        //        rdoFemale.Checked = false;

        //        // Load data từ file
        //        LoadCustomerData();

        //        // Hiển thị dữ liệu
        //        DisplayInGrid();

        //        Console.WriteLine($"Loaded {customers.Count} customers"); // Debug log
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void LoadCustomerData()
        //{
        //    try
        //    {
        //        customers = customerData.GetData();

        //        // Nếu không có dữ liệu, tạo dữ liệu mẫu
        //        if (customers == null || customers.Count == 0)
        //        {
        //            CreateSampleData();
        //        }

        //        Console.WriteLine($"Customer count: {customers.Count}"); // Debug
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error loading data: {ex.Message}");
        //        CreateSampleData(); // Fallback to sample data
        //    }
        //}

        //private void CreateSampleData()
        //{
        //    customers = new List<Customer>
        //{
        //    new Customer("KH001", "Nguyễn Văn An", "Nam", "0901234567", "123 Lê Lợi, Q1, TP.HCM"),
        //    new Customer("KH002", "Trần Thị Bình", "Nữ", "0912345678", "456 Nguyễn Huệ, Q3, TP.HCM"),
        //    new Customer("KH003", "Phạm Văn Cường", "Nam", "0923456789", "789 Điện Biên Phủ, Q10, TP.HCM")
        //};

        //    // Lưu dữ liệu mẫu
        //    customerData.SaveData(customers);
        //    Console.WriteLine("Created sample data");
        //}

        //private void DisplayInGrid()
        //{
        //    try
        //    {
        //        _src.DataSource = null; // Clear trước
        //        _src.DataSource = customers;
        //        _src.ResetBindings(false);

        //        // Refresh DataGridView
        //        gridData.Refresh();

        //        Console.WriteLine($"DisplayInGrid: {customers.Count} items"); // Debug

        //        // Tùy chỉnh hiển thị columns (optional)
        //        if (gridData.Columns.Count > 0)
        //        {
        //            if (gridData.Columns["Id"] != null)
        //                gridData.Columns["Id"].HeaderText = "Mã KH";
        //            if (gridData.Columns["Name"] != null)
        //                gridData.Columns["Name"].HeaderText = "Tên KH";
        //            if (gridData.Columns["Gender"] != null)
        //                gridData.Columns["Gender"].HeaderText = "Giới tính";
        //            if (gridData.Columns["PhoneNumber"] != null)
        //                gridData.Columns["PhoneNumber"].HeaderText = "Số ĐT";
        //            if (gridData.Columns["Address"] != null)
        //                gridData.Columns["Address"].HeaderText = "Địa chỉ";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Lỗi hiển thị dữ liệu: {ex.Message}", "Lỗi",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void btnRefresh_Click(object sender, EventArgs e)
        //{
        //    ClearForm();
        //}

        //private void ClearForm()
        //{
        //    txtCode.Text = "";
        //    txtName.Text = "";
        //    txtPhone.Text = "";
        //    txtAddress.Text = "";
        //    rdoMale.Checked = true;
        //    rdoFemale.Checked = false;
        //}

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    // Validation
        //    if (!ValidateInput()) return;

        //    try
        //    {
        //        Customer customer = FindCustomerById(txtCode.Text);

        //        if (customer == null)
        //        {
        //            customer = new Customer();
        //            customers.Add(customer);
        //        }

        //        // Update customer data
        //        customer.Id = txtCode.Text.Trim();
        //        customer.Name = txtName.Text.Trim();
        //        customer.PhoneNumber = txtPhone.Text.Trim();
        //        customer.Address = txtAddress.Text.Trim();
        //        customer.Gender = rdoMale.Checked ? "Nam" : "Nữ";

        //        // Refresh display
        //        DisplayInGrid();

        //        // Save to file
        //        customerData.SaveData(customers);

        //        MessageBox.Show("Cập nhật thông tin khách hàng thành công!",
        //            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Lỗi khi lưu: {ex.Message}", "Lỗi",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private bool ValidateInput()
        //{
        //    if (string.IsNullOrWhiteSpace(txtCode.Text))
        //    {
        //        MessageBox.Show("Mã khách hàng không được để trống!",
        //            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txtCode.Focus();
        //        return false;
        //    }
        //    if (string.IsNullOrWhiteSpace(txtName.Text))
        //    {
        //        MessageBox.Show("Tên khách hàng không được để trống!",
        //            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txtName.Focus();
        //        return false;
        //    }
        //    if (string.IsNullOrWhiteSpace(txtPhone.Text))
        //    {
        //        MessageBox.Show("Số điện thoại không được để trống!",
        //            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txtPhone.Focus();
        //        return false;
        //    }
        //    if (string.IsNullOrWhiteSpace(txtAddress.Text))
        //    {
        //        MessageBox.Show("Địa chỉ không được để trống!",
        //            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txtAddress.Focus();
        //        return false;
        //    }
        //    return true;
        //}

        //private Customer FindCustomerById(string id)
        //{
        //    foreach (Customer customer in customers)
        //    {
        //        if (customer.Id.Equals(id, StringComparison.OrdinalIgnoreCase))
        //        {
        //            return customer;
        //        }
        //    }
        //    return null;
        //}

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(txtCode.Text))
        //    {
        //        MessageBox.Show("Vui lòng chọn khách hàng cần xóa!",
        //            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?",
        //        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        //    if (result == DialogResult.Yes)
        //    {
        //        try
        //        {
        //            Customer customer = FindCustomerById(txtCode.Text);
        //            if (customer != null)
        //            {
        //                customers.Remove(customer);
        //                DisplayInGrid();
        //                customerData.SaveData(customers);
        //                ClearForm();

        //                MessageBox.Show("Xóa thông tin khách hàng thành công!",
        //                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //            else
        //            {
        //                MessageBox.Show("Không tìm thấy khách hàng cần xóa!",
        //                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi",
        //                MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        //private void gridData_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (e.RowIndex >= 0 && e.RowIndex < gridData.Rows.Count)
        //        {
        //            DataGridViewRow row = gridData.Rows[e.RowIndex];
        //            if (row.DataBoundItem is Customer customer)
        //            {
        //                DisplayCustomer(customer);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error in CellClick: {ex.Message}");
        //    }
        //}

        //// Thay thế CellEnter bằng CellClick để dễ debug hơn
        //private void gridData_CellEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    gridData_CellClick(sender, e);
        //}

        //public void DisplayCustomer(Customer customer) // Rename method
        //{
        //    if (customer == null) return;

        //    try
        //    {
        //        txtCode.Text = customer.Id ?? "";
        //        txtName.Text = customer.Name ?? "";
        //        txtPhone.Text = customer.PhoneNumber ?? "";
        //        txtAddress.Text = customer.Address ?? "";

        //        rdoMale.Checked = customer.Gender == "Nam";
        //        rdoFemale.Checked = customer.Gender != "Nam";
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error displaying customer: {ex.Message}");
        //    }
        //}

        //// Method để reload data từ file
        //private void btnReload_Click(object sender, EventArgs e)
        //{
        //    LoadCustomerData();
        //    DisplayInGrid();
        //    ClearForm();
        //    MessageBox.Show("Đã tải lại dữ liệu từ file!", "Thông báo",
        //        MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}
    }
}
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
