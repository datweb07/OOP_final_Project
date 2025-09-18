using OOP_finalProject.Base;
using OOP_finalProject.Employees;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    [Serializable]
    public class Bill : ISerializable
    {
        private string id;
        private DateTime dateCreated;
        private Customer customer;
        private Cashier cashier;
        private List<BillDetails> billDetails = new List<BillDetails>();

        public string Id { get { return id; } set { id = value; } }
        public DateTime DateCreated { get { return dateCreated; } set { dateCreated = value; } }
        public virtual Customer Customer { get { return customer; } set { customer = value; } }
        public virtual string CustomerName { get { 
                if (customer == null) 
                    return "Không xác định";
                return customer.Name; } }
        public virtual Cashier Cashier { get { return cashier; } set { cashier = value; } }
        public virtual string CashierName { get { 
                if (cashier == null) 
                    return "Không xác định";
                return cashier.Name; } }
        public virtual List<BillDetails> BillDetails { get { return billDetails; } set { billDetails = value; } }
        public virtual decimal TotalPrice
        {
            get
            {
                decimal total = 0;
                foreach (BillDetails detail in billDetails)
                {
                    total += detail.TotalPrice;
                }
                return total;
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("DateCreated", DateCreated);
            //info.AddValue("Customer", Customer);
            //info.AddValue("Cashier", Cashier);
            info.AddValue("CustomerName", CustomerName);
            info.AddValue("CashierName", CashierName);
            info.AddValue("BillDetails", BillDetails);
            info.AddValue("TotalPrice", TotalPrice);
        }

        //public Bill(SerializationInfo info, StreamingContext context)
        //{
        //    Id = info.GetString("Id");
        //    DateCreated = info.GetDateTime("DateCreated");
        //    Customer = info.GetValue("Customer");
        //}
    }
}
