using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDMVC.Models;

namespace CRUDMVC.Interface
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAsync();
        Task<Company> GetByIdAsync(int id);
        Task CreateAsync(Company company);
        Task UpdateAsync(Company company);
        Task DeleteAsync(Company company);
        Task<bool> SaveChangesAsync();
    }
}