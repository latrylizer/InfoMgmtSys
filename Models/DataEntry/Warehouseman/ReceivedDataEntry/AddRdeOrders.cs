
namespace InfoMgmtSys.Models.DataEntry.Warehouseman.ReceivedDataEntry
{
    public class AddRdeOrders
    {
        public int RR_no { get; set; }
        public string? Item_description { get; set; }
        public string? UOM { get; set; }
        public int Qty { get; set; }

        public bool ExeAddRdeOrders(AppDB db, AddRdeOrders addRdeOrders)
        {
            return db.AddStoredProc(db, addRdeOrders, "Add_rde_orders");
        }

    }
}
