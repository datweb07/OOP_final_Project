using OOP_finalProject.Base;
using System;

namespace OOP_finalProject.Employees
{
    [Serializable]
    public class Stocker : Employee
    {
        public Stocker(string id, string name, string gender, string phoneNumber, string address) : base(id, name, gender, phoneNumber, address)
        {
        }
    }
}
