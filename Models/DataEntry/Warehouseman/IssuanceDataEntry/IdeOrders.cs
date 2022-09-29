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
            for (int num1 = 0; num1 < addIdeWithOrders.Order_list!.Count; num1++)
            {
                var orders = new AddIdeOrders
                {
                    MIS_no = MIS_no,
                    Item_Description = addIdeWithOrders.Order_list![num1].Item_Description,
                    UOM = addIdeWithOrders.Order_list![num1].UOM,
                    Qty = addIdeWithOrders.Order_list![num1].Qty,
                };
                e.Add(orders);
            }
            return e;
        }
        
    }
}
