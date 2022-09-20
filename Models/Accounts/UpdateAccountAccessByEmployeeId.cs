namespace InfoMgmtSys.Models.Accounts
{
    public class UpdateAccountAccessByEmployeeId
    {
        public int Employee_id { get; set; }
        public int Can_update { get; set; }
        public int Can_delete { get; set; }
        public int Can_Add { get; set; }
        public int Can_view { get; set; }

        public bool ExeUpdateAccountAccessByEmployeeId(AppDB db, UpdateAccountAccessByEmployeeId updateAccountAccessByEmployeeId)
        {
            return db.AddStoredProc(db, updateAccountAccessByEmployeeId, "Update_account_access_by_employee_id");

        }
    }
}
