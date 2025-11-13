using OOP_finalProject.Base;
using System;
using System.Runtime.Serialization;

namespace OOP_finalProject.Products
{
    [Serializable]
    public class ClothingProduct : Product, ISerializable
    {
        private string size;
        public string Size { get { return size; } set { size = value; } }
        public ClothingProduct(string id, string name, decimal price, decimal quantity, string size) : base(id, name, price, quantity)
        {
            Size = size;
        }
        public override string Info()
        {
            return $"Kích cỡ: {Size}";
        }

        protected ClothingProduct(SerializationInfo info, StreamingContext context)
           : base(info, context)
        {
            try
            {
                Size = info.GetString("Size");
            }
            catch (SerializationException)
            {
                // set giá trị mặc định
                Size = "M";
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Size", Size);
        }
    }
}
