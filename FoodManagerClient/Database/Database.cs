using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using FoodManagerClient.Model;

namespace FoodManagerClient.Database
{
   class Database
    {
        public MySqlConnection conn;
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader reader;

        public DataTable table = new DataTable();

        private List<string> list = new List<string>();
        private List<Food> ListFood = new List<Food>();
        public Database()
        {
            try
            {
                string host = "localhost";
                int port = 3306;
                string database = "food";
                string username = "root";
                string password = "";
                String connString = "Server=" + host + ";Database=" + database + ";port=" + port + ";User Id=" + username + ";password=" + password;
                conn = new MySqlConnection(connString);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Дар пайвастшави хатоги мавҷуд" + ex.Message);
            }
        }
    
        public List<Food> GetTypesFoodById(int id)
        {
            ListFood.Clear();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT id,name,price,typesFood,date,descr,image FROM food_table WHERE food_table.typesFood = (SELECT NAME FROM types_food WHERE id = '"+id+"');", conn))
                {
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Food food = new Food();
                        food.Id = reader.GetUInt16(0);
                        food.Name = reader.GetString(1);
                        food.Price = reader.GetDouble(2);
                        food.Typefood = reader.GetString(3);
                        food.DateTime = reader.GetDateTime(4);
                        food.Descr = reader.GetString(5);

                        food.Image = (byte[])reader["image"];

                        ListFood.Add(food);
                    }
                    conn.Close();
                    return ListFood;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            return null;

        }

        public List<Food> GetAllFoodByID(int id)
        {
            ListFood.Clear();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT id,name,price,typesFood,date,descr,image FROM food_table WHERE id = '" + id + "';", conn))
                {
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Food food = new Food();
                        food.Id = reader.GetUInt16(0);
                        food.Name = reader.GetString(1);
                        food.Price = reader.GetDouble(2);
                        food.Typefood = reader.GetString(3);
                        food.DateTime = reader.GetDateTime(4);
                        food.Descr = reader.GetString(5);

                        food.Image = (byte[])reader["image"];

                        ListFood.Add(food);
                    }
                    conn.Close();
                    return ListFood;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            return null;

        }

        public List<string> GetFoodTypes()
        {
            try
            {
                list.Clear();

                using (MySqlCommand cmd = new MySqlCommand("select * from types_food", conn))
                {
                    conn.Open();
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(reader[1].ToString());
                    }

                    conn.Close();
                    return list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n Ба база пайваст нест");
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            return null;
        }
    }
}

