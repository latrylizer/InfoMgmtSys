namespace InfoMgmtSys.Models.DataEntry.Warehouseman.IssuanceDataEntry
{
    public class AddMultipleCollectionIdeOders
    {
        public int IDE_order_no { get; set; }
        public string? Date_time { get; set; }
        public string? Particulars { get; set; }
        public double Amount { get; set; }

        public bool ExeAddMultipleCollectionIdeOrders(AppDB db, List<AddMultipleCollectionIdeOders> addMultipleCollectionIdeOrders)
        {
            for(int num1 =0; num1 < addMultipleCollectionIdeOrders.Count; num1++)
            {
                try
                {
                    db.AddStoredProc(db, addMultipleCollectionIdeOrders[num1], "Add_collection_ide_orders");
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
    }

}
