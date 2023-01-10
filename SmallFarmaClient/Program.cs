using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace SmallFarmaClient
{
    internal class Program
    {
        // Моя строка подключения:
        private static string ConnectionString =
            @"Data Source = .\SQLEXPRESS_2012;Initial Catalog = SmallFarma; Integrated Security = True";

        private static SqlConnection MyConn = null;

        static void Main(string[] args)
        {   
            if (ConnectToDb(ConnectionString))
            {
                try
                {
                    MyClient MC = new MyClient();
                    MC.MainCircle(MyConn);
                }
                catch (Exception e)
                {
                    Console.WriteLine("!!! ОШИБКА ВЫПОЛНЕНИЯ: '" + e.Message + "' !!!");
                }
                finally
                {
                    DisconnectFromDb();
                }
            }
        }

        static bool ConnectToDb(string cs)
        {
            Console.WriteLine("ВЫПОЛНЯЕТСЯ ПОДКЛЮЧЕНИЕ К БАЗЕ ДАННЫХ...");
            try
            {
                MyConn = new SqlConnection(cs);
                MyConn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("!!! ОШИБКА ПОДКЛЮЧЕНИЯ К БД: '" + e.Message + "' !!!");
                return false;
            }
            return true;
        }


        static void DisconnectFromDb()
        {
            MyConn.Close();
        }
    }
}
