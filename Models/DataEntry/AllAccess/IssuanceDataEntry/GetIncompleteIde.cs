using MySql.Data.MySqlClient;
using System.Reflection;

namespace InfoMgmtSys.Models.DataEntry.AllAccess.IssuanceDataEntry
{
    public class GetIncompleteIde
    {
        public int MIS_no { get; set; }

        public static List<GetIncompleteIde> ExeGetIncompleteIde(AppDB db, object obj)
        {
            return ToList(db.ExeDrStoredProc(db, obj, "Get_incomplete_ide"));
        }

        public static List<GetIncompleteIde> ToList(MySqlDataReader dr)
        {
            var e = new List<GetIncompleteIde>();
            while (dr.Read())
            {
                var obj = new GetIncompleteIde();
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
