using MySql.Data.MySqlClient;
using System.Reflection;

namespace InfoMgmtSys.Models.DataEntry.AllAccess.ReceivedDataEntry
{
    public class GetAllRdeWithOrdersCurrentMonth:RdeWIthOrders.AllRde
    {
        public class OrderParams
        {
            public int RR_no { get; set; }
        }
        public List<RdeWIthOrders.AllOrders>? Orders { get; set; }
        public GetAllRdeWithOrdersCurrentMonth()
        {
            this.Orders = new List<RdeWIthOrders.AllOrders>();
        }
        public static List<GetAllRdeWithOrdersCurrentMonth> ExeGetAllRdeWithOrdersCurrentMonth()
        {
            var db = new AppDB();
            var obj = new object();
            var d = new GetAllRdeWithOrdersCurrentMonth();
            var list = new List<GetAllRdeWithOrdersCurrentMonth>();
            var objOrderParms = new GetAllRdeWithOrdersCurrentMonth.OrderParams();

            var rde = d.ToListRde(db.ExeDrStoredProc(db, obj, "Get_rde_by_current_month"));
            for (int num1 =0; num1 < rde.Count; num1++)
            {
                var SetRdeWithOrders = new GetAllRdeWithOrdersCurrentMonth();
                var length = SetRdeWithOrders.GetType().GetProperties().Length;
                for(int num3 = 0; num3 < length; num3++)
                {
                    string propName = SetRdeWithOrders.GetType().GetProperties()[num3].Name.ToString();
                    Type type = SetRdeWithOrders.GetType();
                    PropertyInfo? prop = type.GetProperty(propName);

                    Type rdeType = rde[num1].GetType();
                    PropertyInfo? rdeProp = rdeType.GetProperty(propName);

                    if(propName != "Orders")
                    {
                        Utils.Parser.ReportProps(SetRdeWithOrders,rdeProp!, propName, rde[num1]);
                    }
                }
                objOrderParms.RR_no = rde[num1].RR_no;
                db = new AppDB();

                var rdeOrders = d.TolistOrders(db.ExeDrStoredProc(db, objOrderParms, "Get_rde_order_by_rr_no"));
                for (int num2 =0; num2 < rdeOrders.Count; num2++)
                {
                   SetRdeWithOrders.Orders!.Add(rdeOrders[num2]);
                }
                list.Add(SetRdeWithOrders);
            }
            return list;
        }

        public List<RdeWIthOrders.AllOrders> TolistOrders(MySqlDataReader dr)
        {
            var e = new List<RdeWIthOrders.AllOrders>();
            while (dr.Read())
            {
                var obj = new RdeWIthOrders.AllOrders();
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
