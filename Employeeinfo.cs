namespace EmployeeM.Data
{
    public class Employeeinfo
    {
        internal int employeeId;

        public int EmployeeID { get; set; }
        public required string EmployeeFirstName { get; set; }
        public string? EmployeeLastName { get => EmployeeLastName; set => EmployeeLastName = value; }
        public required string EmployeePosition { get; set; }
        public decimal EmployeeSalary { get; set; }
        public DateTime EmployeeDateOfJoining
        {
            get; set;

        }
    }
}
