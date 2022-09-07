using MySql.Data.MySqlClient;
using System.Reflection;
namespace InfoMgmtSys.Models.DataEntry
{
    public class DataEntryReceived
    {

        //public string? Supplier { get; set; }
        //public int Charge_or_sales_invoice_no { get; set; }
        //public int Terms { get; set; }
        //public string? Grower { get; set; }
        //public int RR_no { get; set; }
        //public string? RR_date { get; set; }
        //public string? Due_date { get; set; }
        //public string? Funding_date { get; set; }
        //public string? PO_reference { get; set; }
        //public int DR_no { get; set; }
        //public int APV_number { get; set; }
        //public int JO_no { get; set; }
        //public string? Trucker { get; set; }
        //public int Trucker_plate_No{ get; set; }
        //public string? Item_description { get; set; }
        //public string? UOM { get; set; }
        //public int Qty { get; set; }
        //public double Price { get; set; }
        //public double Unit_cost { get; set; }
        //public double Vat { get; set; }
        //public double Sub_total { get; set; }
        //public double EWT { get; set; } 
        //public double Admin_fee { get; set; }
        //public int Status { get; set; }
        public int Id { get; set; }
        public string? Supplier { get; set; }
        public int Charge_or_sales_invoice { get; set; }
        public int Terms { get; set; }
        public string? Grower { get; set; }
        public int RR_no { get; set; }
        public int APV_no { get; set; }
        public string? Date_time { get; set; }
        public string? PO_reference { get; set; }
        public int DR_no { get; set; }
        public int JO_no { get; set; }
        public string? Trucker { get; set; }
        public int Trucker_plate_no { get; set; }
        public string? Warehouse { get; set; }
        public string? Item_description { get; set; }
        public int UOM { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public double Total { get; set; }
        public double Total_amount_before_vat { get; set; }
        public int vat { get; set; }
        public double Total_amount_net_of_vat { get; set; }
        public string? Service_provider { get; set; }
        public double Total_amount_payable_to_trucker { get; set; }
        public int Status { get; set; }
        public bool AddDataEntryRecieved(AppDB db, DataEntryReceived der)
        {
            return db.AddStoredProc(db, der, "Add_data_entry_recieved");
        }
        public static List<DataEntryReceived> GetAllDataEntryRecieved(AppDB db)
        {
            return DataEntryReceivedToList(db.ExeDr(db, "select * from data_entry_recieved"));
        }
        public static List<DataEntryReceived> DataEntryReceivedToList(MySqlDataReader dr)
        {
            var e = new List<DataEntryReceived>();
            while (dr.Read())
            {
                var obj = new DataEntryReceived();
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
