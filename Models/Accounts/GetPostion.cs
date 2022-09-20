using MySql.Data.MySqlClient;
using System.Reflection;

namespace InfoMgmtSys.Models.Accounts
{
    public class GetPostion
    {
        public int Id { get; set; }
        public string? Position_name { get; set; }

        public static List<GetPostion> ExeGetPosition(AppDB dB)
        {
            object obj = new object();
            return ToList(dB.ExeDrStoredProc(dB, obj, "Get_position"));
        }

        public static List<GetPostion> ToList(MySqlDataReader dr)
        {
            var e = new List<GetPostion>();
            while (dr.Read())
            {
                var obj = new GetPostion();
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
    }
}
