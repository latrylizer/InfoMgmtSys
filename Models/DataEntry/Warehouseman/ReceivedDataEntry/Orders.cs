using Microsoft.AspNetCore.Mvc;
namespace InfoMgmtSys.Models.DataEntry.Warehouseman.ReceivedDataEntry
{
    public class Orders
    {
        public string? Item_description { get; set; }
        
        public string? UOM { get; set; }
        
        public int Qty { get; set; }
        public List<AddRdeOrders> GetOrders(AddRdeWithOrders addRdeWithOrders, int RR_no)
        {
            var e = new List<AddRdeOrders>();
            for (int num1 = 0; num1 < addRdeWithOrders.Orders!.Count; num1++)
            {
                var orders = new AddRdeOrders
                {
                    RR_no = RR_no,
                    Item_description = addRdeWithOrders.Orders![num1].Item_description,
                    UOM = addRdeWithOrders.Orders![num1].UOM,
                    Qty = addRdeWithOrders.Orders![num1].Qty
                };
                e.Add(orders);
            }
            return e;
        }
    }
}
