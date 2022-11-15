using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace InfoMgmtSys.Models.DataEntry.AllAccess.ReceivedDataEntry
{
    public class GetRdeSummaryReport : RdeSummaryReportContainer
    {
       

        public static dynamic ExeGetRdeSummaryReport(object obj)
        {
            try
            {
                var db = new AppDB();
                var toList = ToList(db.ExeDrStoredProc(db, obj, "Get_rde_summary_report"));
                db.conClose();
                return toList;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
           
        }
        public class GetRdeSummaryReportParams
        {
            public int RR_no { get; set; }
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
