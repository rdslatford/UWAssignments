using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=.;Integrated Security=True;Initial Catalog=AdventureWorks2016CTP3;Server=(local)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                Console.WriteLine(conn.ServerVersion);
            }

            Console.ReadKey();
        }
    }
}
