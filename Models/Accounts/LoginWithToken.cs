using MySql.Data.MySqlClient;
using System.Reflection;
using InfoMgmtSys.Security;
using Microsoft.AspNetCore.Mvc;

namespace InfoMgmtSys.Models.Accounts
{
    public class LoginWithToken
    {
        public string? Token { get; set; }
        public static string ExeGetToken(AppDB db, object obj)
        {
            var data = ToList(db.ExeDrStoredProc(db, obj, "Login"));

            if (data.Count > 0)
            {
                var token = Tokens.CreateToken();
                return token;
            }
            else
            {
                return "Account don't exist";
            }
            
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
            [FromHeader]
            public string? username{ get; set; }
            [FromHeader]
            public string? password { get; set; }
        }

    }
}
