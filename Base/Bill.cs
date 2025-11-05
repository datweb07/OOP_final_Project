<<<<<<< HEAD
using OOP_finalProject.Base;
=======
﻿using OOP_finalProject.Base;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
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

        public Bill()
        {

        }

        public Bill(SerializationInfo info, StreamingContext context)
        {
            Id = info.GetString("Id");
            DateCreated = info.GetDateTime("DateCreated");
<<<<<<< HEAD
            Customer = (Customer)info.GetValue("Customer", typeof(Customer));
            Cashier = (Cashier)info.GetValue("Cashier", typeof(Cashier));
            BillDetails = (List<BillDetails>)info.GetValue("BillDetails", typeof(List<BillDetails>));
=======
            //Customer = (Customer)info.GetValue("Customer", typeof(Customer));
            //Cashier = (Cashier)info.GetValue("Cashier", typeof(Cashier));
            //BillDetails = (List<BillDetails>)info.GetValue("BillDetails", typeof(List<BillDetails>));
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7

            string customerName = info.GetString("CustomerName");
            string cashierName = info.GetString("CashierName");
            if (customerName != "Không xác định")
            {
                customer = new Customer { Name = customerName };
            }

            if (cashierName != "Không xác định")
            {
                cashier = new Cashier { Name = cashierName };
            }
            BillDetails = (List<BillDetails>)info.GetValue("BillDetails", typeof(List<BillDetails>));

        }

        public string Id { get { return id; } set { id = value; } }
        public DateTime DateCreated { get { return dateCreated; } set { dateCreated = value; } }
        public virtual Customer Customer { get { return customer; } set { customer = value; } }
        public virtual string CustomerName 
        { 
            get 
            { 
                if (customer == null) 
                {
                    return "Không xác định";
                }
                return customer.Name; 
            } 
        }
        public virtual Cashier Cashier { get { return cashier; } set { cashier = value; } }
        public virtual string CashierName 
        { 
            get 
            { 
                if (cashier == null)
                {
                    return "Không xác định";
                }
                return cashier.Name;
            } 
        }
        public virtual List<BillDetails> BillDetails { get { return billDetails; } set { billDetails = value; } }
<<<<<<< HEAD
        
        /// <summary>
        /// Tổng giá trị đơn hàng (chưa giảm giá)
        /// </summary>
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
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

<<<<<<< HEAD
        /// <summary>
        /// Số tiền được giảm giá (Strategy Pattern)
        /// </summary>
        public virtual decimal DiscountAmount
        {
            get
            {
                if (customer == null)
                {
                    return 0;
                }
                return customer.CalculateDiscount(TotalPrice);
            }
        }

        /// <summary>
        /// Tổng giá trị sau khi giảm giá
        /// </summary>
        public virtual decimal FinalPrice
        {
            get
            {
                return TotalPrice - DiscountAmount;
            }
        }

        /// <summary>
        /// Phần trăm giảm giá của khách hàng
        /// </summary>
        public virtual decimal DiscountPercentage
        {
            get
            {
                if (customer == null)
                {
                    return 0;
                }
                return customer.GetDiscountPercentage();
            }
        }

=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("DateCreated", DateCreated);
            info.AddValue("CustomerName", CustomerName);
            info.AddValue("CashierName", CashierName);
            info.AddValue("BillDetails", BillDetails);
            //info.AddValue("TotalPrice", TotalPrice);
        }
    }
}
