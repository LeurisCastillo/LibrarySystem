
using LibraryAPI.Models.Context;
using LibraryAPI.Models.Entities;
using LibraryAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibraryAPI.Services
{
    public class LanguageService : ILanguageService
    {
        private LibraryDbContext db;

        public LanguageService(LibraryDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(Language entity)
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
                var language = await GetAsync(id);
                if (language != null)
                {
                    db.Remove(language);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Language> GetAsync(int id)
        {
            try
            {
                return await db.Set<Language>().FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Language>> GetAllAsync()
        {
            try
            {
                return await db.Set<Language>().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(Language entity)
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
