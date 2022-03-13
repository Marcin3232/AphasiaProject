using System.Data;

namespace DataBaseProject.Utils
{
    public class DbConnection
    {
        public static void Open(IDbConnection conn)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }
    }
}
