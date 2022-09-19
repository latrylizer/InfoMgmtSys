using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace InfoMgmtSys.Models.DataEntry.AllAccess.IssuanceDataEntry
{
    public class GetIdeByMisNo
    {
        public int MIS_No { get; set; }
        public string? Issued_to { get; set; }
        public int Cycle_no { get; set; }
        public int Hectarage { get; set; }
        public int RR_no { get; set; }
        public string? Date_time { get; set; }
        public int Terms { get; set; }
        public string? Start_date_of_collection { get; set; }
        public string? Due_date { get; set; }
        public string? Mark_up { get; set; }
        public double Admin_fee { get; set; }
        public string? Collection_terms { get; set; }
        public int Collection_terms_weekly { get; set; }
        public string? Service_provider { get; set; }
        public double Total_amount_payable_to_trucker { get; set; }
        public int Is_complete { get; set; }

        public static List<GetIdeByMisNo> ExeGetIdeByMisNo(AppDB db, Object obj)
        {
            return ToList(db.ExeDrStoredProc(db, obj, "Get_ide_by_MIS_no"));
        }

        public static List<GetIdeByMisNo> ToList(MySqlDataReader dr)
        {
            var e = new List<GetIdeByMisNo>();
            while (dr.Read())
            {
                var obj = new GetIdeByMisNo();
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
        public class GetIdeByMisNoParams
        {
            [FromHeader]
            public int MIS_no { get; set; }
        }

    }
    
}
