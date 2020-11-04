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
            repository.GetAllEmployees();           
            Console.ReadLine();
        }
    }
}
