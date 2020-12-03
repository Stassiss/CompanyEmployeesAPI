using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
                                     FindAll(trackChanges)
                                     .OrderBy(c => c.Name)
                                     .ToList();

    }
}
