using Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess
{
    public class CompaniesContext
    {
        public List<Company> GetCompaniesList()
        {
            using (SqlConnection connection = new SqlConnection(Context.ConnectionString()))
            {
                connection.Open();

                string str = $"EXEC GetCompaniesList";

                SqlCommand command = new SqlCommand(str, connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    List<Company> model = new List<Company>();

                    while (reader.Read())
                    {
                        model.Add(new Company()
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Size = (int)reader["Size"],
                            OrganizationLegalForm = (string)reader["OrganizationLegalForm"]
                        });
                    }

                    return model;
                }
            }

            return null;
        }

        public int CreateCompany()
        {
            using (SqlConnection connection = new SqlConnection(Context.ConnectionString()))
            {
                connection.Open();

                string str = $"EXEC CreateCompany";

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

        public Company GetCompanyById(int id)
        {
            using (SqlConnection connection = new SqlConnection(Context.ConnectionString()))
            {
                connection.Open();

                string str = $"EXEC GetCompanyById {id}";

                SqlCommand command = new SqlCommand(str, connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    return new Company()
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Size = (int)reader["Size"],
                        OrganizationLegalForm = (string)reader["OrganizationLegalForm"]
                    };
                }
            }

            throw new Exception("Error: item not found!");
        }

        public void SaveCompany(Company model)
        {
            using (SqlConnection connection = new SqlConnection(Context.ConnectionString()))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"EXEC SaveCompany {model.Id}, " +
                    $"'{model.Name}', {model.Size}, '{model.OrganizationLegalForm}'", connection);

                if (command.ExecuteNonQuery() != 1)
                {
                    throw new Exception("Save failed!");
                }
            }
        }

        public void DeleteCompany(int id)
        {
            using (SqlConnection connection = new SqlConnection(Context.ConnectionString()))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"EXEC DeleteCompany {id}", connection);

                if (command.ExecuteNonQuery() != 1)
                {
                    throw new Exception("Delete failed!");
                }
            }
        }
    }
}
