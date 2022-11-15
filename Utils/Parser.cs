using System.Reflection;
using MySql.Data.MySqlClient;
using System.Text.Json;
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
                    prop.SetValue(obj, "", null);
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
            else if (prop.PropertyType.Name == "Object")
            {
                if (dr.IsDBNull(dr.GetOrdinal(data)))
                {
                    prop.SetValue(obj,new object(), null);
                }
                else
                {
                    prop.SetValue(obj,JsonSerializer.Deserialize<object>(dr.GetString(data)), null);
                }
            }
        }
        public static void containObject(object obj, object newObj, object prevObj)
        {
            for (int a = 0; a < obj.GetType().GetProperties().Length; a++)
            {
                string propName = obj.GetType().GetProperties()[a].Name;
                var property = obj.GetType().GetProperty(propName);
                var newProperty = newObj.GetType().GetProperty(propName);
                var prevProperty = prevObj.GetType().GetProperty(propName);
                var type = property!.PropertyType.Name;
                dynamic? value = property!.GetValue(obj, null);
                dynamic? prevValue = prevProperty!.GetValue(prevObj, null);
                
                if (value == null)
                {
                    newProperty!.SetValue(newObj, prevValue, null);
                }
                else
                {
                    if (type == "Int32")
                    {
                        if (value == 0)
                        {
                            newProperty!.SetValue(newObj, prevValue, null);
                        }
                        else
                        {
                            newProperty!.SetValue(newObj, value, null);
                        }
                    }
                    else
                    {
                        newProperty!.SetValue(newObj, value, null);
                    }
                   
                }
            }
        }
        public static List<string> showChanged(object obj, object prevObj)
        {
            var logs = new List<string>();
            for (int i = 0; i < obj.GetType().GetProperties().Length; i++)
            {
                string propName = obj.GetType().GetProperties()[i].Name.ToString();
                var property = obj.GetType().GetProperty(propName);
                var prevProperty = prevObj.GetType().GetProperty(propName);
                dynamic? value = property!.GetValue(obj, null) == null ? "null" : property!.GetValue(obj, null);
                dynamic? prevValue = prevProperty!.GetValue(prevObj, null);
                var type = value!.GetType().Name;
                if (type == "String")
                {
                    if (value != "null" && value != prevValue)
                    {
                        logs.Add(propName + ": " + prevValue!.ToString() + " => " + value!.ToString());
                    }

                }
                else
                {
                    if (value != prevValue && value != 0)
                    {
                        logs.Add(propName + ": " + prevValue!.ToString() + " => " + value!.ToString());
                    }
                }

            }
            if (logs.Count > 0)
            {
                return logs;
            }
            else
            {
                logs.Add("No Changes");
                return logs;
            }
        }
    }
}
