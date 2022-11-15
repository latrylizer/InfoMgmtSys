namespace InfoMgmtSys.Models.DataEntry.AllAccess.ReceivedDataEntry
{
    public class RdeSummaryReportContainer
    {
        public string? Supplier { get; set; }
        public int Charge_sale_invoice { get; set; }
        public int Terms { get; set; }
        public string? Grower { get; set; }
        public int RR_no { get; set; }
        public string? Date_time { get; set; }
        public string? Due_date { get; set; }
        public string? Funding_date { get; set; }
        public string? PO_reference { get; set; }
        public int DR_no { get; set; }
        public int APV_no { get; set; }
        public string? Item_description { get; set; }
        public string? UOM { get; set; }
        public double Qty { get; set; }
        public double Price { get; set; }
        public double ExVat { get; set; }
        public double Vat { get; set; }
        public double Subtotal { get; set; }
        public double EWT { get; set; }
        public double Admin_fee { get; set; }
    }
}
