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
        //private List<ComboProduct> comboProducts = new List<ComboProduct>();
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
