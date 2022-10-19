using Microsoft.AspNetCore.Mvc;
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
        public string ExeUpdateRdeWithOrders(UpdateRdeWithOrdersByRrNo updateRdeWithOrdersByRrNo)
        {
            try
            {
                var db = new AppDB();
                var rdeWithOrders = new UpdateRdeWithOrdersContainer();
                var rde = rdeWithOrders.GetRde(updateRdeWithOrdersByRrNo);
                db.AddStoredProc(db, rde, "Update_rde_ap_incharge");
                for (int a = 0; a < updateRdeWithOrdersByRrNo.Orders!.Count; a++)
                {
                    db = new AppDB();
                    db.AddStoredProc(db, updateRdeWithOrdersByRrNo.Orders[a], "Update_rde_orders_ap_incharge");
                }

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
