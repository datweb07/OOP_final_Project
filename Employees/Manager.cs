using OOP_finalProject.Base;
using System;

namespace OOP_finalProject.Employees
{
    [Serializable]
    public class Manager : Employee
    {
        private string store;
        private int teamSize;
        private decimal salary;

        public string Store
        {
            get { return store; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Cửa hàng không thể để trống hoặc rỗng!");
                store = value;
            }
        }

        public int TeamSize
        {
            get { return teamSize; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Số lượng nhân viên không thể âm!");
                teamSize = value;
            }
        }

        public decimal Salary
        {
            get { return salary; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Tiền lương không thể âm!");
                salary = value;
            }
        }

        public Manager(string id, string name, string gender, string phoneNumber, string address, string store)
            : base(id, name, gender, phoneNumber, address)
        {
            Store = store;
            Role = "Manager";
            TeamSize = 0;
        }

        public Manager() : base()
        {
            Role = "Manager";
        }

        public override string GetRole()
        {
            return "Manager";
        }

        public override string GetDisplayInfo()
        {
            return base.GetDisplayInfo() + $", Store: {Store}, Team Size: {TeamSize}";
        }

        public override bool ValidateCredentials(string username, string password)
        {
            return base.ValidateCredentials(username, password) &&
                   !string.IsNullOrWhiteSpace(Store);
        }

        public void AddTeamMember()
        {
            TeamSize++;
        }

        public void RemoveTeamMember()
        {
            if (TeamSize > 0)
                TeamSize--;
        }

        public decimal CalculateBonus()
        {
            return TeamSize * 1000m;
        }
    }
}
