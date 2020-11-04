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
    /// UC1
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

        /// <summary>
        /// Adding Employee To Database
        /// UC2
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddEmployee(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    ///creating a stored Procedure for adding employees into database
                    SqlCommand command = new SqlCommand("dbo.SpAddEmployeeDetails", this.connection);
                    ///command type is set as stored procedure
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    ///adding values from employeemodel to stored procedure using disconnected architecture
                    ///connected architecture will only read the data
                    command.Parameters.AddWithValue("@name", model.name);
                    command.Parameters.AddWithValue("@phone", model.phoneNumber);
                    command.Parameters.AddWithValue("@address", model.address);
                    command.Parameters.AddWithValue("@department", model.department);
                    command.Parameters.AddWithValue("@gender", model.gender);
                    command.Parameters.AddWithValue("@start", model.startDate);
                    command.Parameters.AddWithValue("@salary", model.salary);
                    command.Parameters.AddWithValue("@Deductions", model.taxablePay);
                    command.Parameters.AddWithValue("@taxable_pay", model.taxablePay);
                    command.Parameters.AddWithValue("@income_tax", model.incomeTax);
                    command.Parameters.AddWithValue("@net_pay", model.netPay);
                    ///opening connection to read data and storing in result
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    ///result will contain information about rows affected
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Update Employee Salary In The DataBase
        /// UC3
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateEmployeeDetailsInTheDataBase(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    ///creating a stored Procedure for updating  employees details into database
                    SqlCommand command = new SqlCommand("dbo.SpUpdateDetails", this.connection);
                    ///command type is set as stored procedure
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@employeeId", model.employeeId);
                    command.Parameters.AddWithValue("@salary", model.salary);
                    command.Parameters.AddWithValue("@name", model.name);
                    ///opening up connection
                    connection.Open();
                    ///the result will contain number of rows affected 
                    ///due to execute non query command
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            /// finally means it cannot bypass this finally 
            /// this statement has to be executed
            finally
            {
                this.connection.Close();
            }
        }
    }    
}
