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
    public class EmployeeRepository
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
        /// UC1
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
                            model.DepartmentName = reader.GetString(4);
                            model.gender = reader.GetString(5);
                            model.startDate = reader.GetDateTime(6);
                            model.salary = reader.GetDecimal(7);
                            model.deductions = reader.GetDecimal(8);
                            model.taxablePay = reader.GetDecimal(9);
                            model.incomeTax = reader.GetDecimal(10);
                            model.netPay = reader.GetDecimal(11);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", model.employeeId, model.name, model.phoneNumber, model.address, model.DepartmentName, model.gender, model.startDate, model.salary, model.deductions, model.taxablePay, model.incomeTax, model.netPay);
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
                    command.Parameters.AddWithValue("@department", model.DepartmentName);
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
                    SqlCommand command = new SqlCommand("dbo.spUpdateDetails", this.connection);
                    ///command type is set as stored procedure
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeId", model.employeeId);
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

        /// <summary>
        /// Reading Updated Salary from DataBase
        /// UC3
        /// </summary>
        /// <returns></returns>
        public decimal ReadingUpdatedSalaryfromDataBase()
        {
            ///storing salary value after updating in this 
            decimal salary;
            EmployeeModel model = new EmployeeModel();
            ///passing query
            SqlCommand sqlCommand = new SqlCommand("Select * from payroll_adonet", connection);
            ///opening connection to read 
            this.connection.Open();
            SqlDataReader dr = sqlCommand.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    model.employeeId = Convert.ToInt32(dr["employeeId"]);
                    model.name = dr["name"].ToString();
                    model.salary = Convert.ToDecimal(dr["salary"]);
                }
                Console.WriteLine("{0},{1},{2}", model.employeeId, model.name, model.salary);
                ///putting value in salary if executed
                salary = model.salary;
            }
            else
            {
                throw new Exception("no data found");
            }
            ///closing up reader as well as connection.
            dr.Close();
            connection.Close();
            ///returning salary
            return salary;
        }

        /// <summary>
        /// Get All employee Started In A DateRange
        /// UC5
        /// </summary>
        /// <returns></returns>
        public List<EmployeeModel> GetAllemployeeStartedInADateRange()
        {
            ///creating a list to store all those employees
            List<EmployeeModel> list = new List<EmployeeModel>();
            using (connection)
            {
                ///passing query
                string query = "select * from payroll_adonet where start between cast('01-01-2018' as date) and getdate()";
                SqlCommand command = new SqlCommand(query, connection);
                ///opening connection to read
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        EmployeeModel model = new EmployeeModel();
                        model.employeeId = dr.GetInt32(0);
                        model.name = dr.GetString(1);
                        model.phoneNumber = dr.GetDecimal(2);
                        model.address = dr.GetString(3);
                        model.DepartmentName = dr.GetString(4);
                        model.gender = dr.GetString(5);
                        model.startDate = dr.GetDateTime(6);
                        model.salary = dr.GetDecimal(7);
                        model.deductions = dr.GetDecimal(8);
                        model.taxablePay = dr.GetDecimal(9);
                        model.incomeTax = dr.GetDecimal(10);
                        model.netPay = dr.GetDecimal(11);
                        Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", model.employeeId, model.name, model.phoneNumber, model.address, model.DepartmentName, model.gender, model.startDate, model.salary, model.deductions, model.taxablePay, model.incomeTax, model.netPay);

                        list.Add(model);
                    }
                    ///closing reader and connection
                    dr.Close();
                    connection.Close();
                    return list;
                }
                else
                {
                    throw new Exception("No data found");
                }
            }
        }

        /// <summary>
        /// Grouping Data To Find Min Max Sum Average
        /// UC6
        /// </summary>
        /// <returns></returns>
        public bool GroupingDataToFindMinMaxSumAverage()
        {
            EmployeeModel model = new EmployeeModel();
            using (connection)
            {
                ///query for finsing max min avg count
                string query = "select gender,sum(salary)as sum,min(salary) as min,max(salary)as max,avg(salary) as avg,count(salary)as count from payroll_adonet Group  by gender";
                SqlCommand command = new SqlCommand(query, connection);
                ///opening connection for reading
                connection.Open();
                //executing reader 
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        model.gender = dr.GetString(0);
                        model.salary = dr.GetDecimal(1);
                    }
                    ///to check if some rows are affected
                    int result = command.ExecuteNonQuery();
                    //closing connection and reader
                    dr.Close();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    throw new Exception("No data found");
                }
            }
        }

        /// <summary>
        ///Implementing Er Diagram With MultipleTables
        ///UC7
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ImplementingErDiagramWithMultipleTables(EmployeeModel model)
        {
            ///trying to add data to multiple tables formed in Er diagram and trying to insert value in them 
            ///inserting value into them using stored procedure 
            ///also implementing roll back in stored procdure to roll back even if data is not implemented ina  single table
            try
            {
                using (this.connection)
                {
                    ///using stored procedure
                    SqlCommand command = new SqlCommand("dbo.InsertingDataIntoMultipleTables", connection);  
                    ///changing the command type to stored procedure
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    ///adding details
                    command.Parameters.AddWithValue("@EmployeeID", model.employeeId);
                    command.Parameters.AddWithValue("@name", model.name);
                    command.Parameters.AddWithValue("@phonenumber", model.phoneNumber);
                    command.Parameters.AddWithValue("@address", model.address);
                    command.Parameters.AddWithValue("@gender", model.gender);
                    command.Parameters.AddWithValue("@start", model.startDate);
                    command.Parameters.AddWithValue("@CompanyId", model.CompanyId);
                    command.Parameters.AddWithValue("@CompanyName", model.CompanyName);
                    command.Parameters.AddWithValue("@DepartmentName", model.DepartmentName);
                    command.Parameters.AddWithValue("@DepartmentId", model.DepartmentId);
                    command.Parameters.AddWithValue("@PayrollId", model.PayrollId);
                    command.Parameters.AddWithValue("@salary", model.salary);
                    command.Parameters.AddWithValue("@Deductions", model.taxablePay);
                    command.Parameters.AddWithValue("@taxable_pay", model.taxablePay);
                    command.Parameters.AddWithValue("@income_tax", model.incomeTax);
                    command.Parameters.AddWithValue("@net_pay", model.netPay); 
                    ///opening connection to execute
                    connection.Open(); 
                    ///result will contain the number of rows affected
                    var result = command.ExecuteNonQuery();
                    //closing connection
                    connection.Close();
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
        /// Update Employee Details In The Data Base With ER
        /// UC8,UC9(Also ensuring all the cases for uc9)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateEmployeeSalaryInTheDataBaseWithER(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    ///checking if it is working fine with er
                    ///creating a stored Procedure for updating  employees details into database
                    SqlCommand command = new SqlCommand("dbo.spUpdateDetailsForMultipleTables", this.connection);
                    ///command type is set as stored procedure
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeID", model.employeeId);
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

        /// <summary>
        /// Grouping Data To Find Min Max Sum Average With Er
        /// UC8,UC9
        /// </summary>
        /// <returns></returns>
        public bool GroupingDataToFindMinMaxSumAverageWithEr()
        {
            ///checking if grouping data is working fine with er diagram
            EmployeeModel model = new EmployeeModel();
            using (connection)
            {
                ///using stored procedure to get min max sum avg
                SqlCommand command = new SqlCommand("dbo.spGetDetailsForSumMinMaxAvg", connection);
                ///changing command type to store procedure
                command.CommandType = System.Data.CommandType.StoredProcedure;
                ///opening connection for reading
                connection.Open();
                //executing reader 
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    ///reder is reading data 
                    while (dr.Read())
                    {
                        model.gender = dr.GetString(0);
                        model.salary = dr.GetDecimal(1);
                    }
                    dr.Close();

                    ///to check if some rows are affected
                    int result = command.ExecuteNonQuery();
                    //closing connection and reader
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    throw new Exception("No data found");
                }
            }
        }
    }
}