using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace InfoMgmtSys.Models.DataEntry.AllAccess.ReceivedDataEntry
{
    public class GetRdeSummaryReport
    {
        public string? Supplier { get; set; }
        public int Charge_sale_invoice { get; set; }
        public int Terms { get; set; }
        public string? Grower { get; set; }
        public int RR_no { get; set; }
        public string? Date_time { get; set; }
        public string? PO_reference { get; set; }
        public int DR_no { get; set; }
        public int APV_no { get; set; }
        public string? Item_description { get; set; }
        public string? UOM { get; set; }
        public double Qty { get; set; }
        public double Price { get; set; }
        public double ExVat { get; set; }
        public double Vat { get; set; }
        public double Subtotal { get; set; }
        public double EWT { get; set; }
        public double Admin_fee { get; set; }

        public static List<GetRdeSummaryReport> ExeGetRdeSummaryReport(AppDB db, object obj)
        {
            return ToList(db.ExeDrStoredProc(db, obj, "Get_rde_summary_report"));
        }
        public class GetRdeSummaryReportParams
        {
            [FromHeader]
            public int RR_no { get; set; }
        }
        public static List<GetRdeSummaryReport> ToList(MySqlDataReader dr)
        {
            var e = new List<GetRdeSummaryReport>();
            while (dr.Read())
            {
                var obj = new GetRdeSummaryReport();
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
