using MySql.Data.MySqlClient;
using System.Reflection;

namespace InfoMgmtSys.Models.DataEntry
{
    public class DataEntryIssuance
    {
        public int Id { get; set; }
        public int Mis_no { get; set; }
        public string? Issue_to { get; set; }
        public int Cycle_no { get; set; }
        public int Hectarage { get; set; }
        public int RR_no_reference { get; set; }
        public string? Date_time { get; set; }
        public int Terms { get; set; }
        public int Collection_term { get; set; }
        public string? Start_date_of_collection { get; set; }
        public string? Due_date { get; set; }
        public string? Mark_up { get; set; }
        public double Admin_fee { get; set; }
        public string? Item_description { get; set; }
        public string? UOM { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public double Top_selling_price { get; set; }
        public double Top_sales { get; set; }
        public double Vat { get; set; }
        public double Item_admin_fee { get; set; }
        public double Total { get; set; }
        public double Total_amount_vat_inclusive { get; set; }
        public double Percent_vat { get; set; }
        public double Total_amount_net_of_vat { get; set; }
        public double Total_admin_fee { get; set; }

        public string? Service_provider { get; set; }
        public double Total_amount_payable_to_trucker { get; set; }
        public double Total_recievable_to_grower { get; set; }
        public int Credit_term { get; set; }
        public int Total_collection_term { get; set; }
        public int Control_no { get; set; }
        public int Status { get; set; }
        public bool AddDataEntryRecieved(AppDB db, DataEntryIssuance dei)
        {
            return db.AddStoredProc(db, dei, "Add_data_entry_issuance");
        }
        public static List<DataEntryIssuance> GetAllDataEntryIssuance(AppDB db)
        {
            return DataEntryIssuancesToList(db.ExeDr(db, "select * from data_entry_issuance"));
        }
        public static List<DataEntryIssuance> DataEntryIssuancesToList(MySqlDataReader dr)
        {
            var e = new List<DataEntryIssuance>();
            while (dr.Read())
            {
                var obj = new DataEntryIssuance();
                var length = obj.GetType().GetProperties().Length;
                for (int num1 = 0; num1 < length; num1++)
                {
                    string data = obj.GetType().GetProperties()[num1].Name.ToString() ?? "";
                    Type type = obj.GetType();
                    PropertyInfo? prop = type.GetProperty(data);

                    if (prop != null)
                    {
                        Utils.Parser.prop(obj,prop, data, dr);
                    }

                }
                e.Add(obj);

            }
            return e;
        }
    }


}
