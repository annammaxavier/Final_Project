using EmployeeM.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeM.Services.Employeeservices
{
    public interface IEmployeeRepository
    {
        Task<bool> AddUpdateEmployeeAsync(Employeeinfo employeeInfo);

        Task<bool> DeleteEmployeeAsync(int employeeId);

        Task<EmployeeInfo> GetEmployeeAsync(int employeeId);
        
    }
}
