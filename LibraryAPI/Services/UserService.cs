
using LibraryAPI.Models.Context;
using LibraryAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiDemo.Services.Interfaces;

namespace WebApiDemo.Services
{
    public class UserService : IUserService
    {
        private LibraryDbContext db;

        public UserService(LibraryDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(User entity)
        {
            try
            {
                await db.AddAsync(entity);
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var user = await GetAsync(id);
                if (user != null)
                {
                    db.Remove(user);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> GetAsync(int id)
        {
            try
            {
                return await db.Set<User>().FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<User>> GetAllAsync()
        {
            try
            {
               return await db.Set<User>().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(User entity)
        {
            try
            {
                db.Entry(entity).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
