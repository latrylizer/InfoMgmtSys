using MySql.Data.MySqlClient;
using System.Reflection;
using InfoMgmtSys.Security;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace InfoMgmtSys.Models.Accounts
{
    public class LoginWithToken
    {
        public class LoginResult
        {
            public string? Name { get; set; }
            public string? Position { get; set; }
            public string? Token { get; set; }
        }
        public class UserDetail
        {
            public string? Position_name { get; set; }
            public string? First_name { get; set; }
            public string? Middle_name { get; set; }
            public string? Last_name { get; set; }
            public int Can_update { get; set; }
            public int Can_delete { get; set; }
            public int Can_Add { get; set; }
            public int Can_view { get; set; }
        }
        public string? Token { get; set; }
        public static dynamic ExeGetToken(AppDB db, object obj)
        {
            try
            {
                var data = ToList(db.ExeDrStoredProc(db, obj, "Login"));
                var loginResult = new LoginResult();
                if (data.First_name != null)
                {
                    var token = Tokens.CreateToken(data.First_name + " " + data.Last_name, data.Position_name!);
                    loginResult.Name = data.First_name + " " + data.Last_name;
                    loginResult.Position = data.Position_name;
                    loginResult.Token = token;
                    return loginResult;
                }
                else
                {
                    return "Account don't exist";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }    
           


        }
        public static UserDetail ToList(MySqlDataReader dr)
        {
            var obj = new UserDetail();

            while (dr.Read())
            {
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
            };
            return obj;
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
