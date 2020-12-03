using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext _dbContext;

        public RepositoryManager(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private ICompanyRepository _companyRepository;

        public ICompanyRepository Company
        {
            get
            {
                if (_companyRepository == null)
                {
                    _companyRepository = new CompanyRepository(_dbContext);
                }
                return _companyRepository;
            }
        }

        private IEmployeeRepository _employeeRepository;

        public IEmployeeRepository Employee
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new EmployeeRepository(_dbContext);
                }
                return _employeeRepository;
            }
        }

        public void Save() => _dbContext.SaveChanges();


    }
}
