using System;

namespace OOP_finalProject.Payments
{
    public static class PaymentFactory
    {
        public static Payment CreatePayment(
            PaymentMethod method,
            decimal amount,
            string invoiceId = null,
            string transactionId = null)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Số tiền thanh toán phải lớn hơn 0", nameof(amount));
            }

            switch (method)
            {
                case PaymentMethod.CASH:
                    return new CashPayment(amount, transactionId);
                //case PaymentMethod.CARD:
                //    return new CardPayment(amount, transactionId);
                //case PaymentMethod.QR_CODE:
                //    return new QRPayment(amount, invoiceId, transactionId);
                default:
                    throw new ArgumentException($"Phương thức thanh toán không được hỗ trợ: {method}", nameof(method));
            }
        }

        public static Payment CreatePaymentFromString(
            string methodString,
            decimal amount,
            string invoiceId = null,
            string transactionId = null)
        {
            if (string.IsNullOrWhiteSpace(methodString))
            {
                throw new ArgumentException("Phương thức thanh toán không được để trống", nameof(methodString));
            }

            // chuyển đổi chuỗi thành enum
            if (Enum.TryParse<PaymentMethod>(methodString.ToUpper(), out PaymentMethod method))
            {
                return CreatePayment(method, amount, invoiceId, transactionId);
            }

            throw new ArgumentException($"Phương thức thanh toán không hợp lệ: {methodString}", nameof(methodString));
        }

        public static string GetPaymentMethodName(PaymentMethod method)
        {
            switch (method)
            {
                case PaymentMethod.CASH:
                    return "Tiền mặt";
                case PaymentMethod.CARD:
                    return "Thẻ";
                case PaymentMethod.QR_CODE:
                    return "Quét mã QR";
                default:
                    return "Không xác định";
            }
        }

        public static PaymentMethod[] GetAllPaymentMethods()
        {
            return (PaymentMethod[])Enum.GetValues(typeof(PaymentMethod));
        }
    }
}
