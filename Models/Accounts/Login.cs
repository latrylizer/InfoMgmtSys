using MySql.Data.MySqlClient;
using System.Reflection;
using InfoMgmtSys.Security;

namespace InfoMgmtSys.Models.Accounts
{
    public class Login
    {
        public int Id { get; set; }
        public string? Position_name { get; set; }
        public string? First_name { get; set; }
        public string? Middle_name { get; set; }
        public string? Last_name { get; set; }
        public int Can_update { get; set; }
        public int Can_delete { get; set; }
        public int Can_Add { get; set; }
        public int Can_view { get; set; }
        
        

        public static List<Login> ExeLogin(AppDB db, Object obj)
        {
            return ToList(db.ExeDrStoredProc(db, obj, "Login"));
        }
        public static List<Login> ToList(MySqlDataReader dr)
        {
            var e = new List<Login>();
            while (dr.Read())
            {
                var obj = new Login();
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
            };
           
            return e;
        }
        public class LoginParams
        {
            public string? Username { get; set; }
            public string? Password { get; set; }

        }
    }
}
