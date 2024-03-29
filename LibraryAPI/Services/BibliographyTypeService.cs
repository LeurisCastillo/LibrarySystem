﻿
using LibraryAPI.Models.Context;
using LibraryAPI.Models.Entities;
using LibraryAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibraryAPI.Services
{
    public class BibliographyTypeService : IBibliographyTypeService
    {
        private LibraryDbContext db;

        public BibliographyTypeService(LibraryDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(BibliographyType entity)
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
                var bibliographyType = await GetAsync(id);
                if (bibliographyType != null)
                {
                    db.Remove(bibliographyType);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BibliographyType> GetAsync(int id)
        {
            try
            {
                return await db.Set<BibliographyType>().FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<BibliographyType>> GetAllAsync()
        {
            try
            {
                return await db.Set<BibliographyType>().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(BibliographyType entity)
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
