using OOP_finalProject.Base;
using OOP_finalProject.Data;
using OOP_finalProject.Products;
using System;
using System.Collections.Generic;

namespace OOP_finalProject.Examples
{
    /// <summary>
    /// Demo class để minh họa cách sử dụng Composite Pattern
    /// </summary>
    public class CompositePatternDemo
    {
        /// <summary>
        /// Demo cơ bản: Tạo combo đơn giản
        /// </summary>
        public static void BasicComboDemo()
        {
            Console.WriteLine("=== DEMO: Tạo Combo Cơ Bản ===\n");

            // Tạo các sản phẩm đơn lẻ
            FoodProduct banhKeo = new FoodProduct("F001", "Bánh kẹo", 50000, 2, DateTime.Now.AddMonths(6));
            DrinkProduct nuocNgot = new DrinkProduct("D001", "Coca Cola", 15000, 6);
            FoodProduct mut = new FoodProduct("F002", "Mứt dừa", 80000, 1, DateTime.Now.AddMonths(3));

            // Tạo combo
            CompositeProduct comboTet = new CompositeProduct(
                "COMBO001",
                "Combo Tết 2025",
                15, // Giảm giá 15%
                "Combo quà tết cao cấp cho gia đình"
            );

            // Thêm sản phẩm vào combo
            comboTet.Add(banhKeo);
            comboTet.Add(nuocNgot);
            comboTet.Add(mut);

            // Hiển thị thông tin
            Console.WriteLine(comboTet.Info());
            Console.WriteLine("\n" + new string('-', 50));
        }

        /// <summary>
        /// Demo nâng cao: Nested composite (combo trong combo)
        /// </summary>
        public static void NestedComboDemo()
        {
            Console.WriteLine("\n=== DEMO: Combo Lồng Nhau (Nested) ===\n");

            // Tạo combo nhỏ 1: Combo đồ ăn
            CompositeProduct comboDoAn = new CompositeProduct(
                "COMBO_FOOD",
                "Combo Đồ Ăn",
                10,
                "Combo các món ăn nhẹ"
            );
            comboDoAn.Add(new FoodProduct("F003", "Snack", 20000, 5, DateTime.Now.AddMonths(12)));
            comboDoAn.Add(new FoodProduct("F004", "Kẹo", 15000, 10, DateTime.Now.AddMonths(12)));

            // Tạo combo nhỏ 2: Combo đồ uống
            CompositeProduct comboDrink = new CompositeProduct(
                "COMBO_DRINK",
                "Combo Đồ Uống",
                5,
                "Combo nước giải khát"
            );
            comboDrink.Add(new DrinkProduct("D002", "Pepsi", 12000, 12));
            comboDrink.Add(new DrinkProduct("D003", "Sting", 10000, 6));

            // Tạo combo lớn chứa 2 combo nhỏ
            CompositeProduct comboTiec = new CompositeProduct(
                "COMBO_PARTY",
                "Combo Tiệc Lớn",
                20,
                "Combo tổ chức tiệc hoàn hảo"
            );
            comboTiec.Add(comboDoAn);    // Thêm combo đồ ăn
            comboTiec.Add(comboDrink);   // Thêm combo đồ uống
            comboTiec.Add(new HouseholdProduct("H001", "Ly nhựa", 5000, 50));

            // Hiển thị thông tin
            Console.WriteLine(comboTiec.Info());
            Console.WriteLine($"\nTổng số sản phẩm đơn lẻ trong combo: {comboTiec.GetAllLeafProducts().Count}");
            Console.WriteLine("\n" + new string('-', 50));
        }

        /// <summary>
        /// Demo tính năng: Tính giá tự động
        /// </summary>
        public static void PriceCalculationDemo()
        {
            Console.WriteLine("\n=== DEMO: Tính Giá Tự Động ===\n");

            CompositeProduct combo = new CompositeProduct("CB001", "Combo Test", 0);
            
            Console.WriteLine("Bước 1: Combo rỗng");
            Console.WriteLine($"Giá gốc: {combo.GetOriginalPrice():C}");
            Console.WriteLine($"Giá sau giảm: {combo.Price:C}\n");

            Console.WriteLine("Bước 2: Thêm sản phẩm 1 (100,000đ)");
            combo.Add(new FoodProduct("F001", "Sản phẩm 1", 100000, 1, DateTime.Now.AddMonths(6)));
            Console.WriteLine($"Giá gốc: {combo.GetOriginalPrice():C}");
            Console.WriteLine($"Giá sau giảm: {combo.Price:C}\n");

            Console.WriteLine("Bước 3: Thêm sản phẩm 2 (50,000đ x 2)");
            combo.Add(new DrinkProduct("D001", "Sản phẩm 2", 50000, 2));
            Console.WriteLine($"Giá gốc: {combo.GetOriginalPrice():C}");
            Console.WriteLine($"Giá sau giảm: {combo.Price:C}\n");

            Console.WriteLine("Bước 4: Áp dụng giảm giá 20%");
            combo.DiscountPercentage = 20;
            Console.WriteLine($"Giá gốc: {combo.GetOriginalPrice():C}");
            Console.WriteLine($"Giá sau giảm: {combo.Price:C}");
            Console.WriteLine($"Tiết kiệm: {(combo.GetOriginalPrice() - combo.Price):C}");
            Console.WriteLine("\n" + new string('-', 50));
        }

        /// <summary>
        /// Demo lưu và load dữ liệu
        /// </summary>
        public static void DataPersistenceDemo()
        {
            Console.WriteLine("\n=== DEMO: Lưu và Load Dữ Liệu ===\n");

            CompositeProductData data = new CompositeProductData();

            // Tạo combo mẫu
            CompositeProduct combo = new CompositeProduct(
                "DEMO_COMBO",
                "Combo Demo",
                15,
                "Combo để test lưu trữ"
            );
            combo.Add(new FoodProduct("F001", "Test Food", 50000, 2, DateTime.Now.AddMonths(6)));
            combo.Add(new DrinkProduct("D001", "Test Drink", 20000, 3));

            Console.WriteLine("Lưu combo vào database...");
            bool saveSuccess = data.AddCompositeProduct(combo);
            Console.WriteLine($"Kết quả: {(saveSuccess ? "Thành công" : "Thất bại")}");

            if (saveSuccess)
            {
                Console.WriteLine("\nLoad combo từ database...");
                CompositeProduct loadedCombo = data.FindById("DEMO_COMBO");
                
                if (loadedCombo != null)
                {
                    Console.WriteLine("Load thành công!");
                    Console.WriteLine($"\nThông tin combo đã load:");
                    Console.WriteLine(loadedCombo.GetDisplayInfo());
                }
                else
                {
                    Console.WriteLine("Không tìm thấy combo!");
                }
            }

            Console.WriteLine("\n" + new string('-', 50));
        }

        /// <summary>
        /// Demo so sánh: Sản phẩm đơn vs Composite
        /// </summary>
        public static void ComparisonDemo()
        {
            Console.WriteLine("\n=== DEMO: So Sánh Sản Phẩm Đơn vs Composite ===\n");

            // Sản phẩm đơn
            Product singleProduct = new FoodProduct("F001", "Bánh kẹo", 50000, 1, DateTime.Now.AddMonths(6));
            Console.WriteLine("Sản phẩm đơn:");
            Console.WriteLine($"  - IsComposite: {singleProduct.IsComposite()}");
            Console.WriteLine($"  - Số con: {singleProduct.GetChildren().Count}");
            Console.WriteLine($"  - Giá: {singleProduct.Price:C}");
            Console.WriteLine($"  - Info: {singleProduct.GetShortInfo()}");

            Console.WriteLine();

            // Composite product
            CompositeProduct composite = new CompositeProduct("CB001", "Combo Test", 10);
            composite.Add(new FoodProduct("F001", "Bánh", 30000, 2, DateTime.Now.AddMonths(6)));
            composite.Add(new DrinkProduct("D001", "Nước", 15000, 3));

            Console.WriteLine("Composite Product:");
            Console.WriteLine($"  - IsComposite: {composite.IsComposite()}");
            Console.WriteLine($"  - Số con: {composite.GetChildren().Count}");
            Console.WriteLine($"  - Giá gốc: {composite.GetOriginalPrice():C}");
            Console.WriteLine($"  - Giá sau giảm: {composite.Price:C}");
            Console.WriteLine($"  - Info: {composite.GetShortInfo()}");

            Console.WriteLine("\n" + new string('-', 50));
        }

        /// <summary>
        /// Demo tất cả các tính năng
        /// </summary>
        public static void RunAllDemos()
        {
            Console.WriteLine("╔════════════════════════════════════════════════╗");
            Console.WriteLine("║   COMPOSITE PATTERN DEMO - OOP FINAL PROJECT   ║");
            Console.WriteLine("╚════════════════════════════════════════════════╝\n");

            try
            {
                BasicComboDemo();
                NestedComboDemo();
                PriceCalculationDemo();
                ComparisonDemo();
                DataPersistenceDemo();

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
