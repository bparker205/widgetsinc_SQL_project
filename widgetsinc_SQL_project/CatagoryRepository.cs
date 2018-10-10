using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace widgetsinc_SQL_project
{
    public class CatagoryRepository
    {
        // Defining connection string for methods
        private string connectionString;

        public CatagoryRepository(string _connectionstring)
        {
            connectionString = _connectionstring;
        }


        // GetCatagory returns list of catagories from catagory table
        public List<Catagory> GetCagagory()
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT id, status_id AS sID FROM catagory;";
                MySqlDataReader reader = cmd.ExecuteReader();


                List<Catagory> catagories = new List<Catagory>();
                // While loop to iterate throu each line in catagory table then add to list
                while (reader.Read())
                {
                    Catagory catagory = new Catagory();
                    catagory.id = (int)reader["id"];
                    catagory.status_id = (int)reader["sID"];
                    catagories.Add(catagory);
                }

                return catagories;

            }
        }


        // AddCaragory method creates a new catagoryID in catagory table
        public void AddCatagory(int bID, int sID)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO catagory (id,status_id) VALUES (@bID,@sID);";
                cmd.Parameters.AddWithValue("id", bID);
                cmd.Parameters.AddWithValue("status_id", sID);
                cmd.ExecuteNonQuery();
            }
        }

        // UpdateCatagory method updates row in catagory table
        public void UpdateCatagory(int bID, int sID)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE catagory SET status_id as sID WHERE id = bID;";
                cmd.Parameters.AddWithValue("sID", sID);
                cmd.ExecuteNonQuery();
            }

        }

        // DeleteCatagory method deletes row in catagory table 
        public void DeleteCatagory(int bID, int sID)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM catagory WHERE id = bID;";
                cmd.ExecuteNonQuery();
            }
        }
    }
}
