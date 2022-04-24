using System.Reflection;
using cv09;
using cv09.Middlewares;
using cv09.Services;
using cv09.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

// Add services to the container.
builder.Services.AddDbContext<EShopContext>(options =>
    options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IEShopService, EShopService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "EShop API", Version = "v1"});
});

var app = builder.Build();

try
{
    using var scope = app.Services.CreateScope();

    var context = scope.ServiceProvider.GetService<EShopContext>();

    await context.Database.MigrateAsync();
    EShopContextSeed.Seed(context);
}
catch
{
    Console.WriteLine("An error occurred while migrating or seeding the database.");
    throw;
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<HttpContextMiddleware>();

app.MapControllers();

await app.RunAsync();
