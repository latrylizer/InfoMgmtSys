using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace InfoMgmtSys.Models.DataEntry.AllAccess.IssuanceDataEntry
{
    public class GetCollectionOfIdeOrdersSummary: CollectionOfIdeOrdersSummaryContainer
    {

        public static dynamic ExeGetCollectionOfIdeOrdersSummary(AppDB db, object obj)
        {
            try
            {
                return ToList(db.ExeDrStoredProc(db, obj, "Get_collection_of_ide_orders_summary"));

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static List<GetCollectionOfIdeOrdersSummary> ToList(MySqlDataReader dr)
        {
            var e = new List<GetCollectionOfIdeOrdersSummary>();
            while (dr.Read())
            {
                var obj = new GetCollectionOfIdeOrdersSummary();
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

        public class GetCollectionOfIdeOrdersSummaryParams
        {
            public int MIS_no { get; set; }
        }

    }
}
