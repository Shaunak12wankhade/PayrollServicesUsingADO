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
    }
}
