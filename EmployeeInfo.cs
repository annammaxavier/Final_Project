namespace EmployeeM.Services.Employeeservices
{
    public class EmployeeInfo
    {
        public int EmployeeId { get; internal set; }
        public required string EmployeeFirstName { get; set; }
        public string? EmployeeLastName
        {
            get => EmployeeLastName; set
            {
                EmployeeLastName = value;
            }
        }
        public required string EmployeePosition { get; set; }
        public decimal EmployeeSalary { get; set; }
        public DateTime EmployeeDateOfJoining
        {
            get; set;

        }
    }
}