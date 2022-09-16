namespace InfoMgmtSys.Models.DataEntry.Warehouseman
{
    public class AddDataEntryReceived
    {
        public string? Supplier { get; set; }
        public string? Grower { get; set; }
        public int RR_no { get; set; }
        public string? Date_time { get; set; }
        public string? PO_reference { get; set; }
        public int DR_no { get; set; }
        public string? Trucker { get; set; }
        public int Trucker_plate_no { get; set; }
        public string? Warehouse { get; set; }
        public string? Item_description { get; set; }
        public string? UOM { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public double Total { get; set; }
        public double Total_amount_before_vat { get; set; }
        public int vat { get; set; }
        public double Total_amount_net_of_vat { get; set; }
        public string? Service_provider { get; set; }
        public double Total_amount_payable_to_trucker { get; set; }
        public int Status { get; set; }
        
        public bool AddDataEntryReceivedWarehouseman(AppDB db, AddDataEntryReceived ader)
        {
            return db.AddStoredProc(db, ader, "Add_data_entry_received_warehouseman");
        }
    }

}
