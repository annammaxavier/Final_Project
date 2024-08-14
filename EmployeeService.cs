using EmployeeM.Data;
using SQLite;
using System.Collections;

namespace EmployeeM.Services.Employeeservices
{

    public class EmployeeService(string dbPath) : IEmployeeRepository, IEquatable<EmployeeService?>
    {
        string _dbPath = dbPath;
        

        public Task<IEnumerable> EmployeeInfo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public SQLiteAsyncConnection Database { get; set; }

        private async Task InitAsync()
        {
            if (Database != null)
            {
                return;
            }
            Database = new SQLiteAsyncConnection(_dbPath);
            await NewMethod();
        }
        private async Task NewMethod()
        {
            _ = await Database.CreateTableAsync<T>();
        }

        public async Task<bool> AddUpdateEmployeeAsync(Employeeinfo employeeInfo)
        {
            
            if(employeeInfo.EmployeeID >0)
            {
                await Database.UpdateAsync(employeeInfo);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteEmployeeAsync(int employeeId)
        {
            await Database.DeleteAsync<EmployeeInfo>(employeeId);
            return await Task.FromResult(true);
        }

        public async Task<Employeeinfo> GetEmployeeAsync(int employeeId)
        {
            return await Database.Table<Employeeinfo>(employeeId).Where(p => p.employeeId
                                                                                                                                                                                                                       == employeeId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Employeeinfo>> GetEmployeeAsync()
        {
            await InitAsync();
            return await NewMethod1();
        }

        private async Task<IEnumerable<Employeeinfo>> NewMethod1()
        {
            return (IEnumerable<Employeeinfo>)await Task.FromResult(await Database.Table<Employeeinfo1>()
                .ToListAsync());
        }

        Task<EmployeeInfo> IEmployeeRepository.GetEmployeeAsync(int employeeId)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as EmployeeService);
        }

        public bool Equals(EmployeeService? other)
        {
            return other is not null &&
                   EqualityComparer<SQLiteAsyncConnection>.Default.Equals(Database, other.Database) &&
                   _dbPath == other._dbPath &&
                   EqualityComparer<Task<IEnumerable>>.Default.Equals(EmployeeInfo, other.EmployeeInfo);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
