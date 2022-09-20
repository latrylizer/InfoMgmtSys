namespace InfoMgmtSys.Models.Accounts
{
    public class UpdatePassword
    {
        public int Id { get; set; }
        public string? Password { get; set; }
       
        public bool ExeUpdatePassword(AppDB db, UpdatePassword updatePassword)
        {
            return db.AddStoredProc(db, updatePassword, "Update_password");
        }
    }
}
