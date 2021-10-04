using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotDeskApp.Repository
{
    public class OwnerRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public OwnerRepository(HotDeskDBContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await FindAll()
               .OrderBy(e => e.Login)
               .ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid employeeId)
        {
            return await FindByCondition(employee => employee.EmployeeId.Equals(employeeId))
                .FirstOrDefaultAsync();
        }

        public async Task<Employee> GetEmployeeWithDetailsAsync(Guid employeeId)
        {
            return await FindByCondition(employee => employee.EmployeeId.Equals(employeeId))
                .Include(ac => ac.Reservations)
                .FirstOrDefaultAsync();
        }

        public void CreateEmployee(Employee employee)
        {
            Create(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            Update(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }
    }
}
