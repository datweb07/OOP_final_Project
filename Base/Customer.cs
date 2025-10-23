using OOP_finalProject.Interfaces;
using System;
using System.Runtime.Serialization;

namespace OOP_finalProject.Base
{
    [Serializable]
    public class Customer : ISerializable
    {
        private string id;
        private string name;
        private string gender;
        private string phoneNumber;
        private string address;
        public string Id 
        { 
            get 
            { 
                return id; 
            } 
            set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("ID khách hàng không được để trống hoặc rỗng!");
                }
                id = value; 
            } 
        }
        public string Name 
        { 
            get 
            { 
                return name; 
            } 
            set 
            { 
                if (string.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArgumentException("Tên khách hàng không được để trống hoặc rỗng!");
                }
                name = value; 
            } 
        }
        public string Gender 
        { 
            get 
            { 
                return gender; 
            } 
            set 
            { 
                if (string.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArgumentException("Giới tính khách hàng không được để trống hoặc rỗng!");
                }
                gender = value; 
            } 
        }
        public string PhoneNumber 
        { 
            get 
            { 
                return phoneNumber; 
            } 
            set 
            { 
                if (string.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArgumentException("Số điện thoại khách hàng không được để trống hoặc rỗng!");
                }
                phoneNumber = value; 
            } 
        }
        public string Address 
        { 
            get 
            { 
                return address; 
            } 
            set 
            { 
                if (string.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArgumentException("Địa chỉ khách hàng không được để trống hoặc rỗng!");
                }
                address = value; 
            } 
        }
        public Customer() { }
        public Customer(string id, string name, string gender, string phoneNumber, string address)
        {
            Id = id;
            Name = name;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Address = address;
        }
        public Customer(SerializationInfo info, StreamingContext context)
        {
            Id = info.GetString("Id");
            Name = info.GetString("Name");
            Gender = info.GetString("Gender");
            PhoneNumber = info.GetString("PhoneNumber");
            Address = info.GetString("Address");
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("Name", Name);
            info.AddValue("Gender", Gender);
            info.AddValue("PhoneNumber", PhoneNumber);
            info.AddValue("Address", Address);
        }

        // Strategy Pattern: Discount Strategy
        private IDiscountStrategy discountStrategy;

        /// <summary>
        /// Thiết lập chiến lược giảm giá cho khách hàng
        /// </summary>
        public virtual void SetDiscountStrategy(IDiscountStrategy strategy)
        {
            discountStrategy = strategy;
        }

        /// <summary>
        /// Lấy chiến lược giảm giá hiện tại
        /// </summary>
        public virtual IDiscountStrategy GetDiscountStrategy()
        {
            return discountStrategy;
        }

        /// <summary>
        /// Tính số tiền giảm giá dựa trên strategy
        /// </summary>
        public virtual decimal CalculateDiscount(decimal totalAmount)
        {
            if (discountStrategy == null)
            {
                return 0; // Không có giảm giá nếu chưa set strategy
            }

            return discountStrategy.CalculateDiscount(totalAmount);
        }

        /// <summary>
        /// Lấy phần trăm giảm giá
        /// </summary>
        public virtual decimal GetDiscountPercentage()
        {
            if (discountStrategy == null)
            {
                return 0;
            }

            return discountStrategy.GetDiscountPercentage();
        }

        /// <summary>
        /// Lấy thông tin về loại giảm giá
        /// </summary>
        public virtual string GetDiscountInfo()
        {
            if (discountStrategy == null)
            {
                return "Không có giảm giá";
            }

            return discountStrategy.GetDescription();
        }
    }
}
