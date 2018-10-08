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
                    // prod.id = (int)reader["id"];
                    // prod.brand_id = (int)reader["bId"];
                    prod.description = reader["description"].ToString();
                    // prod.status_id = (int)reader["sId"];
                    // prod.catagory_id = (int)reader["cId"];
                    products.Add(prod);
                }


                return products;

            }

        }
    }
}
