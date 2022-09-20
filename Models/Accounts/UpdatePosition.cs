namespace InfoMgmtSys.Models.Accounts
{
    public class UpdatePosition
    {
        public int Id { get; set; }
        public string? position_name { get; set; }

        public bool ExeUpdatePosition(AppDB db, UpdatePosition updatePosition)
        {
            return db.AddStoredProc(db, updatePosition, "Update_position");
        }
    }
}
