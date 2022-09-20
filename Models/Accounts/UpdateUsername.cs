namespace InfoMgmtSys.Models.Accounts
{
    public class UpdateUsername
    {
        public int Id { get; set; }
        public string? Username { get; set; }

        public bool ExeUpdateUsername(AppDB db, UpdateUsername updateUsername)
        {
            return db.AddStoredProc(db, updateUsername, "Update_username");
        }
    }
}
