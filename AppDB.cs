using MySql.Data.MySqlClient;
using System;
namespace InfoMgmtSys
{
    public sealed class AppDB: IDisposable
    {
        MySqlConnection conn;
        public static readonly string? connectionString;
        static AppDB()
        {
            var mysqlstring = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Port = 3306,
                Database = "info_db",
                UserID = "root",
                Password = "Douls102798",
                SslMode = MySqlSslMode.Disabled,
                ConvertZeroDateTime = false,

            };
            connectionString = mysqlstring.ConnectionString;
            Console.WriteLine("Initializing DB...");
            var db = initDb();
            Console.WriteLine(db ? "Connetion Success" : "No Connection!");


        }
        internal static bool initDb()
        {
            using var conn = new AppDB();
            var res = conn.isDbExist();
            return res;
        }
        public bool isDbExist()
        {
            using var cmd = CreateCommand("SHOW DATABASES LIKE 'info_db'");
            using var reader = cmd.ExecuteReader();
            return reader.HasRows;
        }
        public AppDB()
        {
            conn = new MySqlConnection(connectionString);
            conn.Open();
        }

        public MySqlCommand CreateCommand (string query)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = query;    
            return cmd;
        }
        public MySqlDataReader ExeDr(AppDB db, string query)
        {
            using var cmd = db.CreateCommand(query);
            var dr = cmd.ExecuteReader();
            return dr;
        }
        public MySqlCommand StoredProc(string storedProcName)
        {
            using var query = CreateCommand(storedProcName);
            query.CommandType = System.Data.CommandType.StoredProcedure;
            return query;
        }
        public MySqlCommand Param(MySqlCommand query, string parameter, string value)
        {
            query.Parameters.AddWithValue(parameter, value);
            return query;
        }
        public bool AddStoredProc(AppDB db, object obj, string storedProc)
        {
            using var query = db.StoredProc(storedProc);
            var count = obj.GetType().GetProperties().Length;
            for (int num1 = 0; num1 < count; num1++)
            {
                string name = obj.GetType().GetProperties()[num1].Name;
                string value = obj.GetType().GetProperties()[num1].GetValue(obj, null)?.ToString() ?? "";
                db.Param(query, name, value);
            }
            var hasRows = query.ExecuteNonQuery();
            return hasRows == 1; ;
        }
        public void Dispose() => conn.Dispose();
    }
}
