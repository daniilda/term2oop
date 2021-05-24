using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace OOP_78Lab
{
    public class DbConnection
    {
        readonly string _connectionString = "Server=DESKTOP-TBF0424;Initial Catalog=lab; User ID = 'sa'; Password='daniilda'";

        public async Task UpdateDb(List<News> list)
        {
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var sqexp1 = "DELETE tab";
                SqlCommand command1 = new SqlCommand(sqexp1, connection);
                await command1.ExecuteNonQueryAsync();
                for (int i = 0; i < list.Count; i++)
                {
                    var sqlExpression = $"INSERT INTO tab (title, description, link, time) VALUES ('{list[i].Title}','{list[i].Desctiprion}','{list[i].Url}','{list[i].Time}')";
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    await command.ExecuteNonQueryAsync();
                }
                
            }
        }

        public async Task<List<News>> GetDataFromDb()
        {
            var list = new List<News>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var sqexp1 = "SELECT * FROM tab";
                SqlCommand command1 = new SqlCommand(sqexp1, connection);
                SqlDataReader reader = command1.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {

                    while (reader.Read()) // построчно считываем данные
                    {
                        object title = reader.GetValue(0);
                        object description = reader.GetValue(1);
                        object link = reader.GetValue(2);
                        object time = reader.GetValue(3);
                        var news = new News
                        {
                            Title = (string)title,
                            Desctiprion = (string)description,
                            Url = (string)link,
                            Time = Convert.ToDateTime(time),
                        };
                    list.Add(news);
                    }

                }
            }
            return list;
        }




    }
}