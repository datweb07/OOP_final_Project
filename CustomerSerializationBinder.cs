using OOP_finalProject.Base;
using OOP_finalProject.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOP_finalProject
{
    public class CustomerSerializationBinder : SerializationBinder
    {
        private readonly Dictionary<string, Type> _typeMappings = new Dictionary<string, Type>
    {
        { "OOP_finalProject.Customers.Customer", typeof(Customer) },
        { "OOP_finalProject.Customers.VIPCustomer", typeof(VIPCustomer) },
        { "OOP_finalProject.Customers.RegularCustomer", typeof(RegularCustomer) },
        { "OOP_finalProject.CustomerList", typeof(CustomerList) }
    };

        public override Type BindToType(string assemblyName, string typeName)
        {
            if (_typeMappings.ContainsKey(typeName))
                return _typeMappings[typeName];

            // Fallback: try to load the type
            return Type.GetType($"{typeName}, {assemblyName}");
        }
    }
}
