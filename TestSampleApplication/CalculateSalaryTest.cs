using System;
using WpfSampleApplication;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestSampleApplication
{
    [TestFixture]
    public class CalculateSalaryTest
    {
        [TestCase]
        public void CalculateSalaryTestMethod()
        {
            try
            {
                BusinessLogic bLogicObj = new BusinessLogic();
                List<double> empBSalaryList = new List<double>() { 800, 1200, 2500 };
                foreach (double empBSalary in empBSalaryList)
                {
                    double grossActual = bLogicObj.CalGrossSalary(empBSalary);
                    double grossExpected = this.CalGrossSalary(empBSalary);
                    Assert.AreEqual(grossExpected, grossActual, "The gross salary is not as expected.");
                }
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            
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
