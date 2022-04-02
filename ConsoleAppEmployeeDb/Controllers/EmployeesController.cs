using ConsoleAppEmployeeDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleAppEmployeeDb.Controllers
{
    internal class EmployeesController
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeesDb;
                        Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
                        ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public List<Employee> GetEmployeesFromDatabase()
        {
            var result = new List<Employee>();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            var query = $"select * from Employees";
            using (SqlCommand readCommand = new SqlCommand(query, connection))
            {
                SqlDataReader reader = readCommand.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = new Employee
                    {
                        Id = (int)reader["Id"],
                        FirstName = (string)reader["firstname"],
                        LastName= (string)reader["lastname"],
                        Salary = (int)reader["salary"],
                    };
                    result.Add(employee);
                }
            }

            return result;
        }
    }
}
