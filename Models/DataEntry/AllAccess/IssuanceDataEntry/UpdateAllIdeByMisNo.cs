namespace InfoMgmtSys.Models.DataEntry.AllAccess.IssuanceDataEntry
{
    public class UpdateAllIdeByMisNo
    {
        public int MIS_no { get; set; }
        public string? Issued_to { get; set; }
        public int Cycle_no { get; set; }
        public int Hectarage { get; set; }
        public string? Date_time { get; set; }
        public int Terms { get; set; }
        public string? Start_date_of_collection { get; set; }
        public string? Due_date { get; set; }
        public string? Mark_up { get; set; }
        public double Admin_fee { get; set; }
        public string? Collection_terms { get; set; }
        public int Collection_terms_weekly { get; set; }
        public string? Service_provider { get; set; }
        public double Total_amount_payable_to_trucker { get; set; }
        public int Is_complete { get; set; }
        
        public bool ExeUpdateAllIdeByMisNo(AppDB db, UpdateAllIdeByMisNo updateAllIdeByMisNo)
        {
            return db.AddStoredProc(db, updateAllIdeByMisNo, "Update_all_ide_by_MIS_no");
        }

    }
}
