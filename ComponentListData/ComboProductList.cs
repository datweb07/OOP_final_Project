//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.Serialization;
//using System.Text;
//using System.Threading.Tasks;

//namespace OOP_finalProject
//{
//    [Serializable]
//    public class ComboProductList : ISerializable
//    {
//        //private List<ComboProduct> comboProducts = new List<ComboProduct>();
//        public void GetObjectData(SerializationInfo info, StreamingContext context)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}

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
    public class ComboProductList : ISerializable
    {
        private List<ComboProduct> comboProducts = new List<ComboProduct>();

        public List<ComboProduct> ComboProducts
        {
            get { return comboProducts; }
            set { comboProducts = value; }
        }

        public ComboProductList()
        {
        }

        public ComboProductList(List<ComboProduct> comboProducts)
        {
            ComboProducts = comboProducts;
        }

        public ComboProductList(SerializationInfo info, StreamingContext context)
        {
            ComboProducts = (List<ComboProduct>)info.GetValue("ComboProduct", typeof(List<ComboProduct>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ComboProduct", ComboProducts, typeof(List<ComboProduct>));
        }

        public void AddComboProduct(ComboProduct comboProduct)
        {
            comboProducts.Add(comboProduct);
        }

        public bool RemoveComboProduct(string id)
        {
            var product = comboProducts.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                comboProducts.Remove(product);
                return true;
            }
            return false;
        }

        public ComboProduct FindComboProduct(string id)
        {
            return comboProducts.FirstOrDefault(p => p.Id == id);
        }
    }
}