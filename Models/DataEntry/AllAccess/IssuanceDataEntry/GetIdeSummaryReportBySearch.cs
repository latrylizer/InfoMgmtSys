using MySql.Data.MySqlClient;
using System.Reflection;

namespace InfoMgmtSys.Models.DataEntry.AllAccess.IssuanceDataEntry
{
    public class GetIdeSummaryReportBySearch:IdeSummaryReportContainer
    {
        public class GetIdeSummaryReportParams
        {
            public string? MIS_no { get; set; }
            public string? Issued_to { get; set; }
            public string? From_date { get; set; }
            public string? To_date { get; set; }


        }
        public static dynamic ExeGetIdeSummaryReport(GetIdeSummaryReportParams getIdeSummaryReportParams)
        {
            try
            {
                var param = getIdeSummaryReportParams;

                if (param.MIS_no != null)
                {
                    var param1 = new GetIdeSummaryReportBySearchMisNo();
                    param1.MIS_no = param.MIS_no;
                    var db = new AppDB();
                    var result = ToList(db.ExeDrStoredProc(db, param1, "Get_ide_summary_report_by_mis_no"));
                    return result;
                    
                }
                else if (param.Issued_to !=null)
                {
                    var param1 = new GetIdeSummaryReportBySearchIssuedToAndDates();
                    param1.Issued_to = param.Issued_to;
                    param1.From_date = param.From_date;
                    param1.To_date = param.To_date;
                    var db = new AppDB();
                    var result = ToList(db.ExeDrStoredProc(db, param1, "Get_ide_summary_report_by_issued_to_and_date"));
                    return result;
                }
                else
                {
                    var param1 = new GetIdeSummaryReportBySearchDates();
                    param1.From_date = param.From_date;
                    param1.To_date = param.To_date;
                    var db = new AppDB();
                    var result = ToList(db.ExeDrStoredProc(db, param1, "Get_ide_summary_report_by_date"));
                    return result;
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public class GetIdeSummaryReportBySearchIssuedToAndDates
        {
            public string? Issued_to { get; set; }
            public string? From_date { get; set; }
            public string? To_date { get; set; }
        }
        public class GetIdeSummaryReportBySearchDates
        {
            public string? From_date { get; set; }
            public string? To_date { get; set; }
        }
        public class GetIdeSummaryReportBySearchMisNo
        {
            public string? MIS_no { get; set; }
        }
        public static List<IdeSummaryReportContainer> ToList(MySqlDataReader dr)
        {
            var e = new List<IdeSummaryReportContainer>();
            while (dr.Read())
            {
                var obj = new IdeSummaryReportContainer();
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
