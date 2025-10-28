using OOP_finalProject.Employees;
using System;
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
        }

        private void StoreForm_Load(object sender, EventArgs e)
        {
            ManagerData.CreateSampleData();
            cboManager.DataSource = managerData.GetData();
            cboManager.ValueMember = "Id";
            cboManager.DisplayMember = "Name";

            if (cboManager.Items.Count > 0)
                cboManager.SelectedIndex = 0;

            Store store = storeData.GetData();
            Display(store);
        }

        private void Display(Store store)
        {
            txtId.Text = store.StoreId;
            txtName.Text = store.StoreName;
            txtAddress.Text = store.Location;

            if (store.Manager != null)
            {
                cboManager.SelectedValue = store.Manager.Id;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Mã cửa hàng không được để trống !",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Tên cửa hàng không được để trống !",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Địa chỉ cửa hàng không được để trống !",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboManager.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn quản lý !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Store store = new Store();
            store.StoreId = txtId.Text;
            store.StoreName = txtName.Text;
            store.Location = txtAddress.Text;
            store.Manager = cboManager.SelectedItem as Manager;

            storeData.SaveData(store);

            MessageBox.Show("Lưu thông tin cửa hàng thành công !"
             , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
    }
}
