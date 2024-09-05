using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDMVC.Data;
using CRUDMVC.Interface;
using CRUDMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDMVC.Repository
{
    public class CompanyRepository(DataContext context) : ICompanyRepository
    {
        public async Task CreateAsync(Company company)
        {
            await context.Companies.AddAsync(company);
        }

        public async Task DeleteAsync(Company company)
        {
            context.Companies.Remove(company);
        }

        public async Task<IEnumerable<Company>> GetAsync()
        {
            return await context.Companies.ToListAsync();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await context.Companies.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public async Task UpdateAsync(Company company)
        {
            context.Entry(company).State = EntityState.Modified;
        }
    }
}