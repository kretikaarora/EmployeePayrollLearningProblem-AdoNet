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
            EmployeeRepository repository = new EmployeeRepository();           
            Console.WriteLine(repository.GroupingDataToFindMinMaxSumAverage() ? "Query Succesful for grouping data " : "Failed");
        }
    }
}
