using OOP_finalProject.Data;
using OOP_finalProject.Employees;
using System.Collections.Generic;
using System.IO;

namespace OOP_finalProject
{
    public class CashierData : BaseDataRepository<CashierList, Cashier>
    {
        public CashierData() : base()
        {
        }
        public override List<Cashier> GetData()
        {
            CashierList cashierList = Load();
            return cashierList.Cashiers ?? new List<Cashier>();
        }
        public override void SaveData(List<Cashier> cashiers)
        {
            CashierList cashierList = new CashierList(cashiers);
            Save(cashierList);
        }

        public override void CreateSampleData()
        {
            if (!File.Exists(filePath))
            {
                List<Cashier> cashiers = new List<Cashier>()
            {
                new Cashier("NV001", "Nguyễn Văn A", "Nam", "0901234567", "123 Lê Lợi, Q1, TP.HCM"),
                new Cashier("NV002", "Trần Thị B", "Nữ", "0912345678", "456 Nguyễn Huệ, Q3, TP.HCM"),
            };
                SaveData(cashiers);
            }
        }
    }
}
