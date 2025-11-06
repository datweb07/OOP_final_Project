using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    [Serializable]
    public class ClothingProductList : ISerializable
    {
        private List<Products.ClothingProduct> clothingProducts = new List<Products.ClothingProduct>();
        public List<Products.ClothingProduct> ClothingProducts { get { return clothingProducts; } set { clothingProducts = value; } }
        public ClothingProductList()
        {
        }
        public ClothingProductList(List<Products.ClothingProduct> clothingProducts)
        {
            ClothingProducts = clothingProducts;
        }
        public ClothingProductList(SerializationInfo info, StreamingContext context)
        {
            ClothingProducts = (List<Products.ClothingProduct>)info.GetValue("ClothingProducts", typeof(List<Products.ClothingProduct>));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ClothingProducts", ClothingProducts);
        }
        public void AddClothingProduct(Products.ClothingProduct clothingProduct)
        {
            clothingProducts.Add(clothingProduct);
        }
    }
}
