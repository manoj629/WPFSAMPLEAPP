using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfSampleApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<EmployeeDetails> empDetailsList = new List<EmployeeDetails>();
            EmployeeDetails empDetails = new EmployeeDetails();
            empDetails.Name = "Alaxendar";
            empDetails.Department = "IT";            
            empDetailsList.Add(empDetails);
            empDetails = new EmployeeDetails();
            empDetails.Name = "Bob";
            empDetails.Department = "Accounts";
            empDetailsList.Add(empDetails);
            empDetails = new EmployeeDetails();
            empDetails.Name = "Robert";
            empDetails.Department = "HR";
            empDetailsList.Add(empDetails);
            empDetails = new EmployeeDetails();
            empDetails.Name = "Steve";
            empDetails.Department = "HR";
            empDetailsList.Add(empDetails);
            EmpComboBox.ItemsSource = empDetailsList;

        }

        private void CalculateGrossSalary_Click(object sender, RoutedEventArgs e)
        {            
            if (BSalaryTextBox.Text != "")
            {
                double gross = CalGrossSalary(Convert.ToDouble(BSalaryTextBox.Text));
                GrossSalaryTextBox.Text = gross.ToString();
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

        public void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GetEmployeeDetails_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDetails selectedEmp = EmpComboBox.SelectedItem as EmployeeDetails;
            if (selectedEmp != null)
            {
                DepartmentTextBox.Text = GetEmpDepartment(selectedEmp);
                BSalaryTextBox.Text = GetEmpBasicSalary(selectedEmp.Department).ToString();
            }
        }

        public string GetEmpDepartment(EmployeeDetails emp)
        {
            return emp.Department;
        }

        public double GetEmpBasicSalary(string dept)
        {
            if (dept == "IT")
                return 1000.0;
            else if (dept == "Account")
                return 500;
            else
                return 2000;
        }

        private void EmpComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DepartmentTextBox.Text = "";
            BSalaryTextBox.Text = "";
        }
    }

    public class EmployeeDetails
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public double BSalary { get; set; }
    }
}
