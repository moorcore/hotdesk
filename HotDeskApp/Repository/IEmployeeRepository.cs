using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotDeskApp.Repository
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(Guid employeeId);
        Task<Employee> GetEmployeeWithDetailsAsync(Guid employeeId);
        void CreateEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
