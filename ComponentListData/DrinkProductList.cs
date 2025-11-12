using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    [Serializable]
    public class DrinkProductList : ISerializable
    {
        private List<DrinkProduct> drinkProducts = new List<DrinkProduct>();

        public List<DrinkProduct> DrinkProducts { get { return drinkProducts; } set { drinkProducts = value; } }

        public DrinkProductList()
        {
        }

        public DrinkProductList(List<DrinkProduct> drinkProducts)
        {
            DrinkProducts = drinkProducts;
        }

        public DrinkProductList(SerializationInfo info, StreamingContext context)
        {
            DrinkProducts = (List<DrinkProduct>)info.GetValue("DrinkProducts", typeof(List<DrinkProduct>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DrinkProducts", DrinkProducts);
        }

        public void AddDrinkProduct(DrinkProduct drinkProduct)
        {
            drinkProducts.Add(drinkProduct);
        }
    }
}
