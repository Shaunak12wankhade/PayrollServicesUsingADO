using System;

namespace PayrollServicesUsingADO
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Welcome to payroll services using ADO");

            EmployeeRepository repository = new EmployeeRepository();
            Console.WriteLine("Id Name BasicPay Startdate Gender Department PhoneNumber Address Deduction Tax IncomeTax NetPay \n");
            repository.GetAllEmployee();
            Console.ReadLine();

        }
    }
}
