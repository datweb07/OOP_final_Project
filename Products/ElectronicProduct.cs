using OOP_finalProject.Base;
using System;
<<<<<<< HEAD
using System.Runtime.Serialization;
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7

namespace OOP_finalProject.Products
{
    [Serializable]
<<<<<<< HEAD
    public class ElectronicProduct : Product, ISerializable
    {
        private string warrantyPeriod;

        public string WarrantyPeriod
        {
            get { return warrantyPeriod; }
            set
            {
                //if (string.IsNullOrWhiteSpace(value))
                //    throw new ArgumentException("Thời gian bảo hành không được để trống");
                warrantyPeriod = value;
            }
        }

        public ElectronicProduct(string id, string name, decimal price, decimal quantity, string warrantyPeriod) : base(id, name, price, quantity)
        {
            WarrantyPeriod = warrantyPeriod;
        }

        protected ElectronicProduct(SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
            try
            {
                WarrantyPeriod = info.GetString("WarrantyPeriod");
            }
            catch (SerializationException)
            {
                // Nếu file cũ không có trường WarrantyPeriod, set giá trị mặc định
                WarrantyPeriod = "12 months";
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("WarrantyPeriod", WarrantyPeriod);
        }

=======
    public class ElectronicProduct : Product
    {
        private string warrantyPeriod;
        public string WarrantyPeriod { get { return warrantyPeriod; } set { warrantyPeriod = value; } }
        public ElectronicProduct(string id, string name, decimal price, int quantity, string warrantyPeriod) : base(id, name, price, quantity)
        {
            WarrantyPeriod = warrantyPeriod;
        }
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        public override string Info()
        {
            return $"Thời gian bảo hành: {WarrantyPeriod}";
        }
<<<<<<< HEAD

        public override string GetDisplayInfo()
        {
            return base.GetDisplayInfo() + $", Warranty: {WarrantyPeriod}";
        }

        public override decimal CalculateTotal()
        {
            decimal baseTotal = base.CalculateTotal();
            decimal warrantyCost = Price * 0.05m; 
            return baseTotal + warrantyCost;
        }

        public override decimal CalculateDiscount(decimal discountPercentage)
        {
            if (discountPercentage > 20)
                discountPercentage = 20; 

            return base.CalculateDiscount(discountPercentage);
        }
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
    }
}
