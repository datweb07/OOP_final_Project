using OOP_finalProject.Base;
using OOP_finalProject.Customers;
using OOP_finalProject.Strategies;
using System;

namespace OOP_finalProject.Examples
{
    /// <summary>
    /// Demo class để minh họa cách sử dụng Strategy Pattern cho Discount System
    /// </summary>
    public class StrategyPatternDemo
    {
        /// <summary>
        /// Demo cơ bản: So sánh giảm giá Regular vs VIP
        /// </summary>
        public static void BasicDiscountDemo()
        {
            Console.WriteLine("=== DEMO: So Sánh Giảm Giá Regular vs VIP ===\n");

            decimal orderAmount = 1000000m; // 1 triệu đồng

            // Regular Customer
            Customer regularCustomer = new RegularCustomer("REG001", "Nguyễn Văn A", "Nam", "0901234567", "Hà Nội");
            Console.WriteLine($"Khách hàng: {regularCustomer.Name}");
            Console.WriteLine($"Loại: Regular Customer");
            Console.WriteLine($"Giá trị đơn hàng: {orderAmount:C}");
            Console.WriteLine($"Phần trăm giảm giá: {regularCustomer.GetDiscountPercentage()}%");
            Console.WriteLine($"Số tiền giảm: {regularCustomer.CalculateDiscount(orderAmount):C}");
            Console.WriteLine($"Số tiền phải trả: {orderAmount - regularCustomer.CalculateDiscount(orderAmount):C}");
            Console.WriteLine();

            // VIP Customer
            Customer vipCustomer = new VIPCustomer("VIP001", "Trần Thị B", "Nữ", "0907654321", "TP.HCM");
            Console.WriteLine($"Khách hàng: {vipCustomer.Name}");
            Console.WriteLine($"Loại: VIP Customer");
            Console.WriteLine($"Giá trị đơn hàng: {orderAmount:C}");
            Console.WriteLine($"Phần trăm giảm giá: {vipCustomer.GetDiscountPercentage()}%");
            Console.WriteLine($"Số tiền giảm: {vipCustomer.CalculateDiscount(orderAmount):C}");
            Console.WriteLine($"Số tiền phải trả: {orderAmount - vipCustomer.CalculateDiscount(orderAmount):C}");
            
            Console.WriteLine("\n" + new string('-', 50));
        }

        /// <summary>
        /// Demo: Thay đổi strategy động (Dynamic Strategy Change)
        /// </summary>
        public static void DynamicStrategyChangeDemo()
        {
            Console.WriteLine("\n=== DEMO: Thay Đổi Strategy Động ===\n");

            decimal orderAmount = 500000m; // 500k

            // Tạo customer thường
            Customer customer = new Customer("C001", "Lê Văn C", "Nam", "0909999999", "Đà Nẵng");
            
            Console.WriteLine($"Khách hàng: {customer.Name}");
            Console.WriteLine($"Giá trị đơn hàng: {orderAmount:C}\n");

            // Ban đầu không có strategy
            Console.WriteLine("1. Không có chiến lược giảm giá:");
            Console.WriteLine($"   Giảm giá: {customer.CalculateDiscount(orderAmount):C}");
            Console.WriteLine($"   Phải trả: {orderAmount - customer.CalculateDiscount(orderAmount):C}\n");

            // Set strategy Regular
            customer.SetDiscountStrategy(new RegularCustomerDiscountStrategy());
            Console.WriteLine("2. Áp dụng Regular Customer Strategy (10%):");
            Console.WriteLine($"   Giảm giá: {customer.CalculateDiscount(orderAmount):C}");
            Console.WriteLine($"   Phải trả: {orderAmount - customer.CalculateDiscount(orderAmount):C}\n");

            // Thay đổi sang VIP strategy
            customer.SetDiscountStrategy(new VIPCustomerDiscountStrategy());
            Console.WriteLine("3. Nâng cấp lên VIP Customer Strategy (30%):");
            Console.WriteLine($"   Giảm giá: {customer.CalculateDiscount(orderAmount):C}");
            Console.WriteLine($"   Phải trả: {orderAmount - customer.CalculateDiscount(orderAmount):C}");

            Console.WriteLine("\n" + new string('-', 50));
        }

        /// <summary>
        /// Demo: Tích hợp với Bill
        /// </summary>
        public static void BillWithDiscountDemo()
        {
            Console.WriteLine("\n=== DEMO: Tích Hợp Discount với Bill ===\n");

            // Tạo bill với Regular Customer
            Bill billRegular = new Bill();
            billRegular.Id = "BILL001";
            billRegular.DateCreated = DateTime.Now;
            billRegular.Customer = new RegularCustomer("REG001", "Nguyễn Văn A", "Nam", "0901234567", "Hà Nội");
            
            // Thêm sản phẩm vào bill
            billRegular.BillDetails.Add(new BillDetails 
            { 
                ProductID = "P001", 
                ProductName = "Sản phẩm 1", 
                Quantity = 2, 
                UnitPrice = 250000 
            });
            billRegular.BillDetails.Add(new BillDetails 
            { 
                ProductID = "P002", 
                ProductName = "Sản phẩm 2", 
                Quantity = 1, 
                UnitPrice = 500000 
            });

            Console.WriteLine($"Bill ID: {billRegular.Id}");
            Console.WriteLine($"Khách hàng: {billRegular.CustomerName} (Regular)");
            Console.WriteLine($"Tổng giá trị: {billRegular.TotalPrice:C}");
            Console.WriteLine($"Giảm giá ({billRegular.DiscountPercentage}%): {billRegular.DiscountAmount:C}");
            Console.WriteLine($"Thành tiền: {billRegular.FinalPrice:C}");
            Console.WriteLine();

            // Tạo bill với VIP Customer
            Bill billVIP = new Bill();
            billVIP.Id = "BILL002";
            billVIP.DateCreated = DateTime.Now;
            billVIP.Customer = new VIPCustomer("VIP001", "Trần Thị B", "Nữ", "0907654321", "TP.HCM");
            
            // Thêm cùng sản phẩm
            billVIP.BillDetails.Add(new BillDetails 
            { 
                ProductID = "P001", 
                ProductName = "Sản phẩm 1", 
                Quantity = 2, 
                UnitPrice = 250000 
            });
            billVIP.BillDetails.Add(new BillDetails 
            { 
                ProductID = "P002", 
                ProductName = "Sản phẩm 2", 
                Quantity = 1, 
                UnitPrice = 500000 
            });

            Console.WriteLine($"Bill ID: {billVIP.Id}");
            Console.WriteLine($"Khách hàng: {billVIP.CustomerName} (VIP)");
            Console.WriteLine($"Tổng giá trị: {billVIP.TotalPrice:C}");
            Console.WriteLine($"Giảm giá ({billVIP.DiscountPercentage}%): {billVIP.DiscountAmount:C}");
            Console.WriteLine($"Thành tiền: {billVIP.FinalPrice:C}");
            Console.WriteLine();

            // So sánh tiết kiệm
            decimal savings = billRegular.FinalPrice - billVIP.FinalPrice;
            Console.WriteLine($"💰 VIP tiết kiệm thêm: {savings:C} so với Regular");

            Console.WriteLine("\n" + new string('-', 50));
        }

        /// <summary>
        /// Demo: Tích hợp với Invoice
        /// </summary>
        public static void InvoiceWithDiscountDemo()
        {
            Console.WriteLine("\n=== DEMO: Tích Hợp Discount với Invoice ===\n");

            Invoice invoice = new Invoice();
            invoice.Id = "INV001";
            invoice.DateCreated = DateTime.Now;
            invoice.Customer = new VIPCustomer("VIP002", "Phạm Văn D", "Nam", "0908888888", "Cần Thơ");

            // Thêm items vào invoice
            invoice.InvoiceDetails.Add(new InvoiceDetails 
            { 
                ProductID = "P003", 
                ProductName = "Laptop", 
                Quantity = 1, 
                UnitPrice = 15000000 
            });
            invoice.InvoiceDetails.Add(new InvoiceDetails 
            { 
                ProductID = "P004", 
                ProductName = "Mouse", 
                Quantity = 2, 
                UnitPrice = 200000 
            });

            Console.WriteLine($"Invoice ID: {invoice.Id}");
            Console.WriteLine($"Khách hàng: {invoice.CustomerName}");
            Console.WriteLine($"Loại khách hàng: VIP");
            Console.WriteLine($"Tổng giá trị: {invoice.SumTotal:C}");
            Console.WriteLine($"Giảm giá ({invoice.DiscountPercentage}%): {invoice.DiscountAmount:C}");
            Console.WriteLine($"Tổng thanh toán: {invoice.FinalTotal:C}");

            Console.WriteLine("\n" + new string('-', 50));
        }

        /// <summary>
        /// Demo: Tích hợp với Order
        /// </summary>
        public static void OrderWithDiscountDemo()
        {
            Console.WriteLine("\n=== DEMO: Tích Hợp Discount với Order ===\n");

            Order order = new Order();
            order.OrderId = "ORD001";
            order.OrderDate = DateTime.Now;
            order.Customer = new RegularCustomer("REG002", "Hoàng Thị E", "Nữ", "0907777777", "Huế");

            // Thêm items vào order
            order.OrderDetails.Add(new OrderDetails 
            { 
                ProductID = "P005", 
                ProductName = "Tivi", 
                Quantity = 1, 
                UnitPrice = 8000000 
            });
            order.OrderDetails.Add(new OrderDetails 
            { 
                ProductID = "P006", 
                ProductName = "Tủ lạnh", 
                Quantity = 1, 
                UnitPrice = 12000000 
            });

            Console.WriteLine($"Order ID: {order.OrderId}");
            Console.WriteLine($"Khách hàng: {order.CustomerName}");
            Console.WriteLine($"Loại khách hàng: Regular");
            Console.WriteLine($"Tổng giá trị: {order.SumTotal:C}");
            Console.WriteLine($"Giảm giá ({order.DiscountPercentage}%): {order.DiscountAmount:C}");
            Console.WriteLine($"Tổng thanh toán: {order.FinalTotal:C}");

            Console.WriteLine("\n" + new string('-', 50));
        }

        /// <summary>
        /// Demo: Bảng so sánh chi tiết
        /// </summary>
        public static void ComparisonTableDemo()
        {
            Console.WriteLine("\n=== DEMO: Bảng So Sánh Chi Tiết ===\n");

            decimal[] amounts = { 100000m, 500000m, 1000000m, 5000000m, 10000000m };

            Console.WriteLine("┌─────────────┬──────────────┬──────────────┬──────────────┬──────────────┐");
            Console.WriteLine("│ Giá trị ĐH  │ Regular (10%)│ VIP (30%)    │ Chênh lệch   │ % Tiết kiệm  │");
            Console.WriteLine("├─────────────┼──────────────┼──────────────┼──────────────┼──────────────┤");

            foreach (decimal amount in amounts)
            {
                Customer regular = new RegularCustomer();
                Customer vip = new VIPCustomer();

                decimal regularFinal = amount - regular.CalculateDiscount(amount);
                decimal vipFinal = amount - vip.CalculateDiscount(amount);
                decimal difference = regularFinal - vipFinal;
                decimal savingsPercent = (difference / amount) * 100;

                Console.WriteLine($"│ {amount,11:N0} │ {regularFinal,12:N0} │ {vipFinal,12:N0} │ {difference,12:N0} │ {savingsPercent,11:F1}% │");
            }

            Console.WriteLine("└─────────────┴──────────────┴──────────────┴──────────────┴──────────────┘");

            Console.WriteLine("\n" + new string('-', 50));
        }

        /// <summary>
        /// Chạy tất cả các demo
        /// </summary>
        public static void RunAllDemos()
        {
            Console.WriteLine("╔════════════════════════════════════════════════╗");
            Console.WriteLine("║   STRATEGY PATTERN DEMO - OOP FINAL PROJECT    ║");
            Console.WriteLine("║         Discount Strategy Implementation       ║");
            Console.WriteLine("╚════════════════════════════════════════════════╝\n");

            try
            {
                BasicDiscountDemo();
                DynamicStrategyChangeDemo();
                BillWithDiscountDemo();
                InvoiceWithDiscountDemo();
                OrderWithDiscountDemo();
                ComparisonTableDemo();

                Console.WriteLine("\n✅ Tất cả demo đã chạy thành công!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ Lỗi khi chạy demo: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }

            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("Nhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}
