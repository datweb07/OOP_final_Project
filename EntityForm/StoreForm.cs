using OOP_finalProject.Employees;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class StoreForm : Form
    {
        public StoreForm()
        {
            InitializeComponent();
        }

        private StoreData storeData = new StoreData();
        private ManagerData managerData = new ManagerData();
        private List<Manager> managers = new List<Manager>();

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            if (cboManager.Items.Count > 0)
                cboManager.SelectedIndex = 0;

            lblStatus.Text = "Đã làm mới dữ liệu";
            lblStatus.ForeColor = Color.FromArgb(52, 152, 219);
        }

        private void StoreForm_Load(object sender, EventArgs e)
        {
            try
            {
                ManagerData.CreateSampleData();

                // lấy danh sách quản lý
                managers = managerData.GetData();

                if (managers == null || managers.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu quản lý. Vui lòng thêm quản lý trước!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblStatus.Text = "Không có dữ liệu quản lý";
                    lblStatus.ForeColor = Color.FromArgb(231, 76, 60);
                    return;
                }

                // gán dữ liệu vào combobox
                cboManager.DataSource = managers;
                cboManager.ValueMember = "Id";
                cboManager.DisplayMember = "Name";

                if (cboManager.Items.Count > 0)
                    cboManager.SelectedIndex = 0;

                // lấy thông tin cửa hàng
                Store store = storeData.GetData();
                Display(store);

                lblStatus.Text = "Đã tải dữ liệu thành công";
                lblStatus.ForeColor = Color.FromArgb(46, 204, 113);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Lỗi khi tải dữ liệu";
                lblStatus.ForeColor = Color.FromArgb(231, 76, 60);
            }
        }

        private void Display(Store store)
        {
            txtId.Text = store.StoreId;
            txtName.Text = store.StoreName;
            txtAddress.Text = store.Location;

            if (!string.IsNullOrEmpty(store.ManagerId))
            {
                // Tìm quản lý 
                for (int i = 0; i < managers.Count; i++)
                {
                    if (managers[i].Id == store.ManagerId)
                    {
                        cboManager.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Mã cửa hàng không được để trống!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtId.Focus();
                lblStatus.Text = "Lỗi: Mã cửa hàng trống";
                lblStatus.ForeColor = Color.FromArgb(231, 76, 60);
                return;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Tên cửa hàng không được để trống!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                lblStatus.Text = "Lỗi: Tên cửa hàng trống";
                lblStatus.ForeColor = Color.FromArgb(231, 76, 60);
                return;
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddress.Focus();
                lblStatus.Text = "Lỗi: Địa chỉ trống";
                lblStatus.ForeColor = Color.FromArgb(231, 76, 60);
                return;
            }

            if (cboManager.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn quản lý!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Lỗi: Chưa chọn quản lý";
                lblStatus.ForeColor = Color.FromArgb(231, 76, 60);
                return;
            }

            try
            {
                // lấy thông tin quản lý được chọn
                Manager selectedManager = (Manager)cboManager.SelectedItem;

                // tạo cửa hàng mới
                Store store = new Store();
                store.StoreId = txtId.Text;
                store.StoreName = txtName.Text;
                store.Location = txtAddress.Text;
                store.ManagerId = selectedManager.Id;

                storeData.SaveData(store);

                // cập nhật storeName cho managerName
                selectedManager.Store = store.StoreName;
                managerData.SaveData(managers);

                MessageBox.Show("Lưu thông tin cửa hàng thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblStatus.Text = "Đã lưu thông tin cửa hàng thành công";
                lblStatus.ForeColor = Color.FromArgb(46, 204, 113);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu thông tin cửa hàng: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Lỗi khi lưu thông tin";
                lblStatus.ForeColor = Color.FromArgb(231, 76, 60);
            }
        }
    }
}