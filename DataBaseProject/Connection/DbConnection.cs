using DataBaseProject.CreateDatabase;
using DataBaseProject.Enums.Db;
using DataBaseProject.Utils;
using Npgsql;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace DataBaseProject.Connection
{
    public class DbConnection
    {
        public IDbConnection Connection()
        {
            TryConnection(out var result, out var ex);

            if (result != null)
            {
                Console.WriteLine($"{DateTime.Now} || INFO: Try create database from server.");

                if (result == SqlExceptionVariable.ValueState()
                    && TryDefaultConnection())
                {
                    var connDb = new DbService();
                    if (connDb.CreateDatabase())
                        return new NpgsqlConnection(ConnectionString.Get(DbConnectionsString.DbAphasia));
                }
                else
                {
                    Console.WriteLine($"{DateTime.Now} || ERROR: Cant create new database. Error code: ");
                    Console.WriteLine($"{DateTime.Now} || ERROR DESC: {ex}");
                    return null;
                }
            }
            return new NpgsqlConnection(ConnectionString.Get(DbConnectionsString.DbAphasia));
        }

        private void TryConnection(out string? result, out string exception)
        {
            result = null;
            exception = "";
            try
            {
                var tryConn = new NpgsqlConnection(ConnectionString.Get(DbConnectionsString.DbAphasia));
                tryConn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now} || ERROR: Cannot open connection to RCP");
                exception = ex.ToString();
                var exExist = GetCodeEx(ex.Data) is string;
                result = exExist ? (string?)GetCodeEx(ex.Data) : "error";
            }
        }

        private bool TryDefaultConnection()
        {
            try
            {
                var conn = new NpgsqlConnection(ConnectionString.Get(DbConnectionsString.DbDefault));
                conn.Open();
                conn.Close();
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"{DateTime.Now} || ERROR: Cannot open default connection.");
                Console.WriteLine($"{DateTime.Now} || ERROR DESC: {ex}");
                Console.WriteLine($"{DateTime.Now} || INFO: App will close.");
                return false;
            }
        }

        private object? GetCodeEx(IDictionary data)
        {
            try
            {
                return data[SqlExceptionVariable.KeyState()];
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
