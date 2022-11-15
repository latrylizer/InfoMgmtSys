using MySql.Data.MySqlClient;
using System.Reflection;
using System.Text.Json;

namespace InfoMgmtSys.Models.Logs
{
    public class GetLogs
    {
        public int Log_id { get; set; }
        public string? Date_time { get; set; }
        public int Report_id { get; set; }
        public string? Report_type { get; set; }
        public string? Client { get; set; }
        public string? Role { get; set; }

        public string? Action { get; set; }

        public object? Data { get; set; }

        public class GetLogsBySearchParams
        {
            public string? search { get; set; }
        }

        public static dynamic ExeGetLogs()
        {
            try
            {
                var newGetLogs = new GetLogs();
                var db = new AppDB();
                var obj = new object();
                var result = newGetLogs.ToList(db.ExeDrStoredProc(db, obj, "Get_logs_current_month"));
                db.conClose();
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }
        public static dynamic ExeGetLogsBySearch(GetLogsBySearchParams getLogsBySearchParams)
        {
            try
            {
                if(getLogsBySearchParams.search == null)
                {
                    return new object();
                }
                var newGetLogs = new GetLogs();
                var db = new AppDB();
                var result = newGetLogs.ToList(db.ExeDrStoredProc(db, getLogsBySearchParams, "Get_logs_by_search"));
                db.conClose();
                return result;
            }
            catch(Exception ex) {
                return ex.Message;
            }
        }
        public List<GetLogs> ToList(MySqlDataReader dr)
        {
            var e = new List<GetLogs>();
            while (dr.Read())
            {
                var obj = new GetLogs();
                var length = obj.GetType().GetProperties().Length;
                for (int num1 = 0; num1 < length; num1++)
                {
                    string data = obj.GetType().GetProperties()[num1].Name.ToString() ?? "";
                    Type type = obj.GetType();
                    PropertyInfo? prop = type.GetProperty(data);

                    if (prop != null)
                    {
                        Utils.Parser.prop(obj, prop, data, dr);
                    }

                }
                e.Add(obj);
            }
            return e;
        }
    }
}
