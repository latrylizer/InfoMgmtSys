namespace InfoMgmtSys.Models.DataEntry.ApIncharge.IssuanceDataEntry
{
    public class UpdateIdeWithOrdersContainer
    {
        public class UpdateIde
        {
            public int MIS_no { get; set; }
            public int RR_no { get; set; }
            public int Terms { get; set; }
            public string? Start_date_of_collection { get; set; }
            public double Total_amount_payable_to_trucker { get; set; }
            public string? Due_date { get; set; }
            public double Mark_up { get; set; }
            public int Collection_terms { get; set; }
            public string? Collection_terms_in_words { get; set; }
        }
        public class UpdateIdeOrder
        {
            public int Entry_no { get; set; }
            public double Price { get; set; }
        }
        public UpdateIdeWithOrdersContainer.UpdateIde GetIde(UpdateIdeWithOrdersByMisNo updateIdeWithOrders)
        {
            var ide = new UpdateIde
            {
                MIS_no = updateIdeWithOrders.MIS_no,
                RR_no = updateIdeWithOrders.RR_no,
                Terms = updateIdeWithOrders.Terms,
                Start_date_of_collection = updateIdeWithOrders.Start_date_of_collection,
                Due_date = updateIdeWithOrders.Due_date,
                Mark_up = updateIdeWithOrders.Mark_up,
                Total_amount_payable_to_trucker = updateIdeWithOrders.Total_amount_payable_to_trucker,
                Collection_terms = updateIdeWithOrders.Collection_terms,
                Collection_terms_in_words = updateIdeWithOrders.Collection_terms_in_words,
            };
            return ide;
        }
        
    }
}
