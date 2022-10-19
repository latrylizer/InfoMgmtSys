using MySql.Data.MySqlClient;
using System.Reflection;
using InfoMgmtSys.Utils;

namespace InfoMgmtSys.Models.DataEntry.AllAccess.IssuanceDataEntry
{
    public class UpdateAllIdeWithOrdersByMisNo
    {
        public int MIS_no { get; set; }
        public string? Issued_to { get; set; }
        public int Cycle_no { get; set; }
        public int Hectarage { get; set; }
        public int RR_no { get; set; }
        public int Terms { get; set; }
        public string? Start_date_of_collection { get; set; }
        public string? Due_date { get; set; }
        public double Mark_up { get; set; }
        public int Collection_terms { get; set; }
        public string? Collection_terms_in_words{ get; set; }
        public string? Service_provider { get; set; }
        public double Total_amount_payable_to_trucker { get; set; }
        public int Is_complete { get; set; }
        public List<UpdateIdeWithOrdersContainer.UpdateAllIdeOrder>? Orders { get; set; }
        public UpdateAllIdeWithOrdersByMisNo()
        {
            Orders = new List<UpdateIdeWithOrdersContainer.UpdateAllIdeOrder>();
        }
        public dynamic ExeUpdateIdeWithOrders(UpdateAllIdeWithOrdersByMisNo updateIdeWithOrders)
        {
            try
            {
                var ideWithOrders = new UpdateIdeWithOrdersContainer();
                var logs = new UpdateIdeWithOrdersContainer.UpdateAllWithWithOrdersLogs();
                var ide = ideWithOrders.GetIde(updateIdeWithOrders);
                var newIde = new UpdateIdeWithOrdersContainer.UpdateAllIde();
                var getIdeParams = new GetIdeByMisNo.GetIdeByMisNoParams();
                getIdeParams.MIS_no = updateIdeWithOrders.MIS_no;
                var db = new AppDB();
                var prevIde = ToList(db.ExeDrStoredProc(db, getIdeParams, "Get_ide_by_mis_no_manager"));
                db.conClose();
                Parser.containObject(ide, newIde, prevIde);

                logs.MIS_no = getIdeParams.MIS_no;
                logs.MIS!.Add(Parser.showChanged(ide, prevIde));

                db = new AppDB();
                db.AddStoredProc(db, newIde, "Update_all_ide_by_MIS_no");

                for (int a = 0; a < updateIdeWithOrders.Orders!.Count; a++)
                {
                    db = new AppDB();
                    var ideOrder = new UpdateIdeWithOrdersContainer.UpdateAllIdeOrder();
                    var getIdeOrderParams = new UpdateIdeWithOrdersContainer.GetIdeOrderByEntryNoAndMisNoParams();
                    getIdeOrderParams.Entry_no = updateIdeWithOrders.Orders[a].Entry_no;
                    getIdeOrderParams.MIS_no = updateIdeWithOrders.MIS_no;
                    var prevIdeOrder = ToListOrder(db.ExeDrStoredProc(db, getIdeOrderParams, "Get_ide_order_by_entry_no_and_mis_no"));
                    db.conClose();
                    Parser.containObject(updateIdeWithOrders.Orders[a], ideOrder, prevIdeOrder);
                    var orderParams = new UpdateIdeWithOrdersContainer.UpdateAllWithWithOrdersLogs.UpdateAllWithWithOrderLogs();
                    orderParams.Entry_no = ideOrder.Entry_no;
                    orderParams.Order!.Add(Parser.showChanged(ideOrder, prevIdeOrder));
                    logs.Orders!.Add(orderParams);
                    db = new AppDB();
                    db.AddStoredProc(db, ideOrder, "Update_all_ide_order_by_entry_no");
                }
                return logs;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
            
        }
        public dynamic ToList(MySqlDataReader dr)
        {
            var obj = new UpdateIdeWithOrdersContainer.UpdateAllIde();
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
        public dynamic ToListOrder(MySqlDataReader dr)
        {
            var obj = new UpdateIdeWithOrdersContainer.UpdateAllIdeOrder();
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
