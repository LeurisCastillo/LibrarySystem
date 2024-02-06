
using LibraryAPI.Models.Context;
using LibraryAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiDemo.Services.Interfaces;

namespace WebApiDemo.Services
{
    public class AutorService : IAutorService
    {
        private LibraryDbContext db;

        public AutorService(LibraryDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(Autor entity)
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
                var autor = await GetAsync(id);
                if (autor != null)
                {
                    db.Remove(autor);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Autor> GetAsync(int id)
        {
            try
            {
                return await db.Set<Autor>().FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Autor>> GetAllAsync()
        {
            try
            {
               return await db.Set<Autor>().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(Autor entity)
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
