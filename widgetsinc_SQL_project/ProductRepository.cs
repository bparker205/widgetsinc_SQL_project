using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;


namespace widgetsinc_SQL_project
{
    public class ProductRepository
    {

        // Defining connection string for methods
        private string connectionString;

        public ProductRepository(string _connectionstring)
        {
            connectionString = _connectionstring;
        }



        // GetProducts returns list of products from product table
        public List<Product> GetProducts()
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT id,brand_id,description,status_id,catagory_id FROM product;";

                MySqlDataReader reader = cmd.ExecuteReader();

                List<Product> products = new List<Product>();

                //While loop to iterating through each line in the product table
                while (reader.Read())
                {
                    Product prod = new Product();
                    //prod.id = (int)reader["id"];
                    //prod.brand_id = (int)reader["brand_id"];
                    prod.description = reader["description"].ToString();
                    //prod.status_id = (int)reader["status_id"];
                    //prod.catagory_id = (int)reader["catagory_id"];
                    products.Add(prod);
                }


                return products;

            }

        }

        // AddProduct method adds a record in product table
        public void AddProduct(int bID, string desc, int sID, int catID)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO product (brand_id, description, status_id, catagory_id) VALUES (@bID,@desc,@sID,@catID);";
                cmd.Parameters.AddWithValue("@bID", bID);
                cmd.Parameters.AddWithValue("@desc", desc);
                cmd.Parameters.AddWithValue("@sID", sID);
                cmd.Parameters.AddWithValue("catID", catID);
                cmd.ExecuteNonQuery();


            }

        }


        // UpdateProduct method updates record in product table
        public void UpdateProduct(int ID, string Desc, int StatusId)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE product SET Desc = @desc, StatusId = sID WHERE ID = @id ;";
                cmd.Parameters.AddWithValue("@desc", Desc);
                cmd.Parameters.AddWithValue("@sID", StatusId);
                cmd.ExecuteNonQuery();

            }
        }


        // DeleteProduct method deletes record in product table
        public void DeleteProduct(int ID)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM product WHERE id = @ID;";
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
