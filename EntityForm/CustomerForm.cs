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

namespace OOP_finalProject
{
    public partial class CustomerForm : Form
    {
        private CustomerData customerData = new CustomerData();
        private List<Customer> customers = new List<Customer>();
        private BindingSource _src = new BindingSource();

        public CustomerForm()
        {
            InitializeComponent();

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

            // Cấu hình để gridData rộng hết cỡ
            gridData.Dock = DockStyle.Fill; // Quan trọng: Fill toàn bộ container
            gridData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Các cột tự động fill
            gridData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Tự động điều chỉnh chiều cao hàng

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

        private void CreateSampleData()
        {
            string filePath = Path.Combine(GetPath.path, nameof(Customer) + ".dat");
            if (!File.Exists(filePath))
            {
                List<Customer> sampleCustomers = new List<Customer>()
                    {
                        new RegularCustomer("KH001", "Nguyễn Văn An", "Nam", "0901234567", "123 Lê Lợi, Quận 1, TP.HCM"),
                        new RegularCustomer("KH002", "Trần Thị Bình", "Nữ", "0912345678", "45 Nguyễn Huệ, Quận 1, TP.HCM"),
                        new RegularCustomer("KH003", "Lê Văn Cường", "Nam", "0923456789", "78 Trần Hưng Đạo, Quận 5, TP.HCM"),
                        new RegularCustomer("KH004", "Phạm Thị Dung", "Nữ", "0934567890", "321 Võ Văn Tần, Quận 3, TP.HCM"),
                        new RegularCustomer("KH005", "Hoàng Văn Em", "Nam", "0945678901", "56 Cách Mạng Tháng 8, Quận 3, TP.HCM"),
                        new VIPCustomer("KH006", "Trương Thị Hương", "Nữ", "0956789012", "12 Hai Bà Trưng, Quận 1, TP.HCM"),
                        new VIPCustomer("KH007", "Võ Văn Giang", "Nam", "0967890123", "234 Pasteur, Quận 3, TP.HCM"),
                        new VIPCustomer("KH008", "Đặng Thị Hoa", "Nữ", "0978901234", "67 Lý Tự Trọng, Quận 1, TP.HCM"),
                        new VIPCustomer("KH009", "Bùi Văn Hùng", "Nam", "0989012345", "89 Nguyễn Đình Chiểu, Quận 3, TP.HCM"),
                        new VIPCustomer("KH010", "Lý Thị Kim", "Nữ", "0990123456", "101 Nam Kỳ Khởi Nghĩa, Quận 1, TP.HCM"),
                    };

                CustomerList customerList = new CustomerList(sampleCustomers);

                using (FileStream fs = File.Create(filePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(CustomerList), new Type[] { typeof(VIPCustomer), typeof(RegularCustomer) });
                    serializer.Serialize(fs, customerList);
                }
            }
        }

        #region Display Methods
        private void DisplayInGrid()
        {
            _src.DataSource = customers;
            _src.ResetBindings(true);
        }

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
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            rdoMale.Checked = true;
            rdoFemale.Checked = false;
            rbRegular.Checked = true;
            UpdateDiscountLabelForSelection();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
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
                return;
            }

            Customer customer = null;

            // Tìm customer có sẵn
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].Id.ToLower() == txtCode.Text.ToLower())
                {
                    customer = customers[i];
                    break;
                }
            }

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
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
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
        private void gridData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            Customer customer = gridData.CurrentRow.DataBoundItem as Customer;

            if (customer == null)
                return;

            Display(customer);
        }
        #endregion
    }
}