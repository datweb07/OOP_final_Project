using System;

namespace OOP_finalProject.Payments
{
    public class CashPayment : Payment
    {
        public decimal ReceivedAmount { get; private set; }
        public decimal ChangeAmount
        {
            get
            {
                if (ReceivedAmount >= Amount)
                {
                    return ReceivedAmount - Amount;
                }
                return 0;
            }
        }

        public CashPayment(decimal amount, string transactionId = null) : base(amount, transactionId)
        {
            Method = PaymentMethod.CASH;
            ReceivedAmount = 0;
        }

        public bool ReceiveCash(decimal receivedAmount)
        {
            if (receivedAmount < 0)
            {
                Message = "Số tiền nhận không được âm!";
                return false;
            }

            if (receivedAmount < Amount)
            {
                Message = $"Số tiền không đủ! Cần: {Amount:N0} đ, Nhận: {receivedAmount:N0} đ";
                return false;
            }

            ReceivedAmount = receivedAmount;
            Message = $"Đã nhận: {ReceivedAmount:N0} đ, Thối lại: {ChangeAmount:N0} đ";
            return true;
        }

        public override bool ProcessPayment()
        {
            try
            {
                // Xác thực thông tin thanh toán
                if (!ValidatePayment())
                {
                    return false;
                }

                // Kiểm tra đã nhận tiền chưa
                if (ReceivedAmount < Amount)
                {
                    MarkAsFailed($"Chưa nhận đủ tiền! Cần: {Amount:N0} đ, Đã nhận: {ReceivedAmount:N0} đ");
                    return false;
                }

                // Thanh toán tiền mặt luôn thành công (nếu đã nhận đủ tiền)
                MarkAsSuccess($"Thanh toán tiền mặt thành công! Số tiền: {Amount:N0} đ, Thối lại: {ChangeAmount:N0} đ");
                return true;
            }
            catch (Exception ex)
            {
                MarkAsFailed($"Lỗi khi xử lý thanh toán: {ex.Message}");
                return false;
            }
        }

        protected override bool ValidatePayment()
        {
            if (Amount <= 0)
            {
                MarkAsFailed("Số tiền thanh toán phải lớn hơn 0!");
                return false;
            }

            if (Status == PaymentStatus.Success)
            {
                MarkAsFailed("Giao dịch này đã được thanh toán thành công!");
                return false;
            }

            return true;
        }

        public override string GetPaymentInfo()
        {
            string info = base.GetPaymentInfo();
            if (ReceivedAmount > 0)
            {
                info += $", Đã nhận: {ReceivedAmount:N0} đ";
                if (ChangeAmount > 0)
                {
                    info += $", Thối lại: {ChangeAmount:N0} đ";
                }
            }
            return info;
        }
    }
}
