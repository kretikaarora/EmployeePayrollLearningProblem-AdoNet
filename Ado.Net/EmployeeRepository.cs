// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeRepository.cs" company="Capgemini">
//   Copyright
// </copyright>
// <creator Name="Kretika Arora"/>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Ado.Net
{
    /// <summary>
    /// Employee Repository Class
    /// </summary>
    class EmployeeRepository
    {
        /// <summary>
        /// Making a Connection with database payroll_services
        /// </summary>
        public static string connectionString = @"Data Source=LAPTOP-TAR1C56T\MSSQLSERVER01;Initial Catalog = payroll_services; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //making connection using connection string
        SqlConnection connection = new SqlConnection(connectionString);

        public object ComandType { get; private set; }

        /// <summary>
        /// getting all employees in database payroll_adonet
        /// </summary>
        public void GetAllEmployees()
        {
            //instance of Employee model for reading table
            EmployeeModel model = new EmployeeModel();
            try
            {
                ///checking if connection is established 
                using (connection)
                {
                    ///query that needs to implemented in the database
                    string query = @"select * from dbo.payroll_adonet";
                    SqlCommand command = new SqlCommand(query, connection);
                    ///opening connection
                    this.connection.Open();
                    //reader to read the data in the table
                    SqlDataReader reader = command.ExecuteReader();
                    ///checking if rows are there in table or not through data reader
                    if (reader.HasRows)
                    {
                        ///reading the data
                        while (reader.Read())
                        {
                            ///it should be mapped according to the coloumns in original data
                            model.employeeId = reader.GetInt32(0);
                            model.name = reader.GetString(1);
                            model.phoneNumber = reader.GetDecimal(2);
                            model.address = reader.GetString(3);
                            model.department = reader.GetString(4);
                            model.gender = reader.GetString(5);
                            model.startDate = reader.GetDateTime(6);
                            model.salary = reader.GetDecimal(7);
                            model.deductions = reader.GetDecimal(8);
                            model.taxablePay = reader.GetDecimal(9);
                            model.incomeTax = reader.GetDecimal(10);
                            model.netPay = reader.GetDecimal(11);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", model.employeeId, model.name, model.phoneNumber, model.address, model.department, model.gender, model.startDate, model.salary, model.deductions, model.taxablePay, model.incomeTax, model.netPay);

                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    ///closing the reader
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            ///this finally will always be implemented
            finally
            {

                this.connection.Close();
            }
        }       
    }    
}
