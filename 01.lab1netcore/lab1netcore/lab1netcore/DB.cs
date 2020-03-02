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
            var sql = "INSERT INTO Region(RegionId, RegionDescription) VALUES (@id, @regionName)";
            var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@regionName", regionName);


            int affected = command.ExecuteNonQuery();
            Console.WriteLine($"{affected} rows inserted");
        }
        public void Delete(SqlConnection connection, int id)
        {
            var sql = "DELETE FROM Region WHERE RegionID = @id";
            var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);
            


            int affected = command.ExecuteNonQuery();
            Console.WriteLine($"{affected} rows inserted");
        }
        
        public void Update(SqlConnection connection, int id, string newRegionName)
        {
            var sql = "Update Region SET RegionDescription=@newRegionName WHERE RegionId=@id";
            var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@newRegionName", newRegionName);

            int affected = command.ExecuteNonQuery();
            Console.WriteLine($"{affected} rows inserted");
        }
    }
}
