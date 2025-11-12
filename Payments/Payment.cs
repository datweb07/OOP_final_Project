using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_finalProject.Payments
{
    public abstract class Payment
    {
        public PaymentMethod Method { get; protected set; }
        public decimal Amount { get; protected set; }
        public string TransactionId { get; protected set; }
        public DateTime TransactionDate { get; protected set; }
        public PaymentStatus Status { get; protected set; }
        public string Message { get; protected set; }

        protected Payment(decimal amount, string transactionId = null)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Số tiền thanh toán phải lớn hơn 0", nameof(amount));
            }

            Amount = amount;
            TransactionId = transactionId ?? GenerateTransactionId();
            TransactionDate = DateTime.Now;
            Status = PaymentStatus.Pending;
            Message = string.Empty;
        }

        public abstract bool ProcessPayment();
        protected abstract bool ValidatePayment();
        public virtual string GetPaymentInfo()
        {
            return $"Phương thức: {Method}, Số tiền: {Amount:N0} đ, Trạng thái: {Status}";
        }

        protected virtual string GenerateTransactionId()
        {
            return $"TXN{DateTime.Now:yyyyMMddHHmmss}{new Random().Next(1000, 9999)}";
        }

        protected void MarkAsSuccess(string message = "Thanh toán thành công")
        {
            Status = PaymentStatus.Success;
            Message = message;
        }

        protected void MarkAsFailed(string message = "Thanh toán thất bại")
        {
            Status = PaymentStatus.Failed;
            Message = message;
        }

        public override string ToString()
        {
            return GetPaymentInfo();
        }
    } 
}
