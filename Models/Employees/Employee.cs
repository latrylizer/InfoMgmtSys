namespace InfoMgmtSys.Models.Employees
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? MiddleName { get; set; }
        public int EmployeeId { get; set; }
        public int AccountAccessId { get; set; }
        
       

        public bool AddEmployee(AppDB db)
        {
            using var query = db.StoredProc("Add_employee");
            db.Param(query, "P_first_name", FirstName ?? "");
            db.Param(query, "P_middle_name", MiddleName ?? "");
            db.Param(query, "P_last_name", LastName ?? "");
            db.Param(query, "P_employee_id", EmployeeId.ToString());
            db.Param(query, "P_account_access_id", AccountAccessId.ToString());

            var hasRows = query.ExecuteNonQuery();

            return hasRows ==1;
        }
    }
}
