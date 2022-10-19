namespace InfoMgmtSys.Models.DataEntry.AllAccess.ReceivedDataEntry
{
    public class UpdateAllRdeOrderEntryNo
    {
        public int Entry_no { get; set; }
        public string? Item_description { get; set; }
        public string? UOM { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }

        public bool ExeUpdateAllRdeOrderEntryNo(AppDB db, UpdateAllRdeOrderEntryNo updateAllRdeOrderEntryNo)
        {
            try
            {
                return db.AddStoredProc(db, updateAllRdeOrderEntryNo, "Update_all_rde_order_by_entry_no");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
