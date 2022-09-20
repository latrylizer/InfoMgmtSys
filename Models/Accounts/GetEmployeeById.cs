using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace InfoMgmtSys.Models.Accounts
{
    public class GetEmployeeById
    {
        public int Id { get; set; }
        public string? Position_id { get; set; }
        public string? First_name { get; set; }
        public string? Middle_name { get; set; }
        public string? Last_name { get; set; }

        public static List<GetEmployeeById> ExeGetEmployeeById(AppDB db, Object obj)
        {
            return ToList(db.ExeDrStoredProc(db, obj, "Get_employee_by_id"));
        }
        public static List<GetEmployeeById> ToList(MySqlDataReader dr)
        {
            var e = new List<GetEmployeeById>();
            while (dr.Read())
            {
                var obj = new GetEmployeeById();
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
        public class GetEmployeeByIdParams
        { 
            [FromHeader]
            public int Id { get; set; }
        }
       
    }
}
