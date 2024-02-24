using LibraryAPI.Models.Entities;

namespace LibraryAPI.Services.Interfaces
{
    public interface IAutorService : ICrud<Autor>
    {
    }

    public interface IBibliographyTypeService : ICrud<BibliographyType>
    {
    }

    public interface IBookService : ICrud<Book>
    {
    }

    public interface IEditorialService : ICrud<Editorial>
    {
    }

    public interface IEmployeeService : ICrud<Employee>
    {
    }

    public interface ILanguageService : ICrud<Language>
    {
    }

    public interface ILoanAndReturnService : ICrud<LoanAndReturn>
    {
    }

    public interface IUserService : ICrud<User>
    {
    }
}
