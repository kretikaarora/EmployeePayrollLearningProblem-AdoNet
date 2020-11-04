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
    public class EmployeeModel
    {
        List<EmployeeModel> list = new List<EmployeeModel>();
        public string name { get; set; }
        public int  employeeId { get; set; }
        //public int EmployeeId { get; internal set; }
        public decimal phoneNumber { get; set; }
        public string address { get; set; }
        public string department { get; set; }
        public string gender { get; set; }
        public decimal salary { get; set; }
        public decimal deductions { get; set; }
        public decimal taxablePay { get; set; }      
        public decimal netPay { get; set; }
        public decimal incomeTax { get; set; }
        public DateTime startDate { get; set; }
    }
}
