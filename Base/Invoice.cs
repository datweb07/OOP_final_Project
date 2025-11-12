using OOP_finalProject.Base;
using OOP_finalProject.Customers;
using OOP_finalProject.Employees;
using OOP_finalProject.Strategies;
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
        private List<InvoiceDetails> invoiceDetails;
        private string paymentMethod;
        private string transactionId;


        public string Id { get { return id; } set { id = value; } }


        public DateTime DateCreated { get { return dateCreated; } set { dateCreated = value; } }


        public Customer Customer
        {
            get { return customer; }
            set
            {
                customer = value;
                if (customer != null)
                {
                    RestoreCustomerDiscountStrategy(customer);
                }
            }
        }

        public Cashier Cashier { get { return cashier; } set { cashier = value; } }


        public List<InvoiceDetails> InvoiceDetails
        {
            get { return invoiceDetails ?? (invoiceDetails = new List<InvoiceDetails>()); }
            set { invoiceDetails = value; }
        }

        public string PaymentMethod { get { return paymentMethod; } set { paymentMethod = value; } }

        public string TransactionId { get { return transactionId; } set { transactionId = value; } }

        public string CashierName
        {
            get { return Cashier?.Name ?? "Không xác định"; }
        }

        public string CustomerName
        {
            get { return Customer?.Name ?? "Không xác định"; }
        }

        public string CustomerTypeDisplay
        {
            get { return Customer?.CustomerType ?? "Không xác định"; }
        }

        public decimal SumTotal
        {
            get
            {
                decimal total = 0;
                foreach (var detail in InvoiceDetails)
                {
                    total += detail.TotalPrice;
                }
                return total;
            }
        }

        public decimal DiscountPercentage
        {
            get
            {
                if (Customer != null)
                {
                    return Customer.GetDiscountPercentage();
                }
                return 0;
            }
        }

        public decimal DiscountAmount
        {
            get
            {
                if (Customer != null)
                {
                    return Customer.CalculateDiscount(SumTotal);
                }
                return 0;
            }
        }

        public decimal FinalTotal
        {
            get { return SumTotal - DiscountAmount; }
        }

        public string DiscountInfo
        {
            get
            {
                if (Customer != null)
                {
                    return Customer.GetDiscountInfo();
                }
                return "Không có giảm giá";
            }
        }

        public Invoice()
        {
            InvoiceDetails = new List<InvoiceDetails>();
            DateCreated = DateTime.Now;
        }

        public Invoice(SerializationInfo info, StreamingContext context)
        {
            // Xử lý tất cả trường hợp lỗi
            try
            {
                Id = info.GetString("Id") ?? GenerateInvoiceId();
            }
            catch
            {
                Id = GenerateInvoiceId();
            }

            try
            {
                DateCreated = info.GetDateTime("DateCreated");
            }
            catch
            {
                DateCreated = DateTime.Now;
            }

            // Xử lý Cashier
            try
            {
                Cashier = (Cashier)info.GetValue("Cashier", typeof(Cashier));
            }
            catch
            {
                try
                {
                    string cashierName = info.GetString("CashierName");
                    Cashier = CreateCashierFromName(cashierName);
                }
                catch
                {
                    Cashier = GetDefaultCashier();
                }
            }

            // Xử lý Customer
            try
            {
                Customer = (Customer)info.GetValue("Customer", typeof(Customer));
            }
            catch
            {
                Customer = CreateCustomerFromAvailableData(info);
            }

            // Đảm bảo Customer có discount strategy
            if (Customer != null)
            {
                RestoreCustomerDiscountStrategy(Customer);
            }

            // Xử lý InvoiceDetails
            try
            {
                InvoiceDetails = (List<InvoiceDetails>)info.GetValue("InvoiceDetails", typeof(List<InvoiceDetails>));
            }
            catch
            {
                InvoiceDetails = new List<InvoiceDetails>();
            }

            // Payment info (không bắt buộc)
            try
            {
                PaymentMethod = info.GetString("PaymentMethod");
            }
            catch { PaymentMethod = null; }

            try
            {
                TransactionId = info.GetString("TransactionId");
            }
            catch { TransactionId = null; }
        }

        private Customer CreateCustomerFromAvailableData(SerializationInfo info)
        {
            try
            {
                // Thử lấy Customer object trực tiếp
                Customer customer = (Customer)info.GetValue("Customer", typeof(Customer));
                if (customer != null)
                {
                    return customer;
                }
            }
            catch { }

            return GetDefaultCustomer();
        }

        private void RestoreCustomerDiscountStrategy(Customer customer)
        {
            if (customer == null)
            {
                return;
            }

            if (customer is VIPCustomer || customer.CustomerType?.Contains("VIP") == true)
            {
                customer.SetDiscountStrategy(new VIPCustomerDiscountStrategy());
            }
            else
            {
                customer.SetDiscountStrategy(new RegularCustomerDiscountStrategy());
            }
        }

        private Cashier CreateCashierFromName(string name)
        {
            return new Cashier { Name = name ?? "Nhân viên" };
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("DateCreated", DateCreated);
            info.AddValue("Cashier", Cashier);
            info.AddValue("Customer", Customer);
            info.AddValue("InvoiceDetails", InvoiceDetails);
            // Payment info (optional)
            info.AddValue("PaymentMethod", PaymentMethod);
            info.AddValue("TransactionId", TransactionId);
        }

        private string GenerateInvoiceId()
        {
            return $"HD{DateTime.Now:yyyyMMddHHmmss}";
        }

        private Cashier GetDefaultCashier()
        {
            return new Cashier { Name = "Nhân viên" };
        }

        private Customer GetDefaultCustomer()
        {
            RegularCustomer customer = new RegularCustomer
            {
                Name = "Khách lẻ",
                CustomerType = "Khách hàng thường"
            };
            customer.SetDiscountStrategy(new RegularCustomerDiscountStrategy());
            return customer;
        }
    }
}
