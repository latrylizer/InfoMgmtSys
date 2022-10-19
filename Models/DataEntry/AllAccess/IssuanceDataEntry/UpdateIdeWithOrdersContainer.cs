namespace InfoMgmtSys.Models.DataEntry.AllAccess.IssuanceDataEntry
{
    public class UpdateIdeWithOrdersContainer
    {
        public class UpdateAllIde
        {
            public int MIS_no { get; set; }
            public string? Issued_to { get; set; }
            public int Cycle_no { get; set; }
            public int Hectarage { get; set; }
            public int RR_no { get; set; }
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
        public class UpdateAllIdeOrder
        {
            public int Entry_no { get; set; }
            public string? Item_description { get; set; }
            public string? UOM { get; set; }
            public int Qty { get; set; }
            public double Price { get; set; }
        }
        public class GetIdeOrderByEntryNoAndMisNoParams
        {
            public int MIS_no { get; set; }
            public int Entry_no { get; set; }
        }
    
        
        public class UpdateAllIdeOrders
        {
            public List<UpdateAllIdeOrder>? Orders { get; set; }
            public UpdateAllIdeOrders()
            {
                Orders = new List<UpdateAllIdeOrder>();
            }
        }
        public class UpdateAllWithWithOrdersLogs
        {
            public int MIS_no { get; set; }
            public List<List<string>>? MIS { get; set; }
            public List<UpdateAllWithWithOrderLogs>? Orders { get; set; }

            public UpdateAllWithWithOrdersLogs()
            {
                MIS = new List<List<string>>();
                Orders = new List<UpdateAllWithWithOrderLogs>();
            }

            public class UpdateAllWithWithOrderLogs
            {
                public int Entry_no { get; set; }
                public List<List<string>>? Order { get; set; }

                public UpdateAllWithWithOrderLogs()
                {
                    Order = new List<List<string>>();
                }
            }

        }
        public UpdateAllIde GetIde(UpdateAllIdeWithOrdersByMisNo updateIdeWithOrdersByMisNo)
        {
            var ide = new UpdateAllIde
            {
                MIS_no = updateIdeWithOrdersByMisNo.MIS_no,
                Issued_to = updateIdeWithOrdersByMisNo.Issued_to,
                Cycle_no = updateIdeWithOrdersByMisNo.Cycle_no,
                Hectarage = updateIdeWithOrdersByMisNo.Hectarage,
                RR_no = updateIdeWithOrdersByMisNo.RR_no,
                Terms = updateIdeWithOrdersByMisNo.Terms,
                Start_date_of_collection = updateIdeWithOrdersByMisNo.Start_date_of_collection,
                Due_date = updateIdeWithOrdersByMisNo.Due_date,
                Mark_up = updateIdeWithOrdersByMisNo.Mark_up,
                Collection_terms = updateIdeWithOrdersByMisNo.Collection_terms,
                Collection_terms_in_words = updateIdeWithOrdersByMisNo.Collection_terms_in_words,
                Service_provider = updateIdeWithOrdersByMisNo.Service_provider,
                Total_amount_payable_to_trucker = updateIdeWithOrdersByMisNo.Total_amount_payable_to_trucker,
                Is_complete = updateIdeWithOrdersByMisNo.Is_complete,
            };
            return ide;
        }
    }
}
