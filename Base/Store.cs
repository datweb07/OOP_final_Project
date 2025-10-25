using OOP_finalProject.Base;
using OOP_finalProject.Employees;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    [Serializable]
    public class Store : ISerializable
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
                {
                    throw new ArgumentException("ID cửa hàng không được để trống hoặc rỗng!");
                }
                storeId = value;
            }
        }

        public string StoreName
        {
            get { return storeName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Tên cửa hàng không được để trống hoặc rỗng!");
                }
                storeName = value;
            }
        }

        public string Location
        {
            get { return location; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Địa điểm cửa hàng không được để trống hoặc rỗng!");
                }
                location = value;
            }
        }

        public Manager Manager
        {
            get { return manager; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Quản lý không thể rỗng!");
                }
                manager = value;
            }
        }

        public List<Cashier> Cashiers
        {
            get { return cashiers; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Danh sách thu ngân không thể rỗng!");
                }
                cashiers = value;
            }
        }

        public List<Product> Products
        {
            get { return products; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Danh sách sản phẩm không thể rỗng!");
                }
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

        public Store(SerializationInfo info, StreamingContext context)
        {
            try
            {
                StoreId = info.GetString("StoreId");
                StoreName = info.GetString("StoreName");
                Location = info.GetString("Location");
                Manager = (Manager)info.GetValue("Manager", typeof(Manager));
                Cashiers = (List<Cashier>)info.GetValue("Cashiers", typeof(List<Cashier>));
                Products = (List<Product>)info.GetValue("Products", typeof(List<Product>));
            }
            catch
            {
                StoreId = "";
                StoreName = "";
                Location = "";
                Manager = null;
                Cashiers = new List<Cashier>();
                Products = new List<Product>();
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("StoreId", StoreId);
            info.AddValue("StoreName", StoreName);
            info.AddValue("Location", Location);
            info.AddValue("Manager", Manager);
            info.AddValue("Cashiers", Cashiers);
            info.AddValue("Products", Products);
        }
    }
}
