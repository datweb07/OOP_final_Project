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
    public class ClothingProduct : Product, ISerializable
    {
        private string size;
        public string Size { get { return size; } set { size = value; } }
        public ClothingProduct(string id, string name, decimal price, decimal quantity, string size) : base(id, name, price, quantity)
=======
    public class ClothingProduct : Product
    {
        private string size;
        public string Size { get { return size; } set { size = value; } }
        public ClothingProduct(string id, string name, decimal price, int quantity, string size) : base(id, name, price, quantity)
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        {
            Size = size;
        }
        public override string Info()
        {
            return $"Kích cỡ: {Size}";
        }
<<<<<<< HEAD

        protected ClothingProduct(SerializationInfo info, StreamingContext context)
           : base(info, context)
        {
            try
            {
                Size = info.GetString("Size");
            }
            catch (SerializationException)
            {
                // Nếu file cũ không có trường Size, set giá trị mặc định
                Size = "M";
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Size", Size);
        }
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
    }
}
