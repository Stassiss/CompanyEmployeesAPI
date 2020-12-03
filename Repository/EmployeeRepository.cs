using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges) =>
            FindByCondition(c => c.CompanyId.Equals(companyId), trackChanges)
            .OrderBy(e => e.Name);

        public Employee GetEmployee(Guid companyId, Guid id, bool trackChanges)
        {
            return FindByCondition(c => c.CompanyId.Equals(companyId) && c.Id.Equals(id), false)
                .SingleOrDefault();
        }
    }
}
