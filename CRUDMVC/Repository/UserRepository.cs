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
    public class UserRepository(DataContext context) : IUserRepository
    {
        public async Task CreateAsync(AppUser user)
        {
            await context.Users.AddAsync(user);
        }

        public async Task DeleteAsync(AppUser user)
        {
            context.Users.Remove(user);
        }

        public async Task<IEnumerable<AppUser>> GetAsync()
        {
            return await context.Users.Include(c => c.Companies).ToListAsync();
        }

        public async Task<AppUser> GetByIdAsync(int id)
        {
            return await context.Users.Include(c => c.Companies).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public async Task UpdateAsync(AppUser user)
        {
            context.Entry(user).State = EntityState.Modified;
        }
    }
}