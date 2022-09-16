namespace InfoMgmtSys.Models.DataEntry.AllAccess.ReceivedDataEntry
{
    public class UpdateAllRdeByRrNo
    {
        public int RR_no { get; set; }
        public string? Supplier { get; set; }
        public int Charge_sale_invoice { get; set; }
        public int Terms { get; set; }
        public string? Grower { get; set; }
        public int APV_no { get; set; }
        public string? Date_time { get; set; }
        public string? PO_reference { get; set; }
        public int DR_no { get; set; }
        public int Job_order_no { get; set; }
        public string? Trucker { get; set; }
        public string? Trucker_plate_no { get; set; }
        public string? Warehouse { get; set; }
        public string? Service_provider { get; set; }
        public double Total_amount_payable_to_trucker { get; set; }
        public int Is_complete { get; set; }

        public bool ExeUpdateAllRdeByRrNo (AppDB db, UpdateAllRdeByRrNo updateAllRdeByRrNo)
        {
            return db.AddStoredProc(db, updateAllRdeByRrNo, "Update_all_rde_by_RR_no");
        }
    }
}
