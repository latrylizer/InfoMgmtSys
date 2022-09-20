namespace InfoMgmtSys.Models.Accounts
{
    public class AddPosition
    {
        public string? Position_name { get; set; }

        public bool ExeAddPosition(AppDB db, AddPosition addPosition)
        {
            return db.AddStoredProc(db, addPosition, "Add_position");
        }
    }
}
