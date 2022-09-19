namespace InfoMgmtSys.Models.DataEntry.AllAccess.IssuanceDataEntry
{
    public class UpdateAllIdeOrderByEntryNo
    {
        public int Entry_no { get; set; }
        public string? Item_Description { get; set; }
        public string? UOM { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }

        public bool ExeUpdateAllIdeOrderByEntryNo(AppDB db, UpdateAllIdeOrderByEntryNo updateAllIdeOrderByEntryNo)
        {
            return db.AddStoredProc(db, updateAllIdeOrderByEntryNo, "Update_all_ide_order_by_entry_no");
        }
    }
}
