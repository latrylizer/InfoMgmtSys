using MySql.Data.MySqlClient;
using System.Reflection;

namespace InfoMgmtSys.Models.DataEntry.AllAccess.IssuanceDataEntry
{
    public class GetLatestIdeMisNo
    {
        public int MIS_no { get; set; }

        public static List<GetLatestIdeMisNo> ExeGetLatestIdeMisNo(AppDB db, Object obj)
        {
            return ToList(db.ExeDrStoredProc(db, obj, "Get_latest_ide_MIS_no"));
        }
        public static List<GetLatestIdeMisNo> ToList(MySqlDataReader dr)
        {
            var e = new List<GetLatestIdeMisNo>();
            while (dr.Read())
            {
                var obj = new GetLatestIdeMisNo();
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
