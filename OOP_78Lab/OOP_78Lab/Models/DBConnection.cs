using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace OOP_78Lab
{
    public class DbConnection
    {
        readonly string _connectionString = "Server=DESKTOP-TBF0424;Initial Catalog=lab; User ID = sa; Password=daniilda";

        public async Task UpdateDb(List<string> list)
        {
            //TODO: Do code
        }

        public async Task<List<string>> GetDataFromDb()
        {
            var list = new List<string>();
            return list;
        }

        public async Task<bool> test()
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                return connection.State == ConnectionState.Open;
            }
        }
    }
}