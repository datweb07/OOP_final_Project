using OOP_finalProject.Base;
using OOP_finalProject.Employees;
using System;
using System.Collections.Generic;

namespace OOP_finalProject
{
    [Serializable]
    public class Store
    {
        private string storeId;
        private string storeName;
        private string location;
        private Manager manager;
        private List<Cashier> cashiers;
        private List<Product> products;

        public string StoreId
        {
            get { return storeId; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Store ID cannot be null or empty");
                storeId = value;
            }
        }

        public string StoreName
        {
            get { return storeName; } 
            set 
            { 
                if (string.IsNullOrWhiteSpace(value)) 
                    throw new ArgumentException("Store name cannot be null or empty"); 
                storeName = value;
            }
        }

        public string Location
        {
            get { return location; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Location cannot be null or empty");
                location = value;
            }
        }

        public Manager Manager
        {
            get { return manager; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Manager cannot be null");
                manager = value;
            }
        }

        public List<Cashier> Cashiers
        {
            get { return cashiers; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Cashiers list cannot be null");
                cashiers = value;
            }
        }

        public List<Product> Products
        {
            get { return products; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Products list cannot be null");
                products = value;
            }
        }

        public Store(string storeId, string storeName, string location, Manager manager)
        {
            StoreId = storeId;
            StoreName = storeName;
            Location = location;
            Manager = manager;
            Cashiers = new List<Cashier>();
            Products = new List<Product>();
        }

        public Store()
        {
        
        }
    }
}
