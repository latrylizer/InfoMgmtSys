using MySql.Data.MySqlClient;
using System.Reflection;

namespace InfoMgmtSys.Models.DataEntry.AllAccess.ReceivedDataEntry
{
    public class GetRdeSummaryReportBySearch: RdeSummaryReportContainer
    {
       public class GetRdeSummaryReportBySearchParams
        {
            public string? Supplier { get; set; }
            public string? RR_no { get; set; }
            public string? From_date { get; set; }
            public string? To_date { get; set; }
        }
        public static dynamic ExeGetRdeSummaryReportBySearch(GetRdeSummaryReportBySearchParams getRdeSummaryReportBySearchParams)
        {
            try
            {
                var parameters = getRdeSummaryReportBySearchParams;
                var list = new List<RdeSummaryReportContainer>();
                var db = new AppDB();
                if(parameters.RR_no != null)
                {
                    var param = new GetRdeSummaryReportBySearchRrNo();
                    param.RR_no = parameters.RR_no;
                    list = ToList(db.ExeDrStoredProc(db, param, "Get_rde_summary_report"));
                    return list;
                }
                else if(parameters.Supplier != null)
                {
                    var param = new GetRdeSummaryReportBySearchSupplierAndDates();
                    param.Supplier = parameters.Supplier;
                    param.From_date = parameters.From_date;
                    param.To_date = parameters.To_date;
                    list = ToList(db.ExeDrStoredProc(db, param, "Get_rde_summary_report_by_supplier_and_date"));
                    return list;
                }
                else
                {
                    var param = new GetRdeSummaryReportBySearchDates();
                    param.From_date = parameters.From_date;
                    param.To_date = parameters.To_date;
                    list = ToList(db.ExeDrStoredProc(db, param, "Get_rde_summary_report_by_date"));
                    return list;
                }
               
                
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public class GetRdeSummaryReportBySearchSupplierAndDates {
            public string? Supplier { get; set; }
            public string? From_date { get; set; }
            public string? To_date { get; set; }
        }
        public class GetRdeSummaryReportBySearchDates {
            public string? From_date { get; set; }
            public string? To_date { get; set; }
        }
        public class GetRdeSummaryReportBySearchRrNo {
            public string? RR_no { get; set; }
        }

        public static List<RdeSummaryReportContainer> ToList(MySqlDataReader dr)
        {
            var e = new List<RdeSummaryReportContainer>();
            while (dr.Read())
            {
                var obj = new RdeSummaryReportContainer();
                var length = obj.GetType().GetProperties().Length;
                for (int num1 = 0; num1 < length; num1++)
                {
                    string data = obj.GetType().GetProperties()[num1].Name.ToString() ?? "";
                    Type type = obj.GetType();
                    PropertyInfo? prop = type.GetProperty(data);

                    if (prop != null)
                    {
                        Utils.Parser.prop(obj, prop, data, dr);
                    }

                }
                e.Add(obj);

            }
            return e;

        }
    }
}
