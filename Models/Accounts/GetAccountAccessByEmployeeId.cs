
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace InfoMgmtSys.Models.Accounts
{
    public class GetAccountAccessByEmployeeId
    {
        public int Entry_no { get; set; }
        public int Employee_id { get; set; }
        public int Can_update { get; set; }
        public int Can_delete { get; set; }
        public int Can_Add { get; set; }
        public int Can_view { get; set; }

        public static List<GetAccountAccessByEmployeeId> ExeGetAccountAccessByEmployeeId(AppDB db, object obj)
        {
            return ToList(db.ExeDrStoredProc(db, obj, "Get_account_access_by_employee_id"));
        }

        public static List<GetAccountAccessByEmployeeId> ToList(MySqlDataReader dr)
        {
            var e = new List<GetAccountAccessByEmployeeId>();
            while (dr.Read())
            {
                var obj = new GetAccountAccessByEmployeeId();
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
            };
            return e;
        }
        public class GetAccountAccessByEmployeeIdParams
        {
            [FromHeader]
            public int Employee_id { get; set; }
        }
    }
}
