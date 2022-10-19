using MySql.Data.MySqlClient;
using System.Reflection;

namespace InfoMgmtSys.Models.DataEntry.AllAccess.IssuanceDataEntry
{
    public class GetAllIdeWithOrdersAndCollectionByCurrentMonth: IdeWithOrdersAndCollection.Ide2
    {
        
        public static dynamic ExeGetAllIdeWithOrdersByCurrentMonth()
        {
            try
            {
                var obj = new object();
                var IdeWithOrdersAndCollection = new GetAllIdeWithOrdersAndCollectionByCurrentMonth();
                var IdeOrdersParams = new IdeWithOrdersAndCollection.IdeOrders2.IdeOrders2Param();
                var IdeOrdersCollectionParams = new IdeWithOrdersAndCollection.IdeCollectionOfOrders.CollectionOfOrdersParams();
                var db = new AppDB();

                var list = new List<GetAllIdeWithOrdersAndCollectionByCurrentMonth>();
                db = new AppDB();
                var ide = IdeWithOrdersAndCollection.ToListIde(db.ExeDrStoredProc(db, obj, "Get_ide_by_current_month"));
                db.conClose();

                for (int a = 0; a < ide.Count; a++)
                {
                    var SetIdeWithOrdersAndCollection = new GetAllIdeWithOrdersAndCollectionByCurrentMonth();
                    var length = SetIdeWithOrdersAndCollection.GetType().GetProperties().Length;

                    for (int b = 0; b < length; b++)
                    {
                        string propname = IdeWithOrdersAndCollection.GetType().GetProperties()[b].Name.ToString();
                        Type type = SetIdeWithOrdersAndCollection.GetType();
                        PropertyInfo? prop = type.GetProperty(propname);

                        Type IdeType = ide[a].GetType();
                        PropertyInfo? IdeProp = IdeType.GetProperty(propname);

                        if (propname != "AllIdeOrders")
                        {
                            Utils.Parser.ReportProps(SetIdeWithOrdersAndCollection, IdeProp!, propname, ide[a]);
                        }


                    }
                    IdeOrdersParams.MIS_no = ide[a].MIS_no;
                    db = new AppDB();

                    var IdeOrders = IdeWithOrdersAndCollection.TolistIdeOrders(db.ExeDrStoredProc(db, IdeOrdersParams, "Get_ide_orders_by_mis_no"));
                    db.conClose();
                    for (int c = 0; c < IdeOrders.Count; c++)
                    {
                        db = new AppDB();
                        IdeOrdersCollectionParams.IDE_order_no = IdeOrders[c].Entry_no;
                        var IdeOrderCollections = IdeWithOrdersAndCollection.TolistIdeOrderCollections(db.ExeDrStoredProc(db, IdeOrdersCollectionParams, "Get_collection_of_ide_orders_by_ide_order_no"));
                        db.conClose();
                        for (int c2 = 0; c2 < IdeOrderCollections.Count; c2++)
                        {
                            IdeOrders[c].Collection_of_orders!.Add(IdeOrderCollections[c2]);
                        }
                    }
                    for (int d = 0; d < IdeOrders.Count; d++)
                    {
                        SetIdeWithOrdersAndCollection.Orders!.Add(IdeOrders[d]);
                    }
                    list.Add(SetIdeWithOrdersAndCollection);
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
            
        }
        public List<IdeWithOrdersAndCollection.Ide2> ToListIde(MySqlDataReader dr)
        {
            var e = new List<IdeWithOrdersAndCollection.Ide2>();
            while (dr.Read())
            {
                var obj = new IdeWithOrdersAndCollection.Ide2();
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
        public List<IdeWithOrdersAndCollection.IdeOrder2> TolistIdeOrders(MySqlDataReader dr)
        {
            var e = new List<IdeWithOrdersAndCollection.IdeOrder2>();
            while (dr.Read())
            {
                var obj = new IdeWithOrdersAndCollection.IdeOrder2();
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
        public List<IdeWithOrdersAndCollection.CollectionOfOrder> TolistIdeOrderCollections(MySqlDataReader dr)
        {
            var e = new List<IdeWithOrdersAndCollection.CollectionOfOrder>();
            while (dr.Read())
            {
                var obj = new IdeWithOrdersAndCollection.CollectionOfOrder();
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
