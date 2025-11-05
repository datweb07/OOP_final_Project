<<<<<<< HEAD
using OOP_finalProject.Customers;
using OOP_finalProject.Interfaces;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.Xml.Serialization;
=======
﻿using System;
using System.Runtime.Serialization;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7

namespace OOP_finalProject.Base
{
    [Serializable]
<<<<<<< HEAD
    //[XmlInclude(typeof(VIPCustomer))]
    //[XmlInclude(typeof(RegularCustomer))]
=======
    [DataContract]
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
    public class Customer : ISerializable
    {
        private string id;
        private string name;
        private string gender;
        private string phoneNumber;
        private string address;
<<<<<<< HEAD
        private string customerType;
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
        public virtual string CustomerType
        {
            get
            {
                return customerType;
            }
            set
            {
                customerType = value;
            }
        }
        public Customer() { }
=======

        [DataMember]
        public string Id { get { return id; } set { id = value; } }

        [DataMember]
        public string Name { get { return name; } set { name = value; } }

        [DataMember]
        public string Gender { get { return gender; } set { gender = value; } }

        [DataMember]
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }

        [DataMember]
        public string Address { get { return address; } set { address = value; } }


>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        public Customer(string id, string name, string gender, string phoneNumber, string address)
        {
            Id = id;
            Name = name;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Address = address;

        }
<<<<<<< HEAD
=======

        public Customer()
        {
        }

>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        public Customer(SerializationInfo info, StreamingContext context)
        {
            Id = info.GetString("Id");
            Name = info.GetString("Name");
            Gender = info.GetString("Gender");
            PhoneNumber = info.GetString("PhoneNumber");
            Address = info.GetString("Address");
<<<<<<< HEAD
            CustomerType = info.GetString("CustomerType");
        }
=======
        }

>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("Name", Name);
            info.AddValue("Gender", Gender);
            info.AddValue("PhoneNumber", PhoneNumber);
            info.AddValue("Address", Address);
<<<<<<< HEAD
            info.AddValue("CustomerType", CustomerType);
        }

        // Strategy Pattern: Discount Strategy
        private IDiscountStrategy discountStrategy;

        // thiết lập chiến lược giảm giá
        public virtual void SetDiscountStrategy(IDiscountStrategy strategy)
        {
            discountStrategy = strategy;
        }

        // lấy chiến lược giảm giá hiện tại
        public virtual IDiscountStrategy GetDiscountStrategy()
        {
            return discountStrategy;
        }

        // tính số tiền giảm giá dựa trên chiến lược
        public virtual decimal CalculateDiscount(decimal totalAmount)
        {
            if (discountStrategy == null)
            {
                return 0;
            }

            return discountStrategy.CalculateDiscount(totalAmount);
        }

        // lấy phần trăm giảm giá
        public virtual decimal GetDiscountPercentage()
        {
            if (discountStrategy == null)
            {
                return 0;
            }

            return discountStrategy.GetDiscountPercentage();
        }

        // lấy thông tin về loại giảm giá
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


//using OOP_finalProject.Customers;
//using OOP_finalProject.Interfaces;
//using System;
//using System.Runtime.Serialization;

//namespace OOP_finalProject.Base
//{
//    [Serializable]
//    public class Customer : ISerializable
//    {
//        #region Private Fields

//        private string id;
//        private string name;
//        private string gender;
//        private string phoneNumber;
//        private string address;
//        private string customerType; // ✅ Thêm field để lưu trữ

//        #endregion

//        #region Properties

//        public string Id
//        {
//            get { return id; }
//            set
//            {
//                if (string.IsNullOrWhiteSpace(value))
//                    throw new ArgumentException("ID khách hàng không được để trống!");
//                id = value;
//            }
//        }

//        public string Name
//        {
//            get { return name; }
//            set
//            {
//                if (string.IsNullOrWhiteSpace(value))
//                    throw new ArgumentException("Tên khách hàng không được để trống!");
//                name = value;
//            }
//        }

//        public string Gender
//        {
//            get { return gender; }
//            set
//            {
//                if (string.IsNullOrWhiteSpace(value))
//                    throw new ArgumentException("Giới tính không được để trống!");
//                gender = value;
//            }
//        }

//        public string PhoneNumber
//        {
//            get { return phoneNumber; }
//            set
//            {
//                if (string.IsNullOrWhiteSpace(value))
//                    throw new ArgumentException("Số điện thoại không được để trống!");
//                phoneNumber = value;
//            }
//        }

//        public string Address
//        {
//            get { return address; }
//            set
//            {
//                if (string.IsNullOrWhiteSpace(value))
//                    throw new ArgumentException("Địa chỉ không được để trống!");
//                address = value;
//            }
//        }

//        /// <summary>
//        /// ✅ FIXED: Sử dụng field với fallback logic
//        /// Ưu tiên dùng field đã lưu, nếu null thì tính toán từ type
//        /// </summary>
//        public virtual string CustomerType
//        {
//            get
//            {
//                // Nếu đã có giá trị từ deserialization, dùng nó
//                if (!string.IsNullOrEmpty(customerType))
//                    return customerType;

//                // Fallback: Tự động xác định dựa trên type
//                if (this is VIPCustomer)
//                {
//                    customerType = "VIP";
//                    return customerType;
//                }
//                if (this is RegularCustomer)
//                {
//                    customerType = "Thường";
//                    return customerType;
//                }

//                return "Không xác định";
//            }
//            protected set
//            {
//                customerType = value;
//            }
//        }

//        #endregion

//        #region Strategy Pattern - Discount

//        private IDiscountStrategy discountStrategy;

//        /// <summary>
//        /// Thiết lập chiến lược giảm giá
//        /// </summary>
//        public virtual void SetDiscountStrategy(IDiscountStrategy strategy)
//        {
//            discountStrategy = strategy;
//        }

//        /// <summary>
//        /// Lấy chiến lược giảm giá hiện tại
//        /// </summary>
//        public virtual IDiscountStrategy GetDiscountStrategy()
//        {
//            return discountStrategy;
//        }

//        /// <summary>
//        /// Tính số tiền giảm giá dựa trên chiến lược
//        /// </summary>
//        public virtual decimal CalculateDiscount(decimal totalAmount)
//        {
//            if (discountStrategy == null)
//                return 0;

//            return discountStrategy.CalculateDiscount(totalAmount);
//        }

//        /// <summary>
//        /// Lấy phần trăm giảm giá
//        /// </summary>
//        public virtual decimal GetDiscountPercentage()
//        {
//            if (discountStrategy == null)
//                return 0;

//            return discountStrategy.GetDiscountPercentage();
//        }

//        /// <summary>
//        /// Lấy thông tin về loại giảm giá
//        /// </summary>
//        public virtual string GetDiscountInfo()
//        {
//            if (discountStrategy == null)
//                return "Không có giảm giá";

//            return discountStrategy.GetDescription();
//        }

//        #endregion

//        #region Constructors

//        /// <summary>
//        /// Constructor mặc định
//        /// </summary>
//        public Customer() { }

//        /// <summary>
//        /// Constructor đầy đủ
//        /// </summary>
//        public Customer(string id, string name, string gender, string phoneNumber, string address)
//        {
//            Id = id;
//            Name = name;
//            Gender = gender;
//            PhoneNumber = phoneNumber;
//            Address = address;
//        }

//        /// <summary>
//        /// ✅ Constructor cho Deserialization - FIXED
//        /// KHÔNG đọc CustomerType vì nó là computed property
//        /// </summary>
//        protected Customer(SerializationInfo info, StreamingContext context)
//        {
//            try
//            {
//                Id = info.GetString("Id");
//                Name = info.GetString("Name");
//                Gender = info.GetString("Gender");
//                PhoneNumber = info.GetString("PhoneNumber");
//                Address = info.GetString("Address");

//                // ✅ KHÔNG đọc CustomerType vì nó được tính toán tự động
//                // CustomerType sẽ được xác định bởi type của object (VIPCustomer/RegularCustomer)
//            }
//            catch (SerializationException ex)
//            {
//                // Log lỗi nếu cần
//                Console.WriteLine($"Deserialization error: {ex.Message}");

//                // Set giá trị mặc định
//                Id = "UNKNOWN";
//                Name = "Unknown Customer";
//                Gender = "Unknown";
//                PhoneNumber = "0000000000";
//                Address = "Unknown";
//            }
//        }

//        #endregion

//        #region Serialization

//        /// <summary>
//        /// ✅ Serialization - FIXED
//        /// KHÔNG serialize CustomerType vì nó là computed property
//        /// </summary>
//        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
//        {
//            info.AddValue("Id", Id);
//            info.AddValue("Name", Name);
//            info.AddValue("Gender", Gender);
//            info.AddValue("PhoneNumber", PhoneNumber);
//            info.AddValue("Address", Address);

//            // ✅ KHÔNG serialize CustomerType
//            // Type information được lưu tự động bởi NetDataContractSerializer
//            // Khi deserialize, nó sẽ tạo đúng type (VIPCustomer/RegularCustomer)
//            // và CustomerType property sẽ tự động trả về đúng giá trị
//        }

//        #endregion

//        #region Overrides

//        public override string ToString()
//        {
//            return $"[{Id}] {Name} - {CustomerType}";
//        }

//        #endregion
//    }
//}
=======
        }
    }
}
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
