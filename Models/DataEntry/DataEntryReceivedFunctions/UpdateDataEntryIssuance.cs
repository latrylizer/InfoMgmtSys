namespace InfoMgmtSys.Models.DataEntry.DataEntryReceivedFunctions
{
    public class UpdateDataEntryIssuance
    {
       public int Id { get; set; }
        public int Mis_no { get; set; }
        public double Price { get; set; }
        public int Terms { get; set; }
        public int Collection_term { get; set; }
        public string? Start_date_of_collection { get; set; }
        public string? Due_date { get; set; }
        public int Status { get; set; }
        public bool ExeUpdateDataEntryIssuance(AppDB db, UpdateDataEntryIssuance udei)
        {
            return db.AddStoredProc(db, udei, "Update_data_entry_issuance");
        }
    }

}
