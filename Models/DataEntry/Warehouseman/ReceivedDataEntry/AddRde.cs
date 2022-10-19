using MySql.Data.MySqlClient;
using System.Reflection;
namespace InfoMgmtSys.Models.DataEntry.Warehouseman.ReceivedDataEntry
{
    public class AddRde
    {
        public string? Supplier { get; set; }
        public int Terms { get; set; }
        public string? Grower { get; set; }
        public string? PO_reference { get; set; }
        public int DR_no { get; set; }
        public string? Trucker { get; set; }
        public string? Trucker_plate_no { get; set; }
        public string? Warehouse { get; set; }

        public bool ExeAddRde(AppDB db, AddRde addRde)
        {
            return db.AddStoredProc(db, addRde, "Add_rde");
        }
    }
}
