using OOP_finalProject.Base;
using OOP_finalProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OOP_finalProject.Employees
{
    [Serializable]
    public class Manager : Employee, ISerializable, ISalaryCalculable
    {
        private string storeName;
        private int teamSize;
        //private decimal salary;

        public string Store
        {
            get { return storeName; }
            set
            {
                storeName = value;
            }
        }

        public int TeamSize
        {
            get { return teamSize; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Số lượng nhân viên không thể âm!");
                }
                teamSize = value;
            }
        }

        //public decimal Salary
        //{
        //    get { return salary; }
        //    set
        //    {
        //        if (value < 0)
        //        {
        //            throw new ArgumentException("Tiền lương không thể âm!");
        //        }
        //        salary = value;
        //    }
        //}

        public Manager(string id, string name, string gender, string phoneNumber, string address, string store)
            : base(id, name, gender, phoneNumber, address)
        {
            Store = store;
            Role = "Manager";
            TeamSize = 0;
        }

        protected Manager(SerializationInfo info, StreamingContext context)
           : base(info, context)
        {
            try
            {
                Store = info.GetString("Store");
                TeamSize = info.GetInt32("TeamSize");
                //Salary = info.GetDecimal("Salary");
            }
            catch
            {
                Store = "";
                TeamSize = 0;
                //Salary = 0;
            }
        }

        public Manager() : base()
        {
            Role = "Manager";
        }

        public override string GetRole()
        {
            return "Manager";
        }

        public decimal HourlyRate
        {
            get { return 28000m; }
        }

        public decimal Salary
        {
            get { return DaysWorked * 8 * HourlyRate; }
        }

        public override string GetDisplayInfo()
        {
            return base.GetDisplayInfo() + $", Store: {Store}, Team Size: {TeamSize}";
        }

        //public override bool ValidateCredentials(string username, string password)
        //{
        //    return base.ValidateCredentials(username, password) &&
        //           !string.IsNullOrWhiteSpace(Store);
        //}

        //public void AddTeamMember()
        //{
        //    TeamSize++;
        //}

        //public void RemoveTeamMember()
        //{
        //    if (TeamSize > 0)
        //        TeamSize--;
        //}

        //public decimal CalculateBonus()
        //{
        //    return TeamSize * 1000m;
        //}

        // tính số lượng nhân viên bán hàng trong team dựa trên danh sách Cashier
        public int CalculateTeamSizeFromCashiers(List<Cashier> cashiers)
        {
            if (cashiers == null)
                return 0;

            int count = 0;
            foreach (Cashier cashier in cashiers)
            {
                if (cashier.ManagerName == this.Name)
                {
                    count++;
                }
            }
            return count;
        }

        // update team size từ việc tính toán
        public void UpdateTeamSizeFromCashiers(List<Cashier> cashiers)
        {
            TeamSize = CalculateTeamSizeFromCashiers(cashiers);
        }

        // Override GetObjectData to serialize Manager-specific properties
        public new void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Store", Store);
            info.AddValue("TeamSize", TeamSize);
            //info.AddValue("Salary", Salary);
        }
    }
}
