namespace InfoMgmtSys.Models.DataEntry.AllAccess.IssuanceDataEntry
{
    public class IdeWithOrdersAndCollection
    {
        public class Ide2 : IdeOrders2
        {
            public int MIS_no { get; set; }
            public string? Issued_to { get; set; }
            public int Cycle_no { get; set; }
            public int Hectarage { get; set; }
            public int RR_no { get; set; }
            public string? Date_time { get; set; }
            public int Terms { get; set; }
            public string? Start_date_of_collection { get; set; }
            public string? Due_date { get; set; }
            public string? Mark_up { get; set; }
            public double Admin_fee { get; set; }
            public string? Collection_terms { get; set; }
            public int Collection_terms_weekly { get; set; }
            public string? Service_provider { get; set; }
            public double Total_amount_payable_to_trucker { get; set; }
            public int Is_complete { get; set; }
        }
        public class IdeOrder2: CollectionOfOrders
        {
            public int Entry_no { get; set; }
            public int MIS_no { get; set; }
            public string? Item_description { get; set; }
            public string? UOM { get; set; }
            public int Qty { get; set; }
            public double Price { get; set; }
        }
        public class CollectionOfOrder
        {
            public int Entry_no { get; set; }
            public int IDE_order_no { get; set; }
            public string? Date_time { get; set; }
            public string? Particulars { get; set; }
            public double Amount { get; set; }
        }
        public class CollectionOfOrders
        {
            public List<CollectionOfOrder>? AllCollectionOfOrders  { get; set; }
            public class CollectionOfOrdersParams
            {
                public int IDE_order_no { get; set; }
            }
            public CollectionOfOrders()
            {
                this.AllCollectionOfOrders = new List<CollectionOfOrder>(); 
            }
        }

        public class IdeOrders2
        {
            public List<IdeOrder2>? AllIdeOrders { get; set; }
            public class IdeOrders2Param
            {
                public int MIS_no { get; set; }
            }
            public IdeOrders2()
            {
                this.AllIdeOrders = new List<IdeOrder2>();
            }
        }
    }
}
