
using LibraryAPI.Models.Context;
using LibraryAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiDemo.Services.Interfaces;

namespace WebApiDemo.Services
{
    public class LoanAndReturnService : ILoanAndReturnService
    {
        private LibraryDbContext db;

        public LoanAndReturnService(LibraryDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(LoanAndReturn entity)
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
                var loanAndReturn = await GetAsync(id);
                if (loanAndReturn != null)
                {
                    db.Remove(loanAndReturn);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<LoanAndReturn> GetAsync(int id)
        {
            try
            {
                return await db.Set<LoanAndReturn>().FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<LoanAndReturn>> GetAllAsync()
        {
            try
            {
               return await db.Set<LoanAndReturn>().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(LoanAndReturn entity)
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
