using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace InfoMgmtSys.Models.DataEntry.AllAccess.IssuanceDataEntry
{
    public class GetCollectionOfIdeOrdersSummary
    {
        public string? Issued_to { get; set; }
        public int Cycle_no { get; set; }
        public int Hectarage { get; set; }
        public int MIS_no { get; set; }
        public int RR_no { get; set; }
        public string? MIS_Date { get; set; }
        public string? Trucker { get; set; }
        public string? Item_Description { get; set; }
        public string? UOM { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public string? Mark_up { get; set; }
        public double Total_Sales { get; set; }
        public double Vat { get; set; }
        public double Admin_fee { get; set; }
        public double Trucker_cost { get; set; }
        public double Total_advances { get; set; }
        public string? Particulars { get; set; }
        public int Terms { get; set; }
        public string? Collection_terms { get; set; }
        public int Collection_terms_weekly { get; set; }
        public string? Start_date_of_collection { get; set; }
        public string? Due_date { get; set; }
        public string? Due_for_collection { get; set; }
        public string? Date_time { get; set; }
        public double Amount { get; set; }

        public static List<GetCollectionOfIdeOrdersSummary> ExeGetCollectionOfIdeOrdersSummary(AppDB db, object obj)
        {
            return ToList(db.ExeDrStoredProc(db, obj, "Get_collection_of_ide_orders_summary"));
        }

        public static List<GetCollectionOfIdeOrdersSummary> ToList(MySqlDataReader dr)
        {
            var e = new List<GetCollectionOfIdeOrdersSummary>();
            while (dr.Read())
            {
                var obj = new GetCollectionOfIdeOrdersSummary();
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

        public class GetCollectionOfIdeOrdersSummaryParams
        {
            [FromHeader]
            public int MIS_no { get; set; }
        }

    }
}
