namespace InfoMgmtSys.Models.DataEntry.ApIncharge.IssuanceDataEntry
{
    public class UpdateIde
    {
        public int MIS_no { get; set; }
        public int RR_no { get; set; }
        public int Terms { get; set; }
        public string? Start_date_of_collection { get; set; }
        public string? Due_date { get; set; }

        public int Collection_terms { get; set; }

      
        public bool ExeUpdateIde(AppDB db, UpdateIde updateIde)
        {
            return db.AddStoredProc(db, updateIde, "Update_ide_ap_incharge");
        }
    }
}
