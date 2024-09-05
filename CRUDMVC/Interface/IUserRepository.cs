using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDMVC.Models;

namespace CRUDMVC.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetAsync();
        Task<AppUser> GetByIdAsync(int id);
        Task CreateAsync(AppUser user);
        Task UpdateAsync(AppUser user);
        Task DeleteAsync(AppUser user);
        Task<bool> SaveChangesAsync();
    }
}