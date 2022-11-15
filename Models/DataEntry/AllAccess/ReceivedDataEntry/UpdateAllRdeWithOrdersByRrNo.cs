using MySql.Data.MySqlClient;
using System.Reflection;
using System.Text;
using System.Text.Json;
using InfoMgmtSys.Utils;
using InfoMgmtSys.Models.Logs;
using System.Web;

namespace InfoMgmtSys.Models.DataEntry.AllAccess.ReceivedDataEntry
{
    public class UpdateAllRdeWithOrdersByRrNo
    {
        public int RR_no { get; set; }
        public string? Supplier { get; set; }
        public int Charge_sale_invoice { get; set; }
        public int Terms { get; set; }
        public string? Grower { get; set; }
        public int APV_no { get; set; }
        public string? PO_reference { get; set; }
        public int DR_no { get; set; }
        public int Job_order_no { get; set; }
        public string? Trucker { get; set; }
        public string? Trucker_plate_no { get; set; }
        public string? Warehouse { get; set; }
        public double Total_amount_payable_to_trucker { get; set; }
        public int Is_complete { get; set; }
        public List<UpdateAllRdeWithOrdersByRrNoContainer.UpdateAllRdeOrder>? Orders { get; set; }

       public dynamic ExeUpdateAllRdeWithOrdersByRrNo(UpdateAllRdeWithOrdersByRrNo updateAllRdeWithOrdersByRrNo, HttpContext httpContext)
        {
            try
            {
                if (updateAllRdeWithOrdersByRrNo.RR_no == 0)
                {
                    return "RR no should not be 0";
                }
                var db = new AppDB();
                var overrideUpdateOrderLogs = new AddLogs.OverrideUpdateOrderLogs();
                var logs = new UpdateAllRdeWithOrdersByRrNoContainer.UpdateAllRdeWithOrdersLogs();
                var rdeWithOrdersContainer = new UpdateAllRdeWithOrdersByRrNoContainer();
                var getRdeByRrNoParams = new GetRdeByRrNo.GetRdeByRrNoParams();
                getRdeByRrNoParams.RR_no = updateAllRdeWithOrdersByRrNo.RR_no;
                var getRdeByRrNo = GetRdeByRrNo.ExeGetRdeByRrNo(db, getRdeByRrNoParams);
                var rde = rdeWithOrdersContainer.GetRde(updateAllRdeWithOrdersByRrNo);
                var newRde = new UpdateAllRdeWithOrdersByRrNoContainer.UpdateAllRde();
                var name = rde.GetType().GetProperties()[0];
                db = new AppDB();
                var prevRde = updateAllRdeWithOrdersByRrNo.ToList(db.ExeDrStoredProc(db, getRdeByRrNoParams, "Get_rde_by_rr_no_manager"));
                db.conClose();



                if (prevRde.RR_no == 0)
                {
                    return "RR no " + rde.RR_no + " does not Exist";
                }

                if (updateAllRdeWithOrdersByRrNo.Orders != null)
                {
                    for (int a = 0; a < updateAllRdeWithOrdersByRrNo.Orders.Count; a++)
                    {
                        if (updateAllRdeWithOrdersByRrNo.Orders[a].Entry_no == 0)
                        {
                            return "Entry no should not be 0";
                        }
                    }
                }


                Parser.containObject(rde, newRde, prevRde);
                logs.RR_no = getRdeByRrNoParams.RR_no;
                logs.RR!.Add(Parser.showChanged(rde, prevRde));

                db = new AppDB();
                db.AddStoredProc(db, newRde, "Update_all_rde_by_RR_no");

                var rdeLog = AddLogs.CompareObj(rde, prevRde);
                if(rdeLog.Count > 0)
                {
                    overrideUpdateOrderLogs.DataEntry = rdeLog;
                }
                overrideUpdateOrderLogs.Orders = new List<dynamic>();
                for (int a = 0; a < updateAllRdeWithOrdersByRrNo.Orders!.Count; a++)
                {
                    db = new AppDB();
                    var rdeOrder = new UpdateAllRdeWithOrdersByRrNoContainer.UpdateAllRdeOrder();
                    var getRdeOrderByEntryNoParams = new UpdateAllRdeWithOrdersByRrNoContainer.GetRdeOrdeByEntryNoParams();
                    getRdeOrderByEntryNoParams.Entry_no = updateAllRdeWithOrdersByRrNo.Orders[a].Entry_no;
                    getRdeOrderByEntryNoParams.RR_no = getRdeByRrNoParams.RR_no;
                    var prevRdeOrder = TolistOrders(db.ExeDrStoredProc(db, getRdeOrderByEntryNoParams, "Get_rde_order_by_entry_no_and_rr_no"));
                    db.conClose();

                    if (prevRdeOrder.Entry_no == 0)
                    {
                        return "Entry no " + updateAllRdeWithOrdersByRrNo.Orders[a].Entry_no + " does not exist";
                    }

                    Parser.containObject(updateAllRdeWithOrdersByRrNo.Orders[a], rdeOrder, prevRdeOrder);

                    var orderParamLogs = new UpdateAllRdeWithOrdersByRrNoContainer.UpdateAllRdeWithOrdersLogs.UpdateAllRdeWithOrderLogs();
                    var orderShowChanged = Parser.showChanged(rdeOrder, prevRdeOrder);
                    orderParamLogs.Order!.Add(orderShowChanged);
                    orderParamLogs.Entry_no = updateAllRdeWithOrdersByRrNo.Orders[a].Entry_no;
                    logs.Orders!.Add(orderParamLogs);
                    db = new AppDB();
                    db.AddStoredProc(db, rdeOrder, "Update_all_rde_order_by_entry_no");
                    var rdeOrderLog = AddLogs.CompareOrderObj(updateAllRdeWithOrdersByRrNo.Orders[a].Entry_no, updateAllRdeWithOrdersByRrNo.Orders[a], prevRdeOrder);
                    if(rdeOrderLog.Count > 0)
                    {
                        overrideUpdateOrderLogs.Orders!.Add(rdeOrderLog);
                    }
                    
                }
                var isChanges = AddLogs.IsNotChanges(overrideUpdateOrderLogs);
                if (!isChanges)
                {
                    AddLogs.ExeAddLogs(overrideUpdateOrderLogs, httpContext, "Receiving", rde.RR_no, "Override");
                }
                return logs;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
           
        }
        public UpdateAllRdeWithOrdersByRrNoContainer.UpdateAllRdeOrder TolistOrders(MySqlDataReader dr)
        {
            var obj = new UpdateAllRdeWithOrdersByRrNoContainer.UpdateAllRdeOrder();
            while (dr.Read())
            {

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
            }
            return obj;
        }
        public UpdateAllRdeWithOrdersByRrNoContainer.UpdateAllRde ToList(MySqlDataReader dr)
        {
            var obj = new UpdateAllRdeWithOrdersByRrNoContainer.UpdateAllRde();
            while (dr.Read())
            {
               
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
            }
            return obj;
        }
    }
}
