using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Reflection;
using System.Web;
using InfoMgmtSys.Models.Logs;
namespace InfoMgmtSys.Models.DataEntry.Warehouseman.ReceivedDataEntry
{
    public class AddRdeWithOrders
    {
        public string? Supplier { get; set; }
        public int Terms { get; set; }
        public string? Grower { get; set; }
        public string? PO_reference { get; set; }
        public int DR_no { get; set; }
        public string? Trucker { get; set; }
        public string? Trucker_plate_no { get; set; }
        public string? Warehouse { get; set; }
        public List<Orders>? Orders { get; set; }

        public string ExeAddRdeWithOrders(AddRdeWithOrders addRdeWithOrders, HttpContext httpContext)
        {
            try
            {
                var db = new AppDB();

                var RdeContainer = new Rde();
                var Rde = RdeContainer.GetRde(addRdeWithOrders);

                int RR_no = ToList(db.ExeDrStoredProc(db, Rde, "Add_rde_return_rr_no"))[0].RR_no;
                var OrderContainer = new Orders();
                var OrderList = OrderContainer.GetOrders(addRdeWithOrders, RR_no);
                for (int num1 = 0; num1 < OrderList.Count; num1++)
                {
                    db = new AppDB();
                    db.AddStoredProc(db, OrderList[num1], "Add_rde_orders");
                }
                AddLogs.ExeAddLogs(addRdeWithOrders, httpContext, "Receiving", RR_no, "Create");
                return "Success";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
             
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
