using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeBE.Infrastructure
{
    public class Test
    {
        static void Main(string[] args)
        {
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "127.0.0.1";
            conn_string.Port = 57779;
            conn_string.UserID = "root";
            conn_string.Password = "my-secret-pw";
            conn_string.Database = "fridge";



            MySqlConnection MyCon = new MySqlConnection(conn_string.ToString());

            try
            {
                MyCon.Open();
                Console.WriteLine("Open");
                MyCon.Close();
                Console.WriteLine("Close");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
