namespace InfoMgmtSys.Models.DataEntry.Warehouseman.IssuanceDataEntry
{
    public class Ide
    {
        public string? Issued_to { get; set; }
        public int Cycle_no { get; set; }
        public string? Date_time { get; set; }
        public string? Service_provider { get; set; }
        public int Hectarage { get; set; }
        public Ide GetIde(AddIdeWithOrders addIdeWithOrders)
        {
            var ide = new Ide
            {
                Issued_to = addIdeWithOrders.Issued_to,
                Cycle_no = addIdeWithOrders.Cycle_no,
                Service_provider = addIdeWithOrders.Service_provider,
                Hectarage = addIdeWithOrders.Hectarage,
            };
            return ide;
        }
    }
}
