using OOP_finalProject.Base;
using System;

namespace OOP_finalProject.Employees
{
    [Serializable]
    public class Cashier : Employee
    {
        public Cashier(string id, string name, string gender, string phoneNumber, string address) : base(id, name, gender, phoneNumber, address)
        {
        }
    }
}
