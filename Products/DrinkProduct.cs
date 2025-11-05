<<<<<<< HEAD
using OOP_finalProject.Base;
using System;
using System.Runtime.Serialization;
=======
﻿using OOP_finalProject.Base;
using System;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7

namespace OOP_finalProject.Products
{
    [Serializable]
<<<<<<< HEAD
    public class DrinkProduct : Product, ISerializable
=======
    public class DrinkProduct : Product
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
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
<<<<<<< HEAD
        protected DrinkProduct(SerializationInfo info, StreamingContext context)
           : base(info, context)
        {
            try
            {
                Carbonated = info.GetBoolean("Carbonated");
            }
            catch (SerializationException)
            {
                // Nếu file cũ không có trường Carbonated, set giá trị mặc định
                Carbonated = false;
            }
        }

        public new void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Carbonated", Carbonated);
        }
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
    }
}
