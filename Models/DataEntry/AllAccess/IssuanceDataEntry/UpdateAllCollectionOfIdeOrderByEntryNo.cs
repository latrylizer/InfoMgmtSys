﻿namespace InfoMgmtSys.Models.DataEntry.AllAccess.IssuanceDataEntry
{
    public class UpdateAllCollectionOfIdeOrderByEntryNo
    {
        public int Entry_no { get; set; }
        public int IDE_order_no { get; set; }
        public string? Particulars { get; set; }
        public double Amount { get; set; }

        public bool ExeUpdateAllCollectionOfIdeOrderByEntryNo(AppDB db, UpdateAllCollectionOfIdeOrderByEntryNo updateAllCollectionOfIdeOrderByEntryNo)
        {
            return db.AddStoredProc(db, updateAllCollectionOfIdeOrderByEntryNo, "Update_all_collection_of_ide_order_by_entry_no");
        }
    }
}
