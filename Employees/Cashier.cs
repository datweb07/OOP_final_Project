using OOP_finalProject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_finalProject.Employees
{
    [Serializable]
    public class Cashier : Employee
    {
        public Cashier(string id, string name, string email, string phoneNumber, string position) : base(id, name, email, phoneNumber, position)
        {
        }
    }
}
