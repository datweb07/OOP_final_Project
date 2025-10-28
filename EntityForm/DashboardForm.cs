using OOP_finalProject.Data;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class DashboardForm : Form
    {
        private CustomerData customerData = new CustomerData();
        private DrinkProductData drinkProductData = new DrinkProductData();
        private FoodProductData foodProductData = new FoodProductData();
        private HouseholdProductData householdProductData = new HouseholdProductData();
        private CompositeProductData compositeProductData = new CompositeProductData();

        public DashboardForm()
        {
            // Khởi tạo form thủ công thay vì dùng InitializeComponent()
            this.Size = new Size(1000, 600);
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "DashboardForm";

            // Tạo nội dung dashboard ngay khi khởi tạo
            CreateDashboardContent();
        }

        private void CreateDashboardContent()
        {
            // Clear existing controls
            this.Controls.Clear();

            // Main container panel
            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(30)
            };

            // Welcome label
            Label welcomeLabel = new Label
            {
                Text = "CHÀO MỪNG ĐẾN VỚI HỆ THỐNG QUẢN LÝ BÁN HÀNG SIÊU THỊ",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                AutoSize = false,
                Size = new Size(800, 60),
                Location = new Point(50, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Instruction label
            Label instructionLabel = new Label
            {
                Text = "Chọn chức năng từ menu bên trái để bắt đầu làm việc",
                Font = new Font("Segoe UI", 14),
                ForeColor = Color.FromArgb(127, 140, 141),
                AutoSize = false,
                Size = new Size(600, 40),
                Location = new Point(150, 100),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Statistics panel
            Panel statsPanel = new Panel
            {
                Location = new Point(50, 180),
                Size = new Size(800, 200),
                BackColor = Color.Transparent
            };

            // Get real data counts
            int customerCount = GetCustomerCount();
            int productCount = GetProductCount();

            // Add statistics cards with real data
            AddStatsCard(statsPanel, "👥 Khách Hàng", customerCount.ToString(), Color.FromArgb(52, 152, 219), 0);
            AddStatsCard(statsPanel, "📦 Sản Phẩm", productCount.ToString(), Color.FromArgb(46, 204, 113), 200);
            AddStatsCard(statsPanel, "🛒 Đơn Hàng", "0", Color.FromArgb(241, 196, 15), 400);
            AddStatsCard(statsPanel, "💰 Doanh Thu", "0", Color.FromArgb(231, 76, 60), 600);

            // Quick actions panel
            Panel quickActionsPanel = CreateQuickActionsPanel();
            quickActionsPanel.Location = new Point(50, 400);

            // Add all controls to main panel
            mainPanel.Controls.Add(welcomeLabel);
            mainPanel.Controls.Add(instructionLabel);
            mainPanel.Controls.Add(statsPanel);
            mainPanel.Controls.Add(quickActionsPanel);

            // Add main panel to form
            this.Controls.Add(mainPanel);
        }

        private void AddStatsCard(Panel parent, string title, string value, Color color, int x)
        {
            Panel card = new Panel
            {
                Location = new Point(x, 0),
                Size = new Size(180, 120),
                BackColor = color,
                Margin = new Padding(10),
                Cursor = Cursors.Hand
            };

            // Add hover effect
            card.MouseEnter += (s, e) =>
            {
                card.BackColor = ControlPaint.Light(color, 0.2f);
            };
            card.MouseLeave += (s, e) =>
            {
                card.BackColor = color;
            };

            Label titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(10, 15),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            Label valueLabel = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(10, 45),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            card.Controls.Add(titleLabel);
            card.Controls.Add(valueLabel);
            parent.Controls.Add(card);
        }

        private Panel CreateQuickActionsPanel()
        {
            Panel quickActionsPanel = new Panel
            {
                Size = new Size(800, 150),
                BackColor = Color.Transparent
            };

            Label quickActionsTitle = new Label
            {
                Text = "🚀 Thao Tác Nhanh",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                Location = new Point(0, 0),
                AutoSize = true
            };

            // Quick action buttons
            Button btnNewOrder = CreateQuickActionButton("📝 Tạo Đơn Hàng", Color.FromArgb(52, 152, 219), 0, 40);
            Button btnViewProducts = CreateQuickActionButton("📦 Xem Sản Phẩm", Color.FromArgb(46, 204, 113), 200, 40);
            Button btnViewCustomers = CreateQuickActionButton("👥 Xem Khách Hàng", Color.FromArgb(155, 89, 182), 400, 40);
            Button btnViewInvoices = CreateQuickActionButton("📋 Xem Hóa Đơn", Color.FromArgb(230, 126, 34), 600, 40);

            quickActionsPanel.Controls.Add(quickActionsTitle);
            quickActionsPanel.Controls.Add(btnNewOrder);
            quickActionsPanel.Controls.Add(btnViewProducts);
            quickActionsPanel.Controls.Add(btnViewCustomers);
            quickActionsPanel.Controls.Add(btnViewInvoices);

            return quickActionsPanel;
        }

        private Button CreateQuickActionButton(string text, Color color, int x, int y)
        {
            Button btn = new Button
            {
                Text = text,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = color,
                Location = new Point(x, y),
                Size = new Size(180, 50),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };

            btn.FlatAppearance.BorderSize = 0;

            // Hover effects
            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = ControlPaint.Light(color, 0.2f);
            };
            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = color;
            };

            // Click events - you can customize these based on your needs
            btn.Click += (s, e) =>
            {
                MessageBox.Show($"Chức năng {text} sẽ được triển khai!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            return btn;
        }

        // Method to get customer count
        private int GetCustomerCount()
        {
            try
            {
                var customers = customerData.GetData();
                return customers?.Count ?? 0;
            }
            catch
            {
                return 0;
            }
        }

        // Method to get product count from all product types
        private int GetProductCount()
        {
            try
            {
                int count = 0;
                count += drinkProductData.GetData()?.Count ?? 0;
                count += foodProductData.GetData()?.Count ?? 0;
                count += householdProductData.GetData()?.Count ?? 0;
                count += compositeProductData.GetData()?.Count ?? 0;
                return count;
            }
            catch
            {
                return 0;
            }
        }

        // Method to refresh dashboard data
        public void RefreshDashboard()
        {
            CreateDashboardContent();
        }

        // Method to update statistics (you can call this from MainForm when data changes)
        public void UpdateStatistics(int customerCount, int productCount, int orderCount, string revenue)
        {
            // Find and update the statistics cards
            foreach (Control control in this.Controls)
            {
                if (control is Panel mainPanel)
                {
                    foreach (Control subControl in mainPanel.Controls)
                    {
                        if (subControl is Panel statsPanel && statsPanel.Location.Y == 180)
                        {
                            // Update statistics here
                            // You can implement logic to update the values
                            break;
                        }
                    }
                }
            }
        }
    }
}