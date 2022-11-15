namespace InfoMgmtSys.Models.DataEntry.AllAccess.IssuanceDataEntry
{
    public class GetCollectionOfIdeOrdersSummaryBySearch: CollectionOfIdeOrdersSummaryContainer
    {
        public class GetCollectionOfIdeOrdersSummaryBySearchParams
        {
            public string? MIS_no { get; set; }
            public string? Issued_to { get; set; }
            public string? From_date { get; set; }
            public string? To_date { get; set; }
        }
        public static dynamic ExeGetCollectionOfIdeOrdersSummaryBySearch(GetCollectionOfIdeOrdersSummaryBySearchParams getCollectionOfIdeOrdersSummaryBySearchParams)
        {
            try 
            {
                var param = getCollectionOfIdeOrdersSummaryBySearchParams;
                var container = new CollectionOfIdeOrdersSummaryContainer();
                var db = new AppDB();
                if (param.MIS_no != null)
                {
                    var param1 = new GetCollectionOfIdeOrdersSummaryMisNo();
                    param1.MIS_no = param.MIS_no;
                    var result = container.ToList(db.ExeDrStoredProc(db, param1, "Get_collection_of_ide_orders_summary"));
                    return result;
                }
                else if (param.Issued_to != null)
                {
                    var param1 = new GetCollectionOfIdeOrdersSummaryIssuedToAndDate();
                    param1.Issued_to = param.Issued_to;
                    param1.From_date = param.From_date;
                    param1.To_date = param.To_date;
                    var result = container.ToList(db.ExeDrStoredProc(db, param1, "Get_collection_of_ide_orders_summary_by_Issued_to_and_date"));
                    return result;
                }
                else
                {
                    var param1 = new GetCollectionOfIdeOrdersSummaryBySearchDate();
                    param1.From_date = param.From_date;
                    param1.To_date = param.To_date;
                    var result = container.ToList(db.ExeDrStoredProc(db, param1, "Get_collection_of_ide_orders_summary_by_date"));
                    return result;
                }
                
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public class GetCollectionOfIdeOrdersSummaryMisNo
        {
            public string? MIS_no { get; set; }
        }
        public class GetCollectionOfIdeOrdersSummaryIssuedToAndDate
        {
            public string? Issued_to { get; set; }
            public string? From_date { get; set; }
            public string? To_date { get; set; }
        }
        public class GetCollectionOfIdeOrdersSummaryBySearchDate
        {
            public string? From_date { get; set; }
            public string? To_date { get; set; }
        }
    }
}
