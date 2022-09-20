namespace InfoMgmtSys.Models.Accounts
{
    public class UpdateEmployee
    {
        public int Id { get; set; }
        public string? First_name { get; set; }
        public string? Middle_name { get; set; }
        public string? Last_name { get; set; }

        public bool ExeUpdateEmployee(AppDB db, UpdateEmployee updateEmployee)
        {
            return db.AddStoredProc(db, updateEmployee, "Update_employee");
        }
    }
}
