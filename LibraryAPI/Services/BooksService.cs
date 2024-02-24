
using LibraryAPI.Models.Context;
using LibraryAPI.Models.Entities;
using LibraryAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibraryAPI.Services
{
    public class BookService : IBookService
    {
        private LibraryDbContext db;

        public BookService(LibraryDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(Book entity)
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
                var book = await GetAsync(id);
                if (book != null)
                {
                    db.Remove(book);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Book> GetAsync(int id)
        {
            try
            {
                return await db.Set<Book>().FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Book>> GetAllAsync()
        {
            try
            {
                return await db.Set<Book>().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(Book entity)
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
