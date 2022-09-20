namespace InfoMgmtSys.Models.Accounts
{
    public class AddAccountAccess
    {
        public int Employee_id { get; set; }
        public int Can_update { get; set; }
        public int Can_delete { get; set; }
        public int Can_Add { get; set; }
        public int Can_view { get; set; }

        public bool ExeAddAccountAccess(AppDB db, AddAccountAccess addAccountAccess)
        {
            return db.AddStoredProc(db, addAccountAccess, "Add_account_access");
        }
    }
}
