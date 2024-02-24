using LibraryAPI.Models.Context;
using LibraryAPI.Services;
using LibraryAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbCon")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAutorService, AutorService>();
builder.Services.AddScoped<IBibliographyTypeService, BibliographyTypeService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IEditorialService, EditorialService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ILanguageService, LanguageService>();
builder.Services.AddScoped<ILoanAndReturnService, LoanAndReturnService>();
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseEndpoints(x =>
{
    x.MapControllers();
});

app.UseHttpsRedirection();

app.Run();


