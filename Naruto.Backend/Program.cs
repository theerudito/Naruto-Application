using Blazored.LocalStorage;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.EntityFrameworkCore;
using Naruto.Data;
using Naruto.Helpers;
using Naruto.Service.Interface;
using Naruto.Service.Repositories;

var builder = WebApplication.CreateBuilder(args);


//var connectionString = builder.Configuration.GetConnectionString("MyDatabase");

//builder.Services.AddDbContext<Application_ContextDB>(options => options.UseSqlite(connectionString));


string baseDirectory = AppContext.BaseDirectory;

string folder = "MyDatabase";
string database = "Naruto.db";
string databaseFilePath = Path.Combine(baseDirectory, folder, database);

var connectionString = $"Data Source={databaseFilePath}";


// // Sqlite
builder.Services.AddDbContext<Application_ContextDB>(options => options.UseSqlite(connectionString));


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSweetAlert2();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<ICharacter, RepositoryCharacter>();
builder.Services.AddScoped<IClan, RepositoryClan>();

builder.Services.AddScoped<Cloudinary_Manager>();
builder.Services.AddScoped<RepositoryAuth>();
builder.Services.AddScoped<LocalStorageData>();
builder.Services.AddScoped<RepositoryJutsu>();
builder.Services.AddScoped<RepositoryOcupation>();
builder.Services.AddScoped<RepositoryCurrent>();
builder.Services.AddScoped<RepositoryVillage>();
builder.Services.AddScoped<InitialConfiguration>();


//AutoMapper
builder.Services.AddAutoMapper(typeof(MappingConfiguration));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
