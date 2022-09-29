using System.Reflection;
using MySql.Data.MySqlClient;
namespace InfoMgmtSys.Utils
{
    public class Parser
    {
        public static void ReportProps(object obj, PropertyInfo prop, string data, object obj2)
        {
            if (prop!.PropertyType.Name == "Int32")
            {
                prop!.SetValue(obj, Convert.ToInt32(obj2.GetType().GetProperty(data)?.GetValue(obj2, null)), null);
            }
            else if (prop!.PropertyType.Name == "String")
            {
                prop!.SetValue(obj, obj2.GetType().GetProperty(data)?.GetValue(obj2, null)!.ToString(), null);
            }
            else if (prop!.PropertyType.Name == "Double")
            {
                prop!.SetValue(obj, Convert.ToDouble(obj2.GetType().GetProperty(data)?.GetValue(obj2, null)), null);
            }
        }
        public static void prop(object obj, PropertyInfo prop, string data, MySqlDataReader dr)
        {
            if(prop.PropertyType.Name == "Int32") 
            {
                if(dr.IsDBNull(dr.GetOrdinal(data)))
                {
                    prop.SetValue(obj, 0, null);
                }
                else
                {
                    prop.SetValue(obj, dr.GetInt32(data), null);
                }
                
            }
            else if(prop.PropertyType.Name == "String") 
            {
                if (dr.IsDBNull(dr.GetOrdinal(data)))
                {
                    prop.SetValue(obj, "0000-00-00", null);
                }
                else
                {
                    prop.SetValue(obj, dr.GetString(data), null);
                };
            }
            else if(prop.PropertyType.Name == "Double")
            {
                if (dr.IsDBNull(dr.GetOrdinal(data)))
                {
                    prop.SetValue(obj, 0.00, null);
                }
                else
                {
                    prop.SetValue(obj, dr.GetDouble(data), null);
                }
            }
        }
    }
}
