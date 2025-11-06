using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    [Serializable]
    public class HouseholdProductList : ISerializable
    {
        private List<HouseholdProduct> householdProducts = new List<HouseholdProduct>();
        public List<HouseholdProduct> HouseholdProducts { get { return householdProducts; } set { householdProducts = value; } }
        public HouseholdProductList()
        {
        }
        public HouseholdProductList(List<HouseholdProduct> householdProducts)
        {
            HouseholdProducts = householdProducts;
        }
        public HouseholdProductList(SerializationInfo info, StreamingContext context)
        {
            HouseholdProducts = (List<HouseholdProduct>)info.GetValue("HouseholdProducts", typeof(List<HouseholdProduct>));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("HouseholdProducts", HouseholdProducts);
        }
        public void AddHouseholdProduct(HouseholdProduct householdProduct)
        {
            householdProducts.Add(householdProduct);
        }
    }
}
