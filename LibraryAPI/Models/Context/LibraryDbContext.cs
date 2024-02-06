using LibraryAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Models.Context
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Autor> Autors { get; set; }
        public DbSet<BibliographyType> BibliographyTypes { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Editorial> Editorials { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LoanAndReturn> LoanAndReturns { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
