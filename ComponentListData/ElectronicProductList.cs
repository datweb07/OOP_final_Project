using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    [Serializable]
    public class ElectronicProductList : ISerializable
    {
        private List<ElectronicProduct> electronicProducts = new List<ElectronicProduct>();
        public List<ElectronicProduct> ElectronicProducts { get { return electronicProducts; } set { electronicProducts = value; } }
        public ElectronicProductList()
        {
        }
        public ElectronicProductList(List<ElectronicProduct> electronicProducts)
        {
            ElectronicProducts = electronicProducts;
        }
        public ElectronicProductList(SerializationInfo info, StreamingContext context)
        {
            ElectronicProducts = (List<ElectronicProduct>)info.GetValue("ElectronicProducts", typeof(List<ElectronicProduct>));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ElectronicProducts", ElectronicProducts);
        }
        public void AddElectronicProduct(ElectronicProduct product)
        {
            ElectronicProducts.Add(product);
        }
    }
}
