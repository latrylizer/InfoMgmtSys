using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using InfoMgmtSys.Models.Logs;
using System.Web;
namespace InfoMgmtSys.Models.DataEntry.ApIncharge.ReceivedDataEntry
{
    public class UpdateRdeWithOrdersByRrNo
    {
        public int RR_no { get; set; }
        public int Charge_sale_invoice { get; set; }
        public int Terms { get; set; }
        public int APV_no { get; set; }
        public int Job_order_no { get; set; }
        public double Total_amount_payable_to_trucker { get; set; }
        public List<UpdateRdeWithOrdersContainer.UpdateRdeOrder>? Orders { get; set; }
        public UpdateRdeWithOrdersByRrNo()
        {
            
            Orders = new List<UpdateRdeWithOrdersContainer.UpdateRdeOrder>();
        }
        public string ExeUpdateRdeWithOrders(UpdateRdeWithOrdersByRrNo updateRdeWithOrdersByRrNo, HttpContext httpContext)
        {
            try
            {
      
               
                var db = new AppDB();
                var rdeWithOrders = new UpdateRdeWithOrdersContainer();
                var rde = rdeWithOrders.GetRde(updateRdeWithOrdersByRrNo);
                if(rde.RR_no == 0)
                {
                    return "RR no should not be 0";
                }
                for(int a=0;a < updateRdeWithOrdersByRrNo.Orders!.Count; a++)
                {
                    if(updateRdeWithOrdersByRrNo.Orders[a].Entry_no == 0)
                    {
                        return "Entry no should not be 0";
                    }
                }
                db.AddStoredProc(db, rde, "Update_rde_ap_incharge");
                for (int a = 0; a < updateRdeWithOrdersByRrNo.Orders!.Count; a++)
                {
                    
                    db = new AppDB();
                    db.AddStoredProc(db, updateRdeWithOrdersByRrNo.Orders[a], "Update_rde_orders_ap_incharge");
                }

                AddLogs.ExeAddLogs(updateRdeWithOrdersByRrNo, httpContext ,"Receiving", updateRdeWithOrdersByRrNo.RR_no, "Update");
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
