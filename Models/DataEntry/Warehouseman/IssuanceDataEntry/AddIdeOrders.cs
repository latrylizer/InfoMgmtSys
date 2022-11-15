namespace InfoMgmtSys.Models.DataEntry.Warehouseman.IssuanceDataEntry
{
    public class AddIdeOrders
    {
        public int MIS_no { get; set; }
        public string? Item_description { get; set; }
        public string? UOM { get; set; }
        public int Qty { get; set; }

        public bool ExeAddIdeOrders(AppDB db, AddIdeOrders addIdeOrders)
        {
            return db.AddStoredProc(db, addIdeOrders, "Add_ide_orders");
        }
    }
}
