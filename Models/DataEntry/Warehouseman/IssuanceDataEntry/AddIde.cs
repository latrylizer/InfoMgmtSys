namespace InfoMgmtSys.Models.DataEntry.Warehouseman.IssuanceDataEntry
{
    public class AddIde
    {
        public string? Issued_to { get; set; }
        public int Cycle_no { get; set; }
        public int RR_no { get; set; }
        public string? Date_time { get; set; }
        public int Terms { get; set; }
        public int Collection_terms { get; set; }
        public string? Service_provider { get; set; }
        public double Total_amount_payable_to_trucker { get; set; }

        public bool ExeAddIde(AppDB db, AddIde addIde)
        {
            return db.AddStoredProc(db, addIde, "Add_ide");
        }

    }
}
