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
            public int Collection_terms { get; set; }
            public string? Collection_terms_in_words { get; set; }
            public string? Service_provider { get; set; }
            public double Total_amount_payable_to_trucker { get; set; }
            public int Is_complete { get; set; }
        }
        public class IdeOrder2: IdeCollectionOfOrders
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
        public class IdeCollectionOfOrders
        {
            public List<CollectionOfOrder>? Collection_of_orders  { get; set; }
            public class CollectionOfOrdersParams
            {
                public int IDE_order_no { get; set; }
            }
            public IdeCollectionOfOrders()
            {
                this.Collection_of_orders = new List<CollectionOfOrder>(); 
            }
        }

        public class IdeOrders2
        {
            public List<IdeOrder2>? Orders { get; set; }
            public class IdeOrders2Param
            {
                public int MIS_no { get; set; }
            }
            public IdeOrders2()
            {
                this.Orders = new List<IdeOrder2>();
            }
        }
    }
}
