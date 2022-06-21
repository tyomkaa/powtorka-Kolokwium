using Kolokwium_powtórka.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Kolokwium_powtórka.Services
{
    public class DBService : IDBService
    {

        private readonly string stringConnection = @"Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True";

        public void AddAnimal(Animal animal)
        {
            var connection = new SqlConnection(stringConnection);
            var command = new SqlCommand();

            command.CommandText = $"INSERT INTO Animal VALUES(@name, @type, @admissiondate)";
            command.Parameters.AddWithValue("name", animal.Name);
            command.Parameters.AddWithValue("type", animal.Type);
            command.Parameters.AddWithValue("addmisiondate", animal.AdmissionDate);

            connection.Open();

            int changedRows = command.ExecuteNonQuery();
            if (changedRows < 0) throw new Exception();

            connection.Close();
        }

        public List<Animal> GetAnimals(string sortBy)
        {
            var animals = new List<Animal>();
            var connection = new SqlConnection(stringConnection);
            {
                var command = new SqlCommand();

                command.Connection = connection;
                string[] nameOfColumns = { "Name", "Type" ,"AdmissionDate"};
                bool isMatched = false;

                if (!string.IsNullOrEmpty(sortBy))
                {
                    foreach(var column in nameOfColumns)
                    {
                        if (sortBy.ToLower().Equals(column))
                        {
                            isMatched = true;
                        }
                    }
                    if (isMatched)
                    {
                        command.CommandText = $"SELECT * FROM Animal ORDER BY {sortBy} DESC";
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                else
                {
                    command.CommandText = "SELECT * FROM Animal ORDER BY AdmissionDate DESC";
                }

                connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    animals.Add(new Animal
                    {
                        idAnimal = int.Parse(reader["id"].ToString()),
                        Name = reader["name"].ToString(),
                        Type = reader["type"].ToString(),
                        AdmissionDate = DateTime.Parse(reader["admissiondate"].ToString())
                    });
                connection.Close();
            }
            return animals;
        }
    }

    public interface IDBService
    {
        public List<Animal> GetAnimals(string sortBy);
        public void AddAnimal(Animal animal);
    }
}
