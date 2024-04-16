using MySql.Data.MySqlClient;
using SkiShop.Models;
using System.Data.SqlClient;

namespace SkiShop.Services
{
    public class SkiDAO
    {
        //connection string to connect to cloud database
        String connectionString = "Server=\"skishop.mysql.database.azure.com\";UserID = \"jloerop\";Password=\"Rsds#077\";Database=\"skishop\";SslMode=Required;SslCa=\"{path_to_CA_cert}\";";
        //method to get inventory from the database
        public List<InventoryModel> getInventory()
        {
            List<InventoryModel> inventory = new List<InventoryModel>();

            string sqlStatement = "SELECT * FROM `inventory`";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);
                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        inventory.Add(new InventoryModel((int)reader[0], (int)reader[1], (int)reader[2], (int)reader[3], (string)reader[4], (string)reader[5], (string)reader[6], (string)reader[7]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };

            }
            return inventory;
        }
        // method to insert a new ski/snowboard into the database
        public bool InsertSki(InventoryModel inventory)
        {
            string sqlStatement = "INSERT INTO `inventory`(`price`, `length`, `width`, `condition`, `brand`, `type`, `image`) VALUES (@price,@length,@width,@condition,@brand,@type,@image)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@PRICE", inventory.Price);
                command.Parameters.AddWithValue("@LENGTH", inventory.Length);
                command.Parameters.AddWithValue("@WIDTH", inventory.Width);
                command.Parameters.AddWithValue("@CONDITION", inventory.Condition);
                command.Parameters.AddWithValue("@BRAND", inventory.Brand);
                command.Parameters.AddWithValue("@TYPE", inventory.Type);
                command.Parameters.AddWithValue("@IMAGE", inventory.Image);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
                return rowsAffected > 0;
            }
        }
        // method to delete a item from the database
        public bool Delete(int id)
        {
            bool success = false;

            string sqlStatement = "DELETE FROM `inventory` WHERE Id = @id";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    connection.Open();
                    int rows = command.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        success = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            }
            return success;
        }
        // method to get product by a certain id from the database
        public InventoryModel GetProductById(int id)
        {
            InventoryModel foundProduct = null;

            string sqlStatement = "SELECT * FROM `inventory` WHERE Id = @id";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundProduct = new InventoryModel((int)reader[0], (int)reader[1], (int)reader[2], (int)reader[3], (string)reader[4], (string)reader[5], (string)reader[6], (string)reader[7]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            }
            return foundProduct;
        }
        // method to update a certain product by id from the database
        public int Update(InventoryModel inventory)
        {
            int newIdNumber = -1;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE `inventory` SET `price`=@price,`length`=@length,`width`=@width,`condition`=@condition,`brand`=@brand,`type`=@type,`image`=@image WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", inventory.Id);
                command.Parameters.AddWithValue("@PRICE", inventory.Price);
                command.Parameters.AddWithValue("@LENGTH", inventory.Length);
                command.Parameters.AddWithValue("@WIDTH", inventory.Width);
                command.Parameters.AddWithValue("@CONDITION", inventory.Condition);
                command.Parameters.AddWithValue("@BRAND", inventory.Brand);
                command.Parameters.AddWithValue("@TYPE", inventory.Type);
                command.Parameters.AddWithValue("@IMAGE", inventory.Image);

                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
                return newIdNumber;
            }
        }
        //method that will search the database and return the results from the database
        public List<InventoryModel> SearchProducts(string searchTerm)
        {
            List<InventoryModel> foundProducts = new List<InventoryModel>();

            string sqlStatement = "SELECT * FROM `inventory` WHERE `brand` LIKE @brand";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@BRAND", '%' + searchTerm + '%');

                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundProducts.Add(new InventoryModel((int)reader[0], (int)reader[1], (int)reader[2], (int)reader[3], (string)reader[4], (string)reader[5], (string)reader[6], (string)reader[7]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            }
            return foundProducts;
        }
    }
}
