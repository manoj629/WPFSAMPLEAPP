using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSampleApplication
{
    public class BusinessLogic
    {
        public double GetEmpBasicSalary(string dept)
        {
            if (dept == "IT")
                return 1000.0;
            else if (dept == "Account")
                return 500;
            else
                return 2000;
        }

        public double CalGrossSalary(double bSalary)
        {
            double grossSalary = 0.0;
            double hraFactor;
            double daFactor;
            if (bSalary > 1000)
            {
                hraFactor = 0.2;
                daFactor = 0.4;
            }
            else
            {
                hraFactor = 0.3;
                daFactor = 0.5;
            }
            double hra = hraFactor * bSalary;
            double da = daFactor * bSalary;

            grossSalary = hra + da + bSalary;
            return grossSalary;
        }
    }
}
