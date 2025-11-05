using OOP_finalProject.Base;
using OOP_finalProject.Employees;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace OOP_finalProject
{
    [Serializable]
    public class Store : ISerializable
    {
        private string storeId;
        private string storeName;
        private string location;
        private string managerId; 
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

        public string ManagerId
        {
            get { return managerId; }
            set { managerId = value; }
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

        public Store(string storeId, string storeName, string location, string managerId)
        {
            StoreId = storeId;
            StoreName = storeName;
            Location = location;
            ManagerId = managerId;
            Cashiers = new List<Cashier>();
            Products = new List<Product>();
        }

        public Store()
        {
            Cashiers = new List<Cashier>();
            Products = new List<Product>();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            
            info.AddValue("StoreId", StoreId);
            info.AddValue("StoreName", StoreName);
            info.AddValue("Location", Location);
            info.AddValue("ManagerId", ManagerId);
            info.AddValue("Cashiers", Cashiers);
            info.AddValue("Products", Products);
        }

        public Store(SerializationInfo info, StreamingContext context)
        {
            try
            {
                StoreId = info.GetString("StoreId");
                StoreName = info.GetString("StoreName");
                Location = info.GetString("Location");
                ManagerId = info.GetString("ManagerId");
                Cashiers = (List<Cashier>)info.GetValue("Cashiers", typeof(List<Cashier>));
                Products = (List<Product>)info.GetValue("Products", typeof(List<Product>));
            }
            catch
            {
                StoreId = "";
                StoreName = "";
                Location = "";
                ManagerId = "";
                Cashiers = new List<Cashier>();
                Products = new List<Product>();
            }
        }
    }
}
