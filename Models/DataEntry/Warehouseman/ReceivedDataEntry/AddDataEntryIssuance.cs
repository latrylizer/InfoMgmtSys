namespace InfoMgmtSys.Models.DataEntry.Warehouseman
{
    public class AddDataEntryIssuance
    {
        public int Mis_no {get;set;}
        public string? Date_time { get; set; }
        public string? Issue_to { get; set; }
        public int Cycle_no { get; set; }
        public double Hectarage { get; set; }
        public string? Item_Description { get; set; }
        public int Qty {get; set; }
        public int Status { get; set; }

        public bool AddDataEntryIssuanceWarehouseman(AppDB db, AddDataEntryIssuance adei)
        {
            return db.AddStoredProc(db, adei, "Add_data_entry_issuance_warehouseman");
        }
    }


}
