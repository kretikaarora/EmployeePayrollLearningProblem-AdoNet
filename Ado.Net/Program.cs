// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeRepository.cs" company="Capgemini">
//   Copyright
// </copyright>
// <creator Name="Kretika Arora"/>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

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
            InsertingDetailsEmployeeDetailsWithEr();


        }

        /// <summary>
        /// Get All Employees
        /// calling function from main UC1
        /// </summary>
        public static void GetAllEmployees()
        {
            EmployeeRepository repository = new EmployeeRepository();
            repository.GetAllEmployees();
        }

        /// <summary>
        /// Add All Employees
        /// calling function from main UC2
        /// </summary>
        public static void AddAllEmployees()
        {
            EmployeeRepository repository = new EmployeeRepository();
            EmployeeModel model = new EmployeeModel();
            model.name = "Kretika";
            model.phoneNumber = 9650925666;
            model.address = "Pune";
            model.DepartmentName = "Hr";
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

        /// <summary>
        /// Update All Details In The Database
        /// calling function from main UC3
        /// </summary>
        public static void UpdateAllDetailsInTheDatabase()
        {
            EmployeeRepository repository = new EmployeeRepository();
            EmployeeModel model = new EmployeeModel();
            model.employeeId = 1;
            model.name = "kajal";
            model.salary = 30000;
            repository.UpdateEmployeeDetailsInTheDataBase(model);
            Console.ReadLine();
        }

        /// <summary>
        /// Get All Employees Started In DataRange
        /// calling function from main UC5
        /// </summary>
        public static void GetAllEmployeesStartedInDataRange()
        {
            EmployeeRepository repository = new EmployeeRepository();
            repository.GetAllemployeeStartedInADateRange();
        }

        /// <summary>
        /// Group All Data To Find Min Max Avg Sum()
        /// calling function from main UC6
        /// </summary>
        public static void GroupAllDataToFindMinMaxAvgSum()
        {
            EmployeeRepository repository = new EmployeeRepository();
            Console.WriteLine(repository.GroupingDataToFindMinMaxSumAverage() ? "Query Succesful for grouping data " : "Failed");
        }

        /// <summary>
        /// Inserting Details Employee Details With Er
        /// calling function from main UC7
        /// </summary>
        public static void InsertingDetailsEmployeeDetailsWithEr()
        {          
            EmployeeRepository repository = new EmployeeRepository();
            EmployeeModel model = new EmployeeModel();
            model.employeeId = 4;
            model.name = "jack";
            model.phoneNumber = 9650925660;
            model.address = "Hyderabad";
            model.gender = "M";
            model.startDate = Convert.ToDateTime("2018-01-06"); 
            model.CompanyId = 102;
            model.CompanyName = "BridgeLabs";
            model.DepartmentId = 11;
            model.DepartmentName = "Coder";
            model.PayrollId = 4;
            model.salary = 70000;
            model.taxablePay = 1000;
            model.incomeTax = 500;
            model.deductions = 500;
            model.netPay = 68000;
            Console.WriteLine(repository.ImplementingErDiagramWithMultipleTables(model) ? "Query Succesful for er diagram" : "Failed");

        }       
    }
}
