using MySql.Data.MySqlClient;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace InfoMgmtSys.Models.DataEntry.AllAccess.ReceivedDataEntry
{
    public class GetRdeOrderByRrNo
    {
        public int Entry_no { get; set; }
        public int RR_no { get; set; }
        public string? Item_description { get; set; }
        public string? UOM { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public class GetRdeOrderByRrNoParams
        {
            [FromHeader]
            public int RR_no { get; set; }
        }
        public static List<GetRdeOrderByRrNo> ExeGetRdeOrderByRrNo(AppDB db, object obj)
        {
            var toList = ToList(db.ExeDrStoredProc(db, obj, "Get_rde_order_by_rr_no"));
            db.conClose();
            return toList;
        }
        public static List<GetRdeOrderByRrNo> ToList(MySqlDataReader dr)
        {
            var e = new List<GetRdeOrderByRrNo>();
            while (dr.Read())
            {
                var obj = new GetRdeOrderByRrNo();
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
