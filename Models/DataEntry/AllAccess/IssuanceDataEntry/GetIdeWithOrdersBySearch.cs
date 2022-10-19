using MySql.Data.MySqlClient;
using System.Reflection;
namespace InfoMgmtSys.Models.DataEntry.AllAccess.IssuanceDataEntry
{
    public class GetIdeWithOrdersBySearch:IdeWithOrders.Ide
    {
        public class SearchParam
        {
            public string? Search { get; set; }
        }
        public static dynamic ExeGetAllIdeWithOrdersBySearch(SearchParam obj)
        {
            try
            {
                var db = new AppDB();
                var IdeWithOrders = new GetIdeWithOrdersBySearch();
                var IdeOrdersParams = new IdeWithOrders.IdeOrders.IdeOrdersParam();
                var list = new List<GetIdeWithOrdersBySearch>();

                var ide = IdeWithOrders.ToListIde(db.ExeDrStoredProc(db, obj, "Get_ide_by_search"));
                db.conClose();
                for (int num1 = 0; num1 < ide.Count; num1++)
                {
                    var SetIdeWithOrders = new GetIdeWithOrdersBySearch();
                    var length = SetIdeWithOrders.GetType().GetProperties().Length;
                    for (int num2 = 0; num2 < length; num2++)
                    {
                        string propName = SetIdeWithOrders.GetType().GetProperties()[num2].Name.ToString();
                        Type type = SetIdeWithOrders.GetType();
                        PropertyInfo? prop = type.GetProperty(propName);

                        Type ideType = ide[num1].GetType();
                        PropertyInfo? ideProp = ideType.GetProperty(propName);

                        if (propName != "Orders")
                        {
                            Utils.Parser.ReportProps(SetIdeWithOrders, ideProp!, propName, ide[num1]);
                        }

                    }
                    IdeOrdersParams.MIS_no = ide[num1].MIS_no;
                    db = new AppDB();
                    var ideOrders = IdeWithOrders.TolistIdeOrders(db.ExeDrStoredProc(db, IdeOrdersParams, "Get_ide_orders_by_mis_no"));
                    db.conClose();
                    for (int num3 = 0; num3 < ideOrders.Count; num3++)
                    {
                        SetIdeWithOrders.Orders!.Add(ideOrders[num3]);
                    }
                    list.Add(SetIdeWithOrders);
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }
        public List<IdeWithOrders.Ide> ToListIde(MySqlDataReader dr)
        {
            var e = new List<IdeWithOrders.Ide>();
            while (dr.Read())
            {
                var obj = new IdeWithOrders.Ide();
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
        public List<IdeWithOrders.IdeOrder> TolistIdeOrders(MySqlDataReader dr)
        {
            var e = new List<IdeWithOrders.IdeOrder>();
            while (dr.Read())
            {
                var obj = new IdeWithOrders.IdeOrder();
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
