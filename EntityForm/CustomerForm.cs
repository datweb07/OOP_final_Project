using OOP_finalProject.Base;
using OOP_finalProject.Customers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private CustomerData customerData = new CustomerData();
        private List<Customer> customers = new List<Customer>();

        BindingSource _src = new BindingSource();
        // Thêm sự kiện cho các nút mới
        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(txtSearch.Text))
        //    {
        //        var filteredCustomers = customers.Where(c =>
        //            c.Id.ToLower().Contains(txtSearch.Text.ToLower()) ||
        //            c.Name.ToLower().Contains(txtSearch.Text.ToLower()) ||
        //            c.PhoneNumber.Contains(txtSearch.Text)).ToList();

        //        _src.DataSource = filteredCustomers;
        //        _src.ResetBindings(true);

        //        statusLabel.Text = $"Tìm thấy {filteredCustomers.Count} kết quả";
        //    }
        //    else
        //    {
        //        DisplayInGrid();
        //        statusLabel.Text = "Sẵn sàng";
        //    }
        //}

        //private void btnAddNew_Click(object sender, EventArgs e)
        //{
        //    btnRefresh_Click(null, null);
        //    txtCode.Focus();
        //    statusLabel.Text = "Nhập thông tin khách hàng mới";
        //}

        // Cập nhật FormSeller_Load
        private void FormCustomer_Load(object sender, EventArgs e)
        {
            CreateSampleData();

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
            customers = customerData.GetData();
            DisplayInGrid();

            //// Đăng ký sự kiện mới
            //btnSearch.Click += btnSearch_Click;
            //btnAddNew.Click += btnAddNew_Click;
            //txtSearch.TextChanged += (s, _) => btnSearch_Click(null, null);
        }



        //private void CreateSampleData()
        //{
        //    string filePath = Path.Combine(GetPath.path, nameof(Customer) + ".dat");
        //    if (!File.Exists(filePath))
        //    {
        //        List<Customer> customers = new List<Customer>()
        //    {
        //        new RegularCustomer("KH001", "Nguyễn Văn A", "Nam", "0901234567", "123 Lê Lợi, Q1, TP.HCM"),
        //        new VIPCustomer("KH002", "Trần Thị B", "Nữ", "0912345678", "456 Nguyễn Huệ, Q3, TP.HCM"),
        //        new RegularCustomer("KH003", "Lê Văn C", "Nam", "0923456789", "789 Trần Hưng Đạo, Q5, TP.HCM"),
        //        new VIPCustomer("KH004", "Phạm Thị D", "Nữ", "0934567890", "321 Võ Văn Tần, Q3, TP.HCM"),
        //    };

        //        using (FileStream fs = File.Create(filePath))
        //        {
        //            DataContractSerializer serializer = new DataContractSerializer(typeof(List<Customer>));
        //            serializer.WriteObject(fs, customers);
        //        }
        //    }
        //}

        private void CreateSampleData()
        {
            string filePath = Path.Combine(GetPath.path, nameof(Customer) + ".dat");
            if (!File.Exists(filePath))
            {
                List<Customer> customers = new List<Customer>()
        {
            new Customer("KH001", "Nguyễn Văn A", "Nam", "0901234567", "123 Lê Lợi, Q1, TP.HCM"),
            new Customer("KH002", "Trần Thị B", "Nữ", "0912345678", "456 Nguyễn Huệ, Q3, TP.HCM"),
            new Customer("KH003", "Lê Văn C", "Nam", "0923456789", "789 Trần Hưng Đạo, Q5, TP.HCM"),
            new Customer("KH004", "Phạm Thị D", "Nữ", "0934567890", "321 Võ Văn Tần, Q3, TP.HCM"),
        };

                // Tạo CustomerList từ List<Customer>
                CustomerList customerList = new CustomerList(customers);

                using (FileStream fs = File.Create(filePath))
                {
                    // Serialize CustomerList thay vì List<Customer>
                    NetDataContractSerializer netDataContractSerializer = new NetDataContractSerializer();
                    netDataContractSerializer.Serialize(fs, customerList);
                }
            }
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
                // Tạo customer type dựa trên radio button selection
                if (rbVIP != null && rbVIP.Checked)
                {
                    customer = new VIPCustomer(
                        txtCode.Text,
                        txtName.Text,
                        rdoMale.Checked ? "Nam" : "Nữ",
                        txtPhone.Text,
                        txtAddress.Text
                    );
                }
                else
                {
                    customer = new RegularCustomer(
                        txtCode.Text,
                        txtName.Text,
                        rdoMale.Checked ? "Nam" : "Nữ",
                        txtPhone.Text,
                        txtAddress.Text
                    );
                }
                customers.Add(customer);
            }
            else
            {
                // Update existing customer
                customer.Id = txtCode.Text;
                customer.PhoneNumber = txtPhone.Text;
                customer.Address = txtAddress.Text;
                customer.Name = txtName.Text;
                customer.Gender = rdoMale.Checked ? "Nam" : "Nữ";
            }

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
            
            // Display customer type and discount info
            if (rbVIP != null && rbRegular != null)
            {
                if (customer is VIPCustomer)
                {
                    rbVIP.Checked = true;
                    if (lblDiscountInfo != null)
                    {
                        lblDiscountInfo.Text = customer.GetDiscountInfo();
                        lblDiscountInfo.ForeColor = Color.Gold;
                    }
                }
                else if (customer is RegularCustomer)
                {
                    rbRegular.Checked = true;
                    if (lblDiscountInfo != null)
                    {
                        lblDiscountInfo.Text = customer.GetDiscountInfo();
                        lblDiscountInfo.ForeColor = Color.Blue;
                    }
                }
                else
                {
                    rbRegular.Checked = true;
                    if (lblDiscountInfo != null)
                    {
                        lblDiscountInfo.Text = "Không có giảm giá";
                        lblDiscountInfo.ForeColor = Color.Black;
                    }
                }
            }
        }
    }
}
