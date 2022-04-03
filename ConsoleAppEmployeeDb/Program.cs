using ConsoleAppEmployeeDb.Controllers;
using System;

namespace ConsoleAppEmployeeDb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeesController employeesController = new EmployeesController();

            //employeesController.InsertEmployee("John", "Brown", 8600);

            employeesController.UpdateEmployee(1, "John", "BonJovi", 10000);

            var result = employeesController.GetEmployeesFromDatabase();
            foreach (var item in result)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} - {item.Salary} zł");
            }

            
        }

     }
} 
