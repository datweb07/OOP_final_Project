using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_finalProject
{
    public interface ISalaryCalculable
    {
        decimal HourlyRate { get; }
        decimal Salary { get; }
    }
}
