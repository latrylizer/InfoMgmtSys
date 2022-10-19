namespace InfoMgmtSys.Models.DataEntry.Warehouseman.IssuanceDataEntry
{
    public class IdeOrders
    {
        public string? Item_Description { get; set; }
        public string? UOM { get; set; }
        public int Qty { get; set; }

        public List<AddIdeOrders> GetOrderList(AddIdeWithOrders addIdeWithOrders, int MIS_no)
        {
            var e = new List<AddIdeOrders>();
            for (int num1 = 0; num1 < addIdeWithOrders.Orders!.Count; num1++)
            {
                var orders = new AddIdeOrders
                {
                    MIS_no = MIS_no,
                    Item_Description = addIdeWithOrders.Orders![num1].Item_Description,
                    UOM = addIdeWithOrders.Orders![num1].UOM,
                    Qty = addIdeWithOrders.Orders![num1].Qty,
                };
                e.Add(orders);
            }
            return e;
        }
        
    }
}
