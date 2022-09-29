using MySql.Data.MySqlClient;
using System.Reflection;

namespace InfoMgmtSys.Models.DataEntry.Warehouseman.ReceivedDataEntry
{
    public class AddRdeReturnRrNo
    {
        public string? Supplier { get; set; }
        public int Terms { get; set; }
        public string? Grower { get; set; }
        public string? Date_time { get; set; }
        public string? PO_reference { get; set; }
        public int DR_no { get; set; }
        public string? Trucker { get; set; }
        public string? Trucker_plate_no { get; set; }
        public string? Warehouse { get; set; }
        public string? Service_provider { get; set; }

        public bool ExeAddRde(AppDB db, AddRdeReturnRrNo addRdeReturnRrNo)
        {
            return db.AddStoredProc(db, addRdeReturnRrNo, "Add_rde_return_rr_no");
        }
        public int ExeAddRdeReturnRrNo(AppDB db, Object obj)
        {

            int RR_no = ToList(db.ExeDrStoredProc(db,obj, "Add_rde_return_rr_no"))[0].RR_no;
            return RR_no;
        }

        public static List<LastInsertedId> ToList(MySqlDataReader dr)
        {
            var e = new List<LastInsertedId>();
            while (dr.Read())
            {
                var obj = new LastInsertedId();
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

        public class LastInsertedId
        {
            public int RR_no { get; set; }
        }
    }
}
