using MySql.Data.MySqlClient;
using System.Reflection;

namespace InfoMgmtSys.Models.DataEntry.AllAccess.IssuanceDataEntry
{
    public class CollectionOfIdeOrdersSummaryContainer
    {
        public string? Issued_to { get; set; }
        public int Cycle_no { get; set; }
        public int Hectarage { get; set; }
        public int MIS_no { get; set; }
        public int RR_no { get; set; }
        public string? Date_time { get; set; }
        public string? Service_provider { get; set; }
        public string? Item_description { get; set; }
        public string? UOM { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public string? Mark_up { get; set; }
        public double Total_Sales { get; set; }
        public double Vat { get; set; }
        public double Admin_fee { get; set; }
        public double Total_amount_payable_to_trucker { get; set; }
        public double Total_advances { get; set; }
        public string? Particulars { get; set; }
        public int Terms { get; set; }
        public int Collection_terms { get; set; }
        public string? Collection_terms_in_words { get; set; }
        public string? Start_date_of_collection { get; set; }
        public string? Due_date { get; set; }
        public string? Due_for_collection { get; set; }
        public string? Date_of_collection { get; set; }
        public double Amount { get; set; }
        public List<CollectionOfIdeOrdersSummaryContainer> ToList(MySqlDataReader dr)
        {
            var e = new List<CollectionOfIdeOrdersSummaryContainer>();
            while (dr.Read())
            {
                var obj = new CollectionOfIdeOrdersSummaryContainer();
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
