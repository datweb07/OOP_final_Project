using OOP_finalProject.Base;
using System;
using System.Runtime.Serialization;

namespace OOP_finalProject.Products
{
    [Serializable]
    public class DrinkProduct : Product, ISerializable
    {
        private bool carbonated;
        public bool Carbonated { get { return carbonated; } set { carbonated = value; } }
        public DrinkProduct(string id, string name, decimal price, decimal quantity, bool carbonated) : base(id, name, price, quantity)
        {
            Carbonated = carbonated;
        }
        public override string Info()
        {
            return $"Có gas: {Carbonated}";
        }
        protected DrinkProduct(SerializationInfo info, StreamingContext context)
           : base(info, context)
        {
            try
            {
                Carbonated = info.GetBoolean("Carbonated");
            }
            catch (SerializationException)
            {
                // set giá trị mặc định
                Carbonated = false;
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Carbonated", Carbonated);
        }
    }
}
