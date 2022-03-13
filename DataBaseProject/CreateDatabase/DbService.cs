using Dapper;
using DataBaseProject.Enums.Db;
using DataBaseProject.Utils;
using DataBaseQuery.Database;
using Npgsql;
using System.Data;

namespace DataBaseProject.CreateDatabase
{
    public class DbService
    {
        public bool CreateDatabase()
        {
            var tempConn = new NpgsqlConnection(ConnectionString.Get(DbConnectionsString.DbAphasia));
            var database = tempConn.Database;

            using (IDbConnection conn = new NpgsqlConnection(ConnectionString.Get(DbConnectionsString.DbDefault)))
            {
                DbConnection.Open(conn);

                try
                {
                    conn.Execute(AphasiaDb.InitDatabase(database), null, commandType: CommandType.Text);
                    Console.WriteLine($"{DateTime.Now} || INFO: Create database name: {database}");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{DateTime.Now} || ERROR: cant create database.");
                    Console.WriteLine($"{DateTime.Now} || ERROR DESC: {ex}");
                    return false;
                }
            }
        }
    }
}
