using MySql.Data.MySqlClient;
using System.Reflection;
namespace InfoMgmtSys.Models.DataEntry.Warehouseman
{
    public class GetReviewSheet
    {
        public string? Supplier { get; set; }
        public int Charge_or_sales_invoice { get; set; }
        public int Terms { get; set; }
        public string? Grower { get; set; }
        public int RR_no { get; set; }
        public string? Date_time { get; set; }
        public string? Due_date { get; set; }
        public string? Funding_date { get; set; }
        public string? PO_reference { get; set; }
        public int DR_no { get; set; }
        public int APV_no { get; set; }
        public string? Item_description { get; set; }
        public string? UOM { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public double ExVat { get; set; }
        public double Vat { get; set; }
        public double Subtotal { get; set; }
        public double EWT { get; set; }
        public double Admin_fee { get; set; }

        public static List<GetReviewSheet> GetDataEntryReveivedReviewSheet(AppDB db, object obj)
        {
            return ToList(db.ExeDrStoredProc(db, obj, "Get_receiving_data_entry_review_sheet"));
        }
        public static List<GetReviewSheet> ToList(MySqlDataReader dr)
        {
            var e = new List<GetReviewSheet>();
            while (dr.Read())
            {
                var obj = new GetReviewSheet();
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
