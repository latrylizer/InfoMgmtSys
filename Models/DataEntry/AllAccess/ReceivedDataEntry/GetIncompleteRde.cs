using MySql.Data.MySqlClient;
using System.Reflection;

namespace InfoMgmtSys.Models.DataEntry.AllAccess.ReceivedDataEntry
{
    public class GetIncompleteRde
    {
        public int RR_no { get; set; }

        public static List<GetIncompleteRde> ExeGetIncompleteRde(AppDB db)
        {
            object obj = new object() ;
            var toList = ToList(db.ExeDrStoredProc(db, obj, "Get_incomplete_rde"));
            db.conClose();
            return toList;
        }

        public static List<GetIncompleteRde> ToList(MySqlDataReader dr)
        {
            var e = new List<GetIncompleteRde>();
            while (dr.Read())
            {
                var obj = new GetIncompleteRde();
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
