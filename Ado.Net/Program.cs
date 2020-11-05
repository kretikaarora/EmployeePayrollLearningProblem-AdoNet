// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeRepository.cs" company="Capgemini">
//   Copyright
// </copyright>
// <creator Name="Kretika Arora"/>
// --------------------------------------------------------------------------------------------------------------------
using System;

namespace Ado.Net
{
    /// <summary>
    /// Program Class
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Employee Payroll services");
            EmployeeRepository repository = new EmployeeRepository();
            EmployeeModel model = new EmployeeModel();
            model.name = "Kretika";
            model.phoneNumber = 9650925666;
            model.address = "Pune";
            model.department = "Hr";
            model.gender = "F";
            model.startDate = DateTime.Now;
            model.salary = 60000;
            model.deductions = 1000;
            model.taxablePay = 500;
            model.incomeTax = 500;
            model.netPay = 58000;
            Console.WriteLine(repository.AddEmployee(model) ? "Record inserted successfully " : "Failed");
            Console.ReadLine();
        }
    }
}
