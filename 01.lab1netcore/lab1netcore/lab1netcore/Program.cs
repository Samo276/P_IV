using System;
using System.Data.SqlClient;
namespace lab1netcore
{
    class Program
    {
        static void Main()
        {
            var connectionStrig = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; //t wrzucamy adres
            using var connection = new SqlConnection(connectionStrig);

            var db = new DB();
            connection.Open();


            db.Select(connection);
            //dopisać update i delete
            //db.Insert(connection, 276, "Bielsko");
            //db.Delete(connection, 276);
            db.Update(connection, 276, "BiALA");
            db.Select(connection);
            connection.Close();
        }


    }
}
