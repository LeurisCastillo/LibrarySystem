
using LibraryAPI.Models.Context;
using LibraryAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiDemo.Services.Interfaces;

namespace WebApiDemo.Services
{
    public class EmployeeService : IEmployeeService
    {
        private LibraryDbContext db;

        public EmployeeService(LibraryDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(Employee entity)
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
                var employee = await GetAsync(id);
                if (employee != null)
                {
                    db.Remove(employee);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Employee> GetAsync(int id)
        {
            try
            {
                return await db.Set<Employee>().FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            try
            {
               return await db.Set<Employee>().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(Employee entity)
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
