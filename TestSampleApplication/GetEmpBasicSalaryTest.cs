using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfSampleApplication;
using System.Collections.Generic;

namespace TestSampleApplication
{
    [TestClass]
    public class GetEmpBasicSalaryTest
    {
        [TestMethod]
        public void GetEmpBasicSalaryTestMethod()
        {


            try
            {
                WpfSampleApplication.MainWindow mainWindow = new MainWindow();
                List<string> deptList = new List<string>() { "IT", "Accounts", "HR" };
                foreach (string empDept in deptList)
                {
                    double basicActual = mainWindow.GetEmpBasicSalary(empDept);
                    double basicExpected = this.GetEmpBasicSalary(empDept);
                    Assert.AreEqual(basicExpected, basicActual, "The basic salary is not as expected.");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        private double GetEmpBasicSalary(string empDept)
        {
            if (empDept == "IT")
                return 1000.0;
            else if (empDept == "Account")
                return 500;
            else
                return 2000;
        }
    }
}
