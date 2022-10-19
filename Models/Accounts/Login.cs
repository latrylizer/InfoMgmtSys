using MySql.Data.MySqlClient;
using System.Reflection;
using InfoMgmtSys.Security;
using System.Web;

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
        
        

        public static dynamic ExeLogin(AppDB db, Object obj)
        {
                return ToList(db.ExeDrStoredProc(db, obj, "Login"));
        }
        public static dynamic ToList(MySqlDataReader dr)
        {
            var obj = new Login();
            if (dr.HasRows)
            {
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
            else
            {
                return "Account Does Not Exist";
            }
          
           
        }
        public class LoginParams
        {
            public string? Username { get; set; }
            public string? Password { get; set; }

        }
    }
}
