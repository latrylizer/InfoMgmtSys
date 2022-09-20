namespace InfoMgmtSys.Models.Accounts
{
    public class AddEmployee
    {
        public int Position_id { get; set; }
        public string? First_name { get; set; }
        public string? Middle_name { get; set; }
        public string? Last_name { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }

        public bool ExeAddEmployee(AppDB db, AddEmployee addEmployee)
        {
            return db.AddStoredProc(db, addEmployee, "Add_employee");
        }
    }
}
