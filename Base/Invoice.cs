using OOP_finalProject.Base;
using OOP_finalProject.Employees;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    [Serializable]
    public class Invoice : ISerializable
    {
        private string id;
        private DateTime dateCreated;
        private Customer customer;
        private Cashier cashier;
        private List<InvoiceDetails> invoiceDetails = new List<InvoiceDetails>();

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
        public virtual List<InvoiceDetails> InvoiceDetails { get { return invoiceDetails; } set { invoiceDetails = value; } }
        public virtual decimal SumTotal
        {
            get
            {
                decimal total = 0;
                foreach (InvoiceDetails detail in invoiceDetails)
                {
                    total += detail.TotalPrice;
                }
                return total;
            }
        }

        public Invoice()
        {
        }

        public Invoice(SerializationInfo info, StreamingContext context)
        {
            Id = info.GetString("Id");
            DateCreated = info.GetDateTime("DateCreated");

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

            InvoiceDetails = (List<InvoiceDetails>)info.GetValue("InvoiceDetails", typeof(List<InvoiceDetails>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("DateCreated", DateCreated);
            info.AddValue("CustomerName", CustomerName);
            info.AddValue("CashierName", CashierName);
            info.AddValue("InvoiceDetails", InvoiceDetails);
        }
    }
}
