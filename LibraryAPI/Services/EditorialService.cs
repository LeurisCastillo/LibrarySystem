
using LibraryAPI.Models.Context;
using LibraryAPI.Models.Entities;
using LibraryAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibraryAPI.Services
{
    public class EditorialService : IEditorialService
    {
        private LibraryDbContext db;

        public EditorialService(LibraryDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(Editorial entity)
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
                var editorial = await GetAsync(id);
                if (editorial != null)
                {
                    db.Remove(editorial);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Editorial> GetAsync(int id)
        {
            try
            {
                return await db.Set<Editorial>().FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Editorial>> GetAllAsync()
        {
            try
            {
                return await db.Set<Editorial>().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(Editorial entity)
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
