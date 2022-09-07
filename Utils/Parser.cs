using System.Reflection;
using MySql.Data.MySqlClient;
namespace InfoMgmtSys.Utils
{
    public class Parser
    {
        public static void prop(object obj, PropertyInfo prop, string data, MySqlDataReader dr)
        {
            if(prop.PropertyType.Name == "Int32") 
            {
                prop.SetValue(obj, dr.GetInt32(data), null);
            }
            else if(prop.PropertyType.Name == "String") 
            {
                prop.SetValue(obj, dr.GetString(data), null);
            }
            else if(prop.PropertyType.Name == "Double")
            {
                prop.SetValue(obj, dr.GetDouble(data), null);
            }
        }
    }
}
