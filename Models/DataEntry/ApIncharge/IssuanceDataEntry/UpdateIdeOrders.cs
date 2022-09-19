namespace InfoMgmtSys.Models.DataEntry.ApIncharge.IssuanceDataEntry
{
    public class UpdateIdeOrders
    {
        public int Entry_no { get; set; }
        public double Price { get; set; }

        public bool ExeUpdateIdeOrders(AppDB db, UpdateIdeOrders updateIde)
        {
            return db.AddStoredProc(db, updateIde, "Update_ide_orders_ap_incharge");
        }

    }
}
