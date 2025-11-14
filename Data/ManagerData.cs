using OOP_finalProject.Data;
using OOP_finalProject.Employees;
using System.Collections.Generic;
using System.IO;

namespace OOP_finalProject
{
    public class ManagerData : BaseDataRepository<ManagerList, Manager>
    {
        public ManagerData() : base() { }
        public override List<Manager> GetData()
        {
            ManagerList managerList = Load();
            return managerList.Managers ?? new List<Manager>();
        }
        public override void SaveData(List<Manager> managers)
        {
            ManagerList managerList = new ManagerList(managers);
            Save(managerList);
        }
        public override void CreateSampleData()
        {
            if (!File.Exists(filePath))
            {
                List<Manager> managers = new List<Manager>()
                {
                    new Manager("MG001", "Nguyễn Thị Lan", "Nữ", "0901123456", "123 Lê Lợi, Q1, TP.HCM", "Không có cửa hàng"),
                    new Manager("MG002", "Trần Văn Nam", "Nam", "0912234567", "456 Nguyễn Huệ, Q3, TP.HCM", "Không có cửa hàng"),
                };

                SaveData(managers);
            }
        }
    }
}
