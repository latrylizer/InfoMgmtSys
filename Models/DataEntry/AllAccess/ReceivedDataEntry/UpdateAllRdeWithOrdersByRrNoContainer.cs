namespace InfoMgmtSys.Models.DataEntry.AllAccess.ReceivedDataEntry
{
    public class UpdateAllRdeWithOrdersByRrNoContainer
    {
        public class UpdateAllRde
        {
            public int RR_no { get; set; }
            public string? Supplier { get; set; }
            public int Charge_sale_invoice { get; set; }
            public int Terms { get; set; }
            public string? Grower { get; set; }
            public int APV_no { get; set; }
            public string? PO_reference { get; set; }
            public int DR_no { get; set; }
            public int Job_order_no { get; set; }
            public string? Trucker { get; set; }
            public string? Trucker_plate_no { get; set; }
            public string? Warehouse { get; set; }
            public double Total_amount_payable_to_trucker { get; set; }
            public int Is_complete { get; set; }
        }
        public class UpdateAllRdeOrder
        {
            public int Entry_no { get; set; }
            public string? Item_description { get; set; }
            public string? UOM { get; set; }
            public int Qty { get; set; }
            public double Price { get; set; }
        }
        public class UpdateAllRdeOrders
        { 
            public List<UpdateAllRdeOrder>? Orders { get; set; }
            public UpdateAllRdeOrders()
            {
                Orders = new List<UpdateAllRdeOrder>();
            }
        }
        public class UpdateAllRdeWithOrdersLogs
        {
            public int RR_no { get; set; }
            public List<List<string>>? RR { get; set; }
            public List<UpdateAllRdeWithOrderLogs>? Orders { get; set; }
            public UpdateAllRdeWithOrdersLogs()
            {
                RR = new List<List<string>>();
                Orders = new List<UpdateAllRdeWithOrderLogs>();
            }

            public class UpdateAllRdeWithOrderLogs
            {
                public int Entry_no { get; set; }
                public List<List<string>>? Order { get; set; }

                public UpdateAllRdeWithOrderLogs()
                {
                    Order = new List<List<string>>();
                }
            }
        }
        public class GetRdeOrdeByEntryNoParams
        {
            public int Entry_no { get; set; }
            public int RR_no  { get; set; }

        }
        public UpdateAllRdeWithOrdersByRrNoContainer.UpdateAllRde GetRde(UpdateAllRdeWithOrdersByRrNo updateAllRdeWithOrdersByRrNo)
        {
            var rde = new UpdateAllRdeWithOrdersByRrNoContainer.UpdateAllRde
            {
                RR_no = updateAllRdeWithOrdersByRrNo.RR_no,
                Supplier = updateAllRdeWithOrdersByRrNo.Supplier,
                Charge_sale_invoice = updateAllRdeWithOrdersByRrNo.Charge_sale_invoice,
                Terms = updateAllRdeWithOrdersByRrNo.Terms,
                Grower = updateAllRdeWithOrdersByRrNo.Grower,
                APV_no = updateAllRdeWithOrdersByRrNo.APV_no,
                PO_reference = updateAllRdeWithOrdersByRrNo.PO_reference,
                DR_no = updateAllRdeWithOrdersByRrNo.DR_no,
                Job_order_no = updateAllRdeWithOrdersByRrNo.Job_order_no,
                Trucker = updateAllRdeWithOrdersByRrNo.Trucker,
                Trucker_plate_no = updateAllRdeWithOrdersByRrNo.Trucker_plate_no,
                Warehouse = updateAllRdeWithOrdersByRrNo.Warehouse,
                Total_amount_payable_to_trucker = updateAllRdeWithOrdersByRrNo.Total_amount_payable_to_trucker,
                Is_complete = updateAllRdeWithOrdersByRrNo.Is_complete,

            };
            return rde;
        }

    }
}
