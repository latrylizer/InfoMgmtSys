namespace InfoMgmtSys.Models.DataEntry.AllAccess.IssuanceDataEntry
{
    public class IdeWithOrders
    {
        public class Ide: IdeOrders
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
            public double Mark_up { get; set; }
            public int Collection_terms { get; set; }
            public string? Collection_terms_in_words { get; set; }
            public string? Service_provider { get; set; }
            public double Total_amount_payable_to_trucker { get; set; }
            public int Is_complete { get; set; }
        }
        public class IdeOrder
        {
            public int Entry_no { get; set; }
            public int MIS_no { get; set; }
            public string? Item_description { get; set; }
            public string? UOM { get; set; }
            public int Qty { get; set; }
            public double Price { get; set; }
        }
        public class IdeOrders
        {
            public List<IdeOrder>? Orders { get; set; }
            public class IdeOrdersParam
            {
                public int MIS_no { get; set; }
            }
            public IdeOrders()
            {
             this.Orders = new List<IdeOrder>();
            }
        }
       
    }

}
