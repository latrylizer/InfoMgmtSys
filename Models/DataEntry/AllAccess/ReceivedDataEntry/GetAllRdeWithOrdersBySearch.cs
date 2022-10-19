using MySql.Data.MySqlClient;
using System.Reflection;

namespace InfoMgmtSys.Models.DataEntry.AllAccess.ReceivedDataEntry
{
    public class GetAllRdeWithOrdersBySearch:RdeWIthOrders.AllRde
    {
        public class OrderParams
        {
            public int RR_no { get; set; }
        }
        public List<RdeWIthOrders.AllRde.Order>? Orders { get; set; }
        public GetAllRdeWithOrdersBySearch()
        {
            this.Orders = new List<RdeWIthOrders.AllRde.Order>();
        }
        public class SearchParam
        {
            public string? Search { get; set; }
        }

        public static dynamic ExeGetAllRdeWithOrdersBySearch(SearchParam obj)
        {
            try
            {
                var db = new AppDB();
                var d = new GetAllRdeWithOrdersBySearch();
                var list = new List<GetAllRdeWithOrdersBySearch>();
                var objOrderParms = new GetAllRdeWithOrdersBySearch.OrderParams();

                var rde = d.ToListRde(db.ExeDrStoredProc(db, obj, "Get_rde_by_search"));
                db.conClose();
                for (int num1 = 0; num1 < rde.Count; num1++)
                {
                    var SetRdeWithOrders = new GetAllRdeWithOrdersBySearch();
                    var length = SetRdeWithOrders.GetType().GetProperties().Length;
                    for (int num3 = 0; num3 < length; num3++)
                    {
                        string propName = SetRdeWithOrders.GetType().GetProperties()[num3].Name.ToString();
                        Type type = SetRdeWithOrders.GetType();
                        PropertyInfo? prop = type.GetProperty(propName);

                        Type rdeType = rde[num1].GetType();
                        PropertyInfo? rdeProp = rdeType.GetProperty(propName);

                        if (propName != "Orders")
                        {
                            Utils.Parser.ReportProps(SetRdeWithOrders, rdeProp!, propName, rde[num1]);
                        }
                    }
                    objOrderParms.RR_no = rde[num1].RR_no;
                    db = new AppDB();

                    var rdeOrders = d.TolistOrders(db.ExeDrStoredProc(db, objOrderParms, "Get_rde_order_by_rr_no"));
                    db.conClose();
                    for (int num2 = 0; num2 < rdeOrders.Count; num2++)
                    {
                        SetRdeWithOrders.Orders!.Add(rdeOrders[num2]);
                    }
                    list.Add(SetRdeWithOrders);
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }
        public List<RdeWIthOrders.AllRde.Order> TolistOrders(MySqlDataReader dr)
        {
            var e = new List<RdeWIthOrders.AllRde.Order>();
            while (dr.Read())
            {
                var obj = new RdeWIthOrders.AllRde.Order();
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
        public List<RdeWIthOrders.AllRde> ToListRde(MySqlDataReader dr)
        {
            var e = new List<RdeWIthOrders.AllRde>();
            while (dr.Read())
            {
                var obj = new RdeWIthOrders.AllRde();
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
