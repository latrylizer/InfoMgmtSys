namespace InfoMgmtSys.Models.DataEntry.ApIncharge.ReceivedDataEntry
{
    public class UpdateRde
    {
        public int RR_no { get; set; }
        public int Charge_sale_invoice { get; set; }
        public int Terms { get; set; }
        public int Job_order_no { get; set; }
        public double Total_amount_payable_to_trucker { get; set; }

        public bool ExeUpdateRde(AppDB db, UpdateRde updateRde)
        {
            return db.AddStoredProc(db, updateRde, "Update_rde_ap_incharge");
        }
    }
}
