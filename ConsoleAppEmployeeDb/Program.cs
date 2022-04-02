using ConsoleAppEmployeeDb.Controllers;
using System;

namespace ConsoleAppEmployeeDb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeesController employeesController = new EmployeesController();
            var result = employeesController.GetEmployeesFromDatabase();
            foreach (var item in result)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} - {item.Salary} zł");
            }
        }

     }
} 
