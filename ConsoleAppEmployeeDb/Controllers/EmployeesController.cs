using ConsoleAppEmployeeDb.Models;
using System;
using System.Collections.Generic;
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
                        LastName = (string)reader["lastname"],
                        Salary = (int)reader["salary"],
                    };
                    result.Add(employee);
                }
            }

            return result;
        }

        public void InsertEmployee(string firstname, string lastname, int salary)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                connection.Open();

                cmd.CommandText = "insert into Employees (firstname, lastname, salary) " +
                    "values (@param1, @param2, @param3)";

                cmd.Parameters.AddWithValue("@param1", firstname);
                cmd.Parameters.AddWithValue("@param2", lastname);
                cmd.Parameters.AddWithValue("@param3", salary);

                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();

                connection.Close();
            }
        }

        public void UpdateEmployee(int id, string firstname, string lastname, int salary)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                connection.Open();

                cmd.CommandText = "update Employees set" +
                    " firstname = @param1," +
                    " lastname = @param2," +
                    " salary = @param3" +
                    " where id = @param4";

                cmd.Parameters.AddWithValue("@param1", firstname);
                cmd.Parameters.AddWithValue("@param2", lastname);
                cmd.Parameters.AddWithValue("@param3", salary);
                cmd.Parameters.AddWithValue("@param4", id);

                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();

                connection.Close();
            }
        }
        public void DeleteEmployee(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                connection.Open();

                cmd.CommandText = "delete from Employees where Id = " + id;
                var rowsAffected = cmd.ExecuteNonQuery();
                if(rowsAffected == 0)
                {
                    Console.WriteLine("Something was wrong...");
                }
                else
                {
                    Console.WriteLine("Employee was deleted");
                }
                cmd.Parameters.Clear();
                connection.Close();
            }
        }
    }
}
