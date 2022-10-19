using MySql.Data.MySqlClient;
using System.Reflection;
using System.Text;
using System.Text.Json;
using InfoMgmtSys.Utils;

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

       public dynamic ExeUpdateAllRdeWithOrdersByRrNo(UpdateAllRdeWithOrdersByRrNo updateAllRdeWithOrdersByRrNo)
        {
            try
            {
                var db = new AppDB();
                var logs =new UpdateAllRdeWithOrdersByRrNoContainer.UpdateAllRdeWithOrdersLogs();
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
                Parser.containObject(rde, newRde, prevRde);
                logs.RR_no = getRdeByRrNoParams.RR_no;
                logs.RR!.Add(Parser.showChanged(rde, prevRde));
                
                db = new AppDB();
                db.AddStoredProc(db, newRde, "Update_all_rde_by_RR_no");

                for (int a = 0; a < updateAllRdeWithOrdersByRrNo.Orders!.Count; a++)
                {
                    db = new AppDB();
                    var rdeOrder = new UpdateAllRdeWithOrdersByRrNoContainer.UpdateAllRdeOrder();
                    var getRdeOrderByEntryNoParams = new UpdateAllRdeWithOrdersByRrNoContainer.GetRdeOrdeByEntryNoParams();
                    getRdeOrderByEntryNoParams.Entry_no = updateAllRdeWithOrdersByRrNo.Orders[a].Entry_no;
                    getRdeOrderByEntryNoParams.RR_no = getRdeByRrNoParams.RR_no;
                    var prevRdeOrder = TolistOrders(db.ExeDrStoredProc(db, getRdeOrderByEntryNoParams, "Get_rde_order_by_entry_no_and_rr_no"));
                    Parser.containObject(updateAllRdeWithOrdersByRrNo.Orders[a], rdeOrder, prevRdeOrder);
                    db.conClose();
                    var orderParamLogs = new UpdateAllRdeWithOrdersByRrNoContainer.UpdateAllRdeWithOrdersLogs.UpdateAllRdeWithOrderLogs();
                    orderParamLogs.Order!.Add(Parser.showChanged(rdeOrder, prevRdeOrder));
                    orderParamLogs.Entry_no = updateAllRdeWithOrdersByRrNo.Orders[a].Entry_no;
                    logs.Orders!.Add(orderParamLogs);
                    db = new AppDB();
                    db.AddStoredProc(db, rdeOrder, "Update_all_rde_order_by_entry_no");
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
        //public List<string> showChanged(object obj, object prevObj)
        //{
        //    var logs = new List<string>();
        //    for (int i = 0; i < obj.GetType().GetProperties().Length; i++)
        //    {
        //        string propName = obj.GetType().GetProperties()[i].Name.ToString();
        //        var property = obj.GetType().GetProperty(propName);
        //        var prevProperty = prevObj.GetType().GetProperty(propName);
        //        dynamic? value = property!.GetValue(obj, null) == null ? "null" : property!.GetValue(obj, null);
        //        dynamic? prevValue = prevProperty!.GetValue(prevObj, null);
        //        var type = value!.GetType().Name;
        //        if(type == "String")
        //        {
        //            if(value != "null" && value != prevValue)
        //            {
        //                logs.Add(propName +": " + prevValue!.ToString() + " => " + value!.ToString());
        //            }
                   
        //        }
        //        else
        //        {
        //            if (value != prevValue)
        //            {
        //                logs.Add(type.ToString() + ": " + prevValue!.ToString() + " => " + value!.ToString());
        //            }
        //        }
               
        //    }
        //    if (logs.Count > 0)
        //    {
        //        return logs;
        //    }
        //    else
        //    {
        //        logs.Add("No Changes");
        //        return logs;
        //    }
        //}
        //public static void containObject(object obj, object newObj, object prevObj)
        //{
        //    for(int a =0; a < obj.GetType().GetProperties().Length; a++)
        //    {
        //        string propName = obj.GetType().GetProperties()[a].Name;
        //        var property = obj.GetType().GetProperty(propName);
        //        var newProperty = newObj.GetType().GetProperty(propName);
        //        var prevProperty = prevObj.GetType().GetProperty(propName);
        //        var type = property!.PropertyType.Name;
        //        var value = property!.GetValue(obj, null);
        //        var prevValue = prevProperty!.GetValue(prevObj, null);

        //        if (value == null)
        //        {
        //            newProperty!.SetValue(newObj, prevValue, null);
        //        }
        //        else
        //        {
        //            newProperty!.SetValue(newObj, value, null);
        //        }
        //    }
        //}
    }
}
