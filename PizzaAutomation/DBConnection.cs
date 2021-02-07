using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PizzaAutomation
{
    public static class DBConnection
    {
        public static string connString = "Server=localhost;Database=pizza;Uid=root;CharSet=utf8;Connection Timeout=1800;";
        public static MySqlConnection connection = new MySqlConnection(connString);
        public static DataTable selectTable(string query, List<MySqlParameter> parameters = null)
        {
            DataTable result = new DataTable();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            using (connection)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                using (cmd)
                {
                    if (parameters != null)
                        parameters.ForEach(parameter => cmd.Parameters.Add(parameter));
                    result.Load(cmd.ExecuteReader());
                }
                return result;
            }
        }

        public static int updateTable(string query, List<MySqlParameter> parameters=null)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            using (connection)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                using (cmd)
                {
                    if (parameters != null)
                        parameters.ForEach(parameter => cmd.Parameters.Add(parameter));
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
