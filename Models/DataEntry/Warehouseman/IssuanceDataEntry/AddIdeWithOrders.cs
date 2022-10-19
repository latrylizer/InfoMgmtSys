using MySql.Data.MySqlClient;
using System.Reflection;

namespace InfoMgmtSys.Models.DataEntry.Warehouseman.IssuanceDataEntry
{
    public class AddIdeWithOrders
    {
        public string? Issued_to { get; set; }
        public int Cycle_no { get; set; }
        public string? Service_provider { get; set; }
        public int Hectarage { get; set; }

        public List<IdeOrders>? Orders { get; set; }

        public string ExeAddIdeWithOrders(AddIdeWithOrders addIdeWithOrders)
        {
           
            try
            {
                var db = new AppDB();
                var IdeContainer = new Ide();
                var Ide = IdeContainer.GetIde(addIdeWithOrders);
                int MIS_no = ToList(db.ExeDrStoredProc(db, Ide, "Add_ide_return_mis_no"))[0].MIS_no;
                var OrderContainer = new IdeOrders();
                var OrderList = OrderContainer.GetOrderList(addIdeWithOrders, MIS_no);
                for (int num1 = 0; num1 < OrderList.Count; num1++)
                {
                    db = new AppDB();
                    db.AddStoredProc(db, OrderList[num1], "Add_ide_orders");
                }
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
            public int MIS_no { get; set; }
        }
    }
    

}
