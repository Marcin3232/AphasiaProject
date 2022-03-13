using DataBaseProject.Enums.Db;
using System.ComponentModel.DataAnnotations;
using System.Configuration;


namespace DataBaseProject.Utils
{
    public static class ConnectionString
    {
        public static string Get(DbConnectionsString db) =>
            ConfigurationManager.ConnectionStrings[db.GetAttribute<DisplayAttribute>().Name].ConnectionString;
    }
}
