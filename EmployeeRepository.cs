using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PayrollServicesUsingADO
{
    class EmployeeRepository
    {
        //Connection to SQL Database
        public static string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = payroll_serviceADO; Integrated Security = True";

        //passing the string to sqlconnection to make connection 
        SqlConnection sqlconnection = new SqlConnection(connectionString);


        public void GetAllEmployee()
        {
            try
            {
                //Creating object for employeemodel and access the fields
                EmployeeModel employeeModel = new EmployeeModel();
                
                string query = @"SELECT * FROM employee_payroll;";

                // define sql command object
                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);

                //Open the connection
                this.sqlconnection.Open();

                
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        employeeModel.EmployeeId = reader.GetInt32(0);
                        employeeModel.EmployeeName = reader["EmployeeName"].ToString();
                        employeeModel.BasicPay = Convert.ToDouble(reader["BasicPay"]);
                        employeeModel.Deductions = Convert.ToDouble(reader["Deductions"]);
                        employeeModel.IncomeTax = Convert.ToDouble(reader["IncomeTax"]);
                        employeeModel.TaxablePay = Convert.ToDouble(reader["TaxablePay"]);
                        employeeModel.NetPay = Convert.ToDouble(reader["NetPay"]);
                        employeeModel.Gender = reader["Gender"].ToString();
                        employeeModel.PhoneNumber = Convert.ToInt64(reader["PhoneNumber"]);
                        employeeModel.Department = reader["Department"].ToString();
                        employeeModel.Address = reader["Address"].ToString();
                        employeeModel.StartDate = Convert.ToDateTime(reader["StartDate"]);

                        Console.WriteLine("{0} {1} {2}  {3} {4} {5}  {6}  {7} {8} {9} {10} {11}", employeeModel.EmployeeId, employeeModel.EmployeeName, employeeModel.BasicPay, employeeModel.StartDate, employeeModel.Gender, employeeModel.Department, employeeModel.PhoneNumber, employeeModel.Address, employeeModel.Deductions, employeeModel.TaxablePay, employeeModel.IncomeTax, employeeModel.NetPay);
                        Console.WriteLine("\n");
                    }
                }
                else
                {
                    Console.WriteLine("No data found");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.sqlconnection.Close();
            }
        }
    }

}
