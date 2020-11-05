// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeModel.cs" company="Capgemini">
//   Copyright
// </copyright>
// <creator Name="Kretika Arora"/>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace Ado.Net
{

   /// <summary>
   /// Employee Model 
   /// </summary>
    public class EmployeeModel
    {        
        public string name { get; set; }
        public int  employeeId { get; set; }     
        public decimal phoneNumber { get; set; }
        public string address { get; set; }       
        public string gender { get; set; }
        public decimal salary { get; set; }
        public decimal deductions { get; set; }
        public decimal taxablePay { get; set; }      
        public decimal netPay { get; set; }
        public decimal incomeTax { get; set; }
        public DateTime startDate { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int PayrollId { get; set; }


    }
}
