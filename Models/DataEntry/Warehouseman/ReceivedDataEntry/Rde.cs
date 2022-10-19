namespace InfoMgmtSys.Models.DataEntry.Warehouseman.ReceivedDataEntry
{
    public class Rde
    {
        public string? Supplier { get; set; }
        public int Terms { get; set; }
        public string? Grower { get; set; }
        public string? Date_time { get; set; }
        public string? PO_reference { get; set; }
        public int DR_no { get; set; }
        public string? Trucker { get; set; }
        public string? Trucker_plate_no { get; set; }
        public string? Warehouse { get; set; }
        public Rde GetRde(AddRdeWithOrders addRdeWithOrders)
        {
            var rde = new Rde
            {
                Supplier = addRdeWithOrders.Supplier,
                Terms = addRdeWithOrders.Terms,
                Grower = addRdeWithOrders.Grower,
                PO_reference = addRdeWithOrders.PO_reference,
                DR_no = addRdeWithOrders.DR_no,
                Trucker = addRdeWithOrders.Trucker,
                Trucker_plate_no = addRdeWithOrders.Trucker_plate_no,
                Warehouse = addRdeWithOrders.Warehouse,
            };
            return rde;
        }

    }
}
