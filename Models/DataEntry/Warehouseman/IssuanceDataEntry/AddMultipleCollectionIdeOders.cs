using InfoMgmtSys.Models.Logs;
namespace InfoMgmtSys.Models.DataEntry.Warehouseman.IssuanceDataEntry
{
    public class AddMultipleCollectionIdeOders
    {
        public int IDE_order_no { get; set; }
        public string? Particulars { get; set; }
        public double Amount { get; set; }

        public string ExeAddMultipleCollectionIdeOrders(List<AddMultipleCollectionIdeOders> addMultipleCollectionIdeOrders, HttpContext httpContext)
        {
            try
            {
                var db = new AppDB();
                for (int num1 = 0; num1 < addMultipleCollectionIdeOrders.Count; num1++)
                {
                    try
                    {
                        db = new AppDB();
                        db.AddStoredProc(db, addMultipleCollectionIdeOrders[num1], "Add_collection_ide_orders");
                        AddLogs.ExeAddLogs(addMultipleCollectionIdeOrders, httpContext, "Issuing", addMultipleCollectionIdeOrders[num1].IDE_order_no, "Add");
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
           
        }
    }

}
