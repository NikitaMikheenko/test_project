using Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess
{
    public class WorkersContext
    {
        public List<Worker> GetWorkersList()
        {
            using (SqlConnection connection = new SqlConnection(Context.ConnectionString()))
            {
                connection.Open();

                string str = $"EXEC GetWorkersList";

                SqlCommand command = new SqlCommand(str, connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    List<Worker> model = new List<Worker>();

                    while (reader.Read())
                    {
                        model.Add(new Worker()
                        {
                            Id = (int)reader["Id"],
                            Surname = (string)reader["Surname"],
                            Name = (string)reader["Name"],
                            MiddleName = reader["MiddleName"].ToString(),
                            DateOfEmployment = (string)reader["DateOfEmployment"],
                            Position = (string)reader["Position"],
                            Company = new Company()
                            {
                                Id = (int)reader["CompanyId"],
                                Name = (string)reader["CompanyName"],
                                Size = (int)reader["CompanySize"],
                                OrganizationLegalForm = (string)reader["CompanyOrganizationLegalForm"]
                            }
                        });
                    }

                    return model;
                }
            }

            return null;
        }

        public int CreateWorker()
        {
            using (SqlConnection connection = new SqlConnection(Context.ConnectionString()))
            {
                connection.Open();

                string str = $"EXEC CreateWorker";

                SqlCommand command = new SqlCommand(str, connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    return (int)reader["Id"];
                }
            }

            throw new Exception("Error adding new item!");
        }

        public Worker GetWorkerById(int id)
        {
            using (SqlConnection connection = new SqlConnection(Context.ConnectionString()))
            {
                connection.Open();

                string str = $"EXEC GetWorkerById {id}";

                SqlCommand command = new SqlCommand(str, connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    return new Worker()
                    {
                        Id = (int)reader["Id"],
                        Surname = (string)reader["Surname"],
                        Name = (string)reader["Name"],
                        MiddleName = reader["MiddleName"].ToString(),
                        DateOfEmployment = (string)reader["DateOfEmployment"],
                        Position = (string)reader["Position"],
                        Company = new Company()
                        {
                            Id = (int)reader["CompanyId"],
                            Name = (string)reader["CompanyName"],
                            Size = (int)reader["CompanySize"],
                            OrganizationLegalForm = (string)reader["CompanyOrganizationLegalForm"]
                        }
                    };
                }
            }

            throw new Exception("Error: item not found!");
        }

        public void SaveWorker(Worker model)
        {
            using (SqlConnection connection = new SqlConnection(Context.ConnectionString()))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"EXEC SaveWorker {model.Id}, '{model.Surname}', '{model.Name}', " +
                    $"'{model.MiddleName}', '{model.DateOfEmployment}', '{model.Position}', {model.Company.Id}", connection);

                if (command.ExecuteNonQuery() != 1)
                {
                    throw new Exception("Save failed!");
                }
            }
        }

        public void DeleteWorker(int id)
        {
            using (SqlConnection connection = new SqlConnection(Context.ConnectionString()))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"EXEC DeleteWorker {id}", connection);

                if (command.ExecuteNonQuery() != 1)
                {
                    throw new Exception("Delete failed!");
                }
            }
        }
    }
}
