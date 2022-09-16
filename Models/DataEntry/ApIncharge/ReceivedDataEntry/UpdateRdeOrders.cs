namespace InfoMgmtSys.Models.DataEntry.ApIncharge.ReceivedDataEntry
{
    public class UpdateRdeOrders
    {
        public int Entry_no { get; set; }
        public double Price {get; set; }
        
        public bool ExeUpdateRdeOrders(AppDB db, UpdateRdeOrders updateRdeOrders) 
        {
            return db.AddStoredProc(db, updateRdeOrders, "Update_rde_orders_ap_incharge");

        }
    }
}
