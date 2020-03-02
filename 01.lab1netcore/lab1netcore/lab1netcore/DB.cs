using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
namespace lab1netcore
{
    public class DB
    {
        public void Select(SqlConnection connection)
        {
            var sql = "SELECT * FROM region";
            var command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader[0]+" "+ reader[1]);
            }
            reader.Close();
        }
        public void Insert(SqlConnection connection, int id, string regionName)
        {
            var sql = "INSERT INTO Region(RegionId, RegionDescription) VALUES (@id, '@regionName')";
            var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@regionName", regionName);


            int affected = command.ExecuteNonQuery();
            Console.WriteLine($"{affected} rows inserted");
        }
        public void Delete(SqlConnection connection, int id)
        {
            var sql = "DELETE FROM Region(RegionId, RegionDescription) WHERE RegionId = @id";
            var command = new SqlCommand(sql, connection);
            //command.Parameters.AddWithValue("@id", id);
            //command.Parameters.AddWithValue("@regionName", regionName);


            int affected = command.ExecuteNonQuery();
            Console.WriteLine($"{affected} rows inserted");
        }
    }
}
