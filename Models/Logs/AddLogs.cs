using System.Text.Json;
using System.Web;
using InfoMgmtSys.Security;
namespace InfoMgmtSys.Models.Logs
{
    public class AddLogs
    {
        public int Report_id { get; set; }
        public string? Report_type { get; set; }
        public string? Client { get; set; }
        public string? Role { get; set; }
        public string? Action { get; set; }
        public string? Data { get; set; }

        public class UpadateAllLogs
        {
            public string? Field_name { get; set; }
            public string? Old { get; set; }
            public string? New { get; set; }
        }
        public class UpdateOrderLogs
        {
            public int Entry_no { get; set; }
            public string? Field_name { get; set; }
            public string? Old { get; set; }
            public string? New { get; set; }
        }
        public class UpdateOverrideLog
        {
            public string? Field_name { get; set; }
            public string? Old { get; set; }
            public string? New { get; set; }
        }
        public class OverrideUpdateOrderLogs
        {
            public dynamic? DataEntry { get; set; }
            public dynamic? Orders { get; set; }
        }
        public static bool IsNotChanges(OverrideUpdateOrderLogs overrideUpdateOrderLogs)
        {
            if (overrideUpdateOrderLogs.Orders != null || overrideUpdateOrderLogs.DataEntry != null)
            {
                if (overrideUpdateOrderLogs.Orders == null)
                {
                    overrideUpdateOrderLogs.Orders = "No Order Changes";
                }
                if (overrideUpdateOrderLogs.DataEntry == null)
                {
                    overrideUpdateOrderLogs.DataEntry = "No Data Entry Changes";
                }
                return false;
            }
            return true;
        }


        public static dynamic CompareOrderObj(int entry_no, dynamic obj, dynamic prevObj)
        {
           // var updateOrderLogs = new UpdateOrderLogs();
            var updateAllLogsList = new List<UpdateOrderLogs>();
            for (int a = 0; a < obj.GetType().GetProperties().Length; a++)
            {
                string propName = obj.GetType().GetProperties()[a].Name.ToString();
                var property = obj.GetType().GetProperty(propName);
                var prevProperty = prevObj.GetType().GetProperty(propName);
                dynamic? value = property.GetValue(obj, null);
                dynamic? prevValue = prevProperty.GetValue(prevObj, null) == null ? "null" : prevProperty.GetValue(prevObj, null);

                if (value == null)
                {
                    continue;
                }
                if (value == prevValue)
                {
                    continue;
                }
                if (value != prevValue)
                {
                    string dynamicValue = "";
                    string dynamicPrevValue = "";
                    var type = value!.GetType().Name;
                    if (type == "String")
                    {
                        dynamicValue = value;
                        dynamicPrevValue = prevValue;
                    }

                    else if (type == "Int32")
                    {
                        if(value == 0)
                        {
                            continue;
                        }
                        dynamicValue = value.ToString();
                        dynamicPrevValue = prevValue.ToString();
                    }

                    else if (type == "Double")
                    {
                        if(value == 0)
                        {
                            continue;
                        }
                        dynamicValue = value.ToString();
                        dynamicPrevValue = prevValue.ToString();
                    }
                    var updateOrderLogs = new UpdateOrderLogs();

                    updateOrderLogs.Field_name = propName;
                    updateOrderLogs.Old = dynamicPrevValue;
                    updateOrderLogs.New = dynamicValue;
                    updateOrderLogs.Entry_no = entry_no;
                    updateAllLogsList.Add(updateOrderLogs);
                }
            }

            return updateAllLogsList;
        }
        public static List<UpadateAllLogs> CompareObj(dynamic obj,dynamic prevObj)
        {
            var updateAllLogsList = new List<UpadateAllLogs>();
            for (int a =0; a < obj.GetType().GetProperties().Length; a++)
            {
                string propName = obj.GetType().GetProperties()[a].Name.ToString();
                var property = obj.GetType().GetProperty(propName);
                var prevProperty = prevObj.GetType().GetProperty(propName);
                dynamic? value = property.GetValue(obj, null);
                dynamic? prevValue = prevProperty.GetValue(prevObj, null) == null ? "null" : prevProperty.GetValue(prevObj, null);

                if (value == null)
                {
                    continue;
                }
                if(value == prevValue)
                {
                    continue;
                }
                if(value != prevValue)
                {
                    string dynamicValue = "";
                    string dynamicPrevValue = "";
                    var type = value!.GetType().Name;
                    if (type == "String")
                    {
                        dynamicValue = value;
                        dynamicPrevValue = prevValue;
                    }
                        
                    else if (type == "Int32")
                    {
                        if(value == 0)
                        {
                            continue;
                        }
                        dynamicValue = value.ToString();
                        dynamicPrevValue = prevValue.ToString();
                    }
                        
                    else if (type == "Double")
                    {
                        if(value == 0)
                        {
                            continue;
                        }
                        dynamicValue = value.ToString();
                        dynamicPrevValue = prevValue.ToString();
                    }
                    var updateAllLogs = new UpadateAllLogs();

                    updateAllLogs.Field_name = propName;
                    updateAllLogs.Old = dynamicPrevValue;
                    updateAllLogs.New = dynamicValue;
                    updateAllLogsList.Add(updateAllLogs);
                }
            }
            
            return updateAllLogsList;
        }

        public static dynamic ExeAddLogs(dynamic data, HttpContext httpContext, string report_type, int report_id, string action)
        {
            var userInfo = httpContext.User.Claims.ToList();
            var addLogs = new AddLogs();
            addLogs.Client = userInfo[0].Value;
            addLogs.Role = userInfo[1].Value;
            addLogs.Data = JsonSerializer.Serialize(data);
            addLogs.Action = action;
            addLogs.Report_id = report_id;
            addLogs.Report_type = report_type;
            var db = new AppDB();
            db.AddStoredProc(db, addLogs, "Add_log");

            return "Succes";
        }
    }


}
