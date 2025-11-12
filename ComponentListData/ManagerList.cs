using OOP_finalProject.Employees;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    [Serializable]
    public class ManagerList : ISerializable
    {
        private List<Manager> managers = new List<Manager>();

        public List<Manager> Managers { get { return managers; } set { managers = value; } }

        public ManagerList()
        {
        }

        public ManagerList(List<Manager> managers)
        {
            Managers = managers;
        }

        public ManagerList(SerializationInfo info, StreamingContext context)
        {
            Managers = (List<Manager>)info.GetValue("Managers", typeof(List<Manager>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Managers", Managers);
        }

        public void AddManager(Manager manager)
        {
            managers.Add(manager);
        }
    }
}
