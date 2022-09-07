namespace InfoMgmtSys.Models.DataEntry.DataEntryReceivedFunctions
{
    public class UpdateDataEntryRecieved
    {
       public int Id { get; set; }
        public int Charge_or_sales_invoice { get; set; }
        public int Terms { get; set; }
        public int JO_no { get; set; }

        public double Price { get; set; }

        public double Total_amount_payable_to_trucker { get; set; }
        public int Status { get; set; } 

        public bool ExeUpdateDataEntryRecieved (AppDB db, UpdateDataEntryRecieved uder)
        {
            return db.AddStoredProc(db, uder, "Update_data_entry_recieved");
        }
    }
    

}
