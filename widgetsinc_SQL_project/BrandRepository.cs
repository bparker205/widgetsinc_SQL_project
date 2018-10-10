using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace widgetsinc_SQL_project
{
    public class BrandRepository
    {
        // Defining connection string for methods
        private string connectionString;

        public BrandRepository(string _connectionstring)
        {
            connectionString = _connectionstring;
        }


        // GetBrands returns list of brands from brand table
        public List<Brand> GetBrands()
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT id, status_id AS sID FROM brand;";
                MySqlDataReader reader = cmd.ExecuteReader();


                List<Brand> brands = new List<Brand>();
                // While loop to iterate throu each line in brand table then add to list
                while (reader.Read())
                {
                    Brand brand = new Brand();
                    brand.id = (int)reader["id"];
                    brand.status_id = (int)reader["sID"];
                    brands.Add(brand);
                }

                return brands;

            }
        }

        // AddBrand method creates a new brand in brand table
        public void AddBrand(int bID, int sID)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO brand (id,status_id) VALUES (@bID,@sID);";
                cmd.Parameters.AddWithValue("id", bID);
                cmd.Parameters.AddWithValue("status_id", sID);
                cmd.ExecuteNonQuery();
            }
        }

        // UpdateBrand method updates row in brand table
        public void UpdateBrand(int bID, int sID)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE brand SET status_id as sID WHERE id = bID;";
                cmd.Parameters.AddWithValue("sID", sID);
                cmd.ExecuteNonQuery();
            }

        }

        // DeleteBrand method deletes row in brand table 
        public void DeleteBrand(int bID, int sID)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM brand WHERE id = bID;";
                cmd.ExecuteNonQuery();
            }
        }
    }
}
