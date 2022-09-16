using MySql.Data.MySqlClient;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace InfoMgmtSys.Models.DataEntry.AllAccess.ReceivedDataEntry
{
    public class GetRdeByRrNo
    {
        public int RR_no { get; set; }
        public string? Supplier { get; set; }
        public int Charge_sale_invoice { get; set; }
        public int Terms { get; set; }
        public string? Grower { get; set; }
        public int APV_no { get; set; }
        public string? Date_time { get; set; }
        public string? PO_reference { get; set; }
        public int DR_no { get; set; }
        public int Job_order_no { get; set; }
        public string? Trucker { get; set; }
        public string? Trucker_plate_no { get; set; }
        public string? Warehouse { get; set; }
        public string? Service_provider { get; set; }
        public double Total_amount_payable_to_trucker { get; set; }
        public int Is_complete { get; set; }
        public static List<GetRdeByRrNo> ExeGetRdeByRrNo(AppDB db, object obj)
        {
            return ToList(db.ExeDrStoredProc(db, obj, "Get_rde_by_RR_no"));
        }
        public static List<GetRdeByRrNo> ToList(MySqlDataReader dr)
        {
            var e = new List<GetRdeByRrNo>();
            while (dr.Read())
            {
                var obj = new GetRdeByRrNo();
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
        public class GetRdeByRrNoParams
        {
            [FromHeader]
            public int RR_no { get; set; }
        }

    }
}
