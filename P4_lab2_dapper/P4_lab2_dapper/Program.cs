using System;
using System.Data.SqlClient;
using Dapper;
namespace P4_lab2_dapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using var connection = new SqlConnection(connectionString);

            var db = new DB();
            
            var region = new Region()
            {
                RegionDescription = "dapper obiekt",
                RegionId = 102
            };
            //db.Insert(connection, region);
            //db.Insert(connection, 103, "Wilkowyje");
            db.Select(connection);
            //db.SelectOrder(connection, 10231);
        }
    }
}
