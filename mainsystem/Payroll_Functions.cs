using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainsystem
{
    public class Payroll
    {
        // Inputs
        public double BasicPay { get; set; }
        public double Honorarium { get; set; }
        public double OtherIncome { get; set; }
        public double Absences { get; set; }
        public double Tardiness { get; set; }
        public double SSS { get; set; }
        public double PhilHealth { get; set; }
        public double Pagibig { get; set; }
        public double Tax { get; set; }
        public double Loan { get; set; }
        public double Savings { get; set; }

        // Computed values
        public double GrossIncome { get; private set; }
        public double TotalDeductions { get; private set; }
        public double NetIncome { get; private set; }

        // Compute gross income
        public void ComputeGross()
        {
            GrossIncome = BasicPay + Honorarium + OtherIncome;
        }

        // Compute total deductions
        public void ComputeDeductions()
        {
            TotalDeductions = Absences + Tardiness + SSS + PhilHealth + Pagibig + Tax + Loan + Savings;
        }

        // Compute net income
        public void ComputeNet()
        {
            NetIncome = GrossIncome - TotalDeductions;
        }
    }

}
