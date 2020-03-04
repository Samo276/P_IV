using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;
namespace P4_lab2_dapper
{
    class DB
    {
        public void SelectOrder(IDbConnection connection, int id) 
        {
            var sql =   "SELECT * " +
                "       FROM Orders O JOIN [Order Detail] OD ON O.OrderId = OD.OrderId " +
                "       WHERE O.OrderId = @id";

            var resultOrder = default(Order);//dlaczo tutuaj nie wipasno null, skro w praktyce default będzie null? żeby dostał nulla typu order

            var result = connection.Query<Order, OrderDetails, Order>
            (
                sql,
                (order, orderDetails) =>
                {
                    resultOrder ??= order;  //jesli resorder jest nullem to daj mu order 
                    if (resultOrder == null) resultOrder = order;
                    
                    resultOrder.Details.Add(orderDetails);
                    return resultOrder;
                },
                new { id },
                splitOn: "OrderId"
            );

        }

        public void Select(IDbConnection connection) 
        {
            var sql = "SELECT * FROM Region";
            var regions = connection.Query(sql);

            foreach (var item in regions)
            {
                Console.WriteLine($"{item.RegionId} {item.RegionDescription}");
            }
        }

        public int Insert(IDbConnection connection, Region region) 
        {
            var insertSql = "INSERT INTO Region( regionId, regionDescription) VALUES (@id, @desc)";
            return connection.Execute(insertSql,
                    new { id = 120, desc = region } 
                    ); 
            
        }
        public int Insert(IDbConnection connection, int id, string description)
        {
            var insertSql = "INSERT INTO Region( regionId, regionDescription) VALUES (@id, @desc)";
            return connection.Execute(insertSql,
                    new
                    {
                        id,
                        desc = description
                    } //zawiera typ anonimowy ->trakyowane jako klasa
                    );
        }
        public int Delete(IDbConnection connection, int id)
        {
            var sql = "DELETE FROM Region WHERE regionId =@id";
            return connection.Execute(sql, id);
        }
    }
}
