using Microsoft.AspNetCore.Mvc;
namespace InfoMgmtSys.Models.DataEntry.ApIncharge.ReceivedDataEntry
{
    public class UpdateRdeWithOrdersContainer
    {
        public class UpdateRde
        {
            public int RR_no { get; set; }
            public int Charge_sale_invoice { get; set; }
            public int Terms { get; set; }
            public int APV_no { get; set; }
            public int Job_order_no { get; set; }
            public double Total_amount_payable_to_trucker { get; set; }
            
        }
        public class UpdateRdeOrder
        {
            public int Entry_no { get; set; }
            public double Price { get; set; }
        }

        public UpdateRde GetRde(UpdateRdeWithOrdersByRrNo updateRdeWithOrdersByRrNo)
        {
            var rde = new UpdateRde
            {
                RR_no = updateRdeWithOrdersByRrNo.RR_no,
                Charge_sale_invoice = updateRdeWithOrdersByRrNo.Charge_sale_invoice,
                Terms = updateRdeWithOrdersByRrNo.Terms,
                APV_no = updateRdeWithOrdersByRrNo.APV_no,
                Job_order_no = updateRdeWithOrdersByRrNo.Job_order_no,
                Total_amount_payable_to_trucker = updateRdeWithOrdersByRrNo.Total_amount_payable_to_trucker
            };
            return rde;
        }
    }
}
