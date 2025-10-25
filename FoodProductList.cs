using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOP_finalProject
{
    [Serializable]
    public class FoodProductList : ISerializable
    {
        private List<FoodProduct> foodProducts = new List<FoodProduct>();
        public List<FoodProduct> FoodProducts
        {
            get { return foodProducts; }
            set { foodProducts = value; }
        }
        public FoodProductList()
        {
        }
        public FoodProductList(List<FoodProduct> foodProducts)
        {
            FoodProducts = foodProducts;
        }
        public FoodProductList(SerializationInfo info, StreamingContext context)
        {
            FoodProducts = (List<FoodProduct>)info.GetValue("FoodProducts", typeof(List<FoodProduct>));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FoodProducts", FoodProducts, typeof(List<FoodProduct>));
        }
        public void AddFoodProduct(FoodProduct foodProduct)
        {
            foodProducts.Add(foodProduct);
        }
    }
}
