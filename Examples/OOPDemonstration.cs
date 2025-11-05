using System;
using System.Collections.Generic;
using OOP_finalProject.Base;
using OOP_finalProject.Products;
using OOP_finalProject.Employees;
using OOP_finalProject.Customers;
using OOP_finalProject.Interfaces;

namespace OOP_finalProject.Examples
{
    /// <summary>
    /// This class demonstrates all 4 OOP properties:
    /// 1. ENCAPSULATION - Private fields, public properties with validation
    /// 2. INHERITANCE - Base classes and derived classes
    /// 3. POLYMORPHISM - Method overriding and interface implementation
    /// 4. ABSTRACTION - Abstract classes and interfaces
    /// </summary>
    public class OOPDemonstration
    {
        // ENCAPSULATION: Private field with controlled access
        private List<Product> products;
        private List<Employee> employees;
        private List<Customer> customers;

        public OOPDemonstration()
        {
            products = new List<Product>();
            employees = new List<Employee>();
            customers = new List<Customer>();
        }

        /// <summary>
        /// Demonstrates INHERITANCE and POLYMORPHISM
        /// Different product types inherit from Product base class
        /// Each overrides methods to provide specific behavior
        /// </summary>
        public void DemonstrateProductInheritance()
        {
            Console.WriteLine("=== INHERITANCE & POLYMORPHISM DEMONSTRATION ===");

            // Create different product types (INHERITANCE)
            Product electronicProduct = new ElectronicProduct("E001", "iPhone 15", 25000000, 10, "12 months");
            Product foodProduct = new FoodProduct("F001", "Bread", 15000, 50, DateTime.Now.AddDays(7));
            Product clothingProduct = new ClothingProduct("C001", "T-Shirt", 200000, 25, "L");

            // POLYMORPHISM: Same method call, different behavior based on actual type
            products.Add(electronicProduct);
            products.Add(foodProduct);
            products.Add(clothingProduct);

            foreach (Product product in products)
            {
                Console.WriteLine($"Product: {product.GetDisplayInfo()}");
                Console.WriteLine($"Specific Info: {product.Info()}");
                Console.WriteLine($"Total Value: {product.CalculateTotal():C}");
                Console.WriteLine($"Discount (10%): {product.CalculateDiscount(10):C}");
                Console.WriteLine("---");
            }
        }

        /// <summary>
        /// Demonstrates ABSTRACTION through interfaces
        /// All objects implement IDisplayable interface
        /// </summary>
        public void DemonstrateAbstraction()
        {
            Console.WriteLine("=== ABSTRACTION DEMONSTRATION ===");

            // Create objects that implement interfaces (ABSTRACTION)
            List<IDisplayable> displayableObjects = new List<IDisplayable>();

            displayableObjects.Add(new ElectronicProduct("E002", "Laptop", 15000000, 5, "24 months"));
            displayableObjects.Add(new Manager("M001", "John Manager", "Male", "0123456789", "123 Main St", "Sales"));
            displayableObjects.Add(new VIPCustomer("V001", "Jane VIP", "Female", "0987654321", "456 Oak Ave"));

            // ABSTRACTION: Using interface without knowing specific implementation
            foreach (IDisplayable obj in displayableObjects)
            {
                Console.WriteLine($"Display Info: {obj.GetDisplayInfo()}");
                Console.WriteLine($"Short Info: {obj.GetShortInfo()}");
                Console.WriteLine("---");
            }
        }

        /// <summary>
        /// Demonstrates ENCAPSULATION
        /// Private fields are accessed through public properties with validation
        /// </summary>
        public void DemonstrateEncapsulation()
        {
            Console.WriteLine("=== ENCAPSULATION DEMONSTRATION ===");

            try
            {
                // ENCAPSULATION: Validation through properties
                ElectronicProduct product = new ElectronicProduct("E003", "Tablet", 8000000, 15, "12 months");

                Console.WriteLine($"Product created successfully: {product.Name}");
                Console.WriteLine($"Price: {product.Price:C}");

                // Try to set invalid values (should throw exceptions)
                try
                {
                    product.Price = -1000; // This should throw an exception
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Encapsulation working: {ex.Message}");
                }

                try
                {
                    product.Name = ""; // This should throw an exception
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Encapsulation working: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Demonstrates all 4 OOP properties working together
        /// </summary>
        public void DemonstrateAllOOPProperties()
        {
            Console.WriteLine("=== ALL 4 OOP PROPERTIES WORKING TOGETHER ===");

            // Create a manager (INHERITANCE from Employee)
            Manager manager = new Manager("M002", "Alice Manager", "Female", "0111222333", "789 Pine St", "IT");

            // ENCAPSULATION: Access through properties with validation
            manager.TeamSize = 5;
            manager.Salary = 15000000;

            // POLYMORPHISM: Overridden methods provide specific behavior
            Console.WriteLine($"Manager Info: {manager.GetDisplayInfo()}");
            Console.WriteLine($"Role: {manager.GetRole()}");
            Console.WriteLine($"Bonus: {manager.CalculateBonus():C}");

            // ABSTRACTION: Using interface methods
            IDisplayable displayableManager = manager;
            Console.WriteLine($"Interface Display: {displayableManager.GetDisplayInfo()}");

            // Create products with different types (INHERITANCE)
            List<Product> productList = new List<Product>
            {
                new ElectronicProduct("E004", "Smartphone", 12000000, 8, "18 months"),
                new FoodProduct("F002", "Milk", 25000, 30, DateTime.Now.AddDays(5)),
                new ClothingProduct("C002", "Jeans", 500000, 20, "32")
            };

            // POLYMORPHISM: Same method call, different implementations
            decimal totalValue = 0;
            foreach (Product product in productList)
            {
                Console.WriteLine($"Product: {product.GetShortInfo()}");
                Console.WriteLine($"Specific Info: {product.Info()}");
                Console.WriteLine($"Total: {product.CalculateTotal():C}");
                totalValue += product.CalculateTotal();
            }

            Console.WriteLine($"Total Store Value: {totalValue:C}");
        }

        /// <summary>
        /// Demonstrates interface-based polymorphism
        /// </summary>
        public void DemonstrateInterfacePolymorphism()
        {
            Console.WriteLine("=== INTERFACE POLYMORPHISM DEMONSTRATION ===");

            // Create objects that implement ICalculable interface
            List<ICalculable> calculableObjects = new List<ICalculable>();

            calculableObjects.Add(new ElectronicProduct("E005", "Gaming PC", 25000000, 3, "36 months"));
            calculableObjects.Add(new FoodProduct("F003", "Premium Coffee", 500000, 10, DateTime.Now.AddMonths(6)));

            // POLYMORPHISM: Same interface, different implementations
            foreach (ICalculable obj in calculableObjects)
            {
                Console.WriteLine($"Object: {obj.GetType().Name}");
                Console.WriteLine($"Total: {obj.CalculateTotal():C}");
                Console.WriteLine($"Discount (15%): {obj.CalculateDiscount(15):C}");
                Console.WriteLine("---");
            }
        }
    }
}
