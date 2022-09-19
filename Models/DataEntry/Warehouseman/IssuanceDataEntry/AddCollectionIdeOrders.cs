namespace InfoMgmtSys.Models.DataEntry.Warehouseman.IssuanceDataEntry
{
    public class AddCollectionIdeOrders
    {
        public int IDE_order_no { get; set; }
        public string? Date_time { get; set; }
        public string? Particulars { get; set; }
        public double Amount { get; set; }

        public bool ExeAddCollectionIdeOrders(AppDB db, AddCollectionIdeOrders addCollectionIdeOrders)
        {
            return db.AddStoredProc(db, addCollectionIdeOrders, "Add_collection_ide_orders");
        }
    }
}
