using Microsoft.EntityFrameworkCore;
using PokemonReviewApp;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Step 5: dependency injection("just means bring this to the program") wire seed.cs
builder.Services.AddTransient<Seed>(); // add object to very beginning "AddTransient"

// install AutoMapper DependencyInjection
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// step 13: wire up api/endpoints ("dependency injection")
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
// builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
// builder.Services.AddScoped<IReviewerRepository, ReviewerRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Step 3: wire in sserver , connection string, DataContext.cs file
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Step 6: add seed data before app starts
if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}

// Middleware
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


/* Step 7: add migration (sql queries)
 * 
 * command
 * 
 * Search Package Manager Console
 * open Microsoft SQL Server
 * dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0.10
 * command: Add-Migration InitialCreate 
 * command: Update-Database
 * 
 * 
 * 
 * if error: delete migration and re-do command ( Remove-Migration )
 * 
 *
 * Step 8: run database seed
 * 
 * search terminal
 * dir cd PokemonReviewApp
 * dotnet run seeddata
 * 
 * check microsoft sql server: make sure table are seeded , right click table --> select top 1000 Rows
 * 
 * if error: double check Seed.cs and program.cs related to seed depency injection
 */


/*
 shortcuts

"ctrl + ." gives recommendation code
 
 */

/*
 debug

How to fix if swagger is not opening
- Double click the file PokemonReviewApp.sln

How to check Erorrs
- search for Error list 
 */