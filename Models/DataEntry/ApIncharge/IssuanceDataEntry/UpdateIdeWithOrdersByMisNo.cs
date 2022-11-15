using InfoMgmtSys.Models.Logs;
namespace InfoMgmtSys.Models.DataEntry.ApIncharge.IssuanceDataEntry
{
    public class UpdateIdeWithOrdersByMisNo
    {
        public int MIS_no { get; set; }
        public int RR_no { get; set; }
        public int Terms { get; set; }
        public string? Start_date_of_collection { get; set; }
        public double Total_amount_payable_to_trucker { get; set; }    
        public string? Due_date { get; set; }
        public double Mark_up { get; set; }
        public int Collection_terms { get; set; }
        public string? Collection_terms_in_words { get; set; }
        public List<UpdateIdeWithOrdersContainer.UpdateIdeOrder>? Orders { get; set; }

        public UpdateIdeWithOrdersByMisNo()
        {
            Orders = new List<UpdateIdeWithOrdersContainer.UpdateIdeOrder>();
        }
        public string ExeUpdateIdeWithOrders(UpdateIdeWithOrdersByMisNo updateIdeWithOrders, HttpContext httpContext)
        {
            try
            {
                if(updateIdeWithOrders.MIS_no == 0)
                {
                    return "MIS no should not be 0";
                }
                var db = new AppDB();
                var ideWithOrders = new UpdateIdeWithOrdersContainer();
                var ide = ideWithOrders.GetIde(updateIdeWithOrders);

                for(int a =0; a < updateIdeWithOrders.Orders!.Count; a++)
                {
                    if(updateIdeWithOrders.Orders[a].Entry_no == 0)
                    {
                        return "Entry no should not be 0";
                    }
                }
                
                db.AddStoredProc(db, ide, "Update_ide_ap_incharge");
                for(int a = 0; a < updateIdeWithOrders.Orders!.Count; a++)
                {
                    db = new AppDB();
                    db.AddStoredProc(db, updateIdeWithOrders.Orders[a], "Update_ide_orders_ap_incharge");
                }
                AddLogs.ExeAddLogs(updateIdeWithOrders, httpContext, "Issuing", ide.MIS_no, "Update");
                return "Success";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
            
        }
    }
}
