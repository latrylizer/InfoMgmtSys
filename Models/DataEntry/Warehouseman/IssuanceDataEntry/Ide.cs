namespace InfoMgmtSys.Models.DataEntry.Warehouseman.IssuanceDataEntry
{
    public class Ide
    {
        public string? Issued_to { get; set; }
        public int Cycle_no { get; set; }
        public string? Date_time { get; set; }
        public int Terms { get; set; }
        public int Collection_terms { get; set; }
        public string? Service_provider { get; set; }
        public double Total_amount_payable_to_trucker { get; set; }
        public Ide GetIde(AddIdeWithOrders addIdeWithOrders)
        {
            var ide = new Ide
            {
                Issued_to = addIdeWithOrders.Issued_to,
                Collection_terms = addIdeWithOrders.Collection_terms,
                Cycle_no = addIdeWithOrders.Cycle_no,
                Date_time = addIdeWithOrders.Date_time,
                Terms = addIdeWithOrders.Terms,
                Service_provider = addIdeWithOrders.Service_provider,
                Total_amount_payable_to_trucker = addIdeWithOrders.Total_amount_payable_to_trucker,
            };
            return ide;
        }
    }
}
