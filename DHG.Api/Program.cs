using Microsoft.EntityFrameworkCore;
using DHG.DataAccess.Context;
using DHG.DataAccess.Repository.Contracts;
using DHG.DataAccess.Repository.Implementations;

var builder = WebApplication.CreateBuilder(args);

//***************************************************************************************

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("Apphumorgatilho");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{  
    options.UseSqlServer(connectionString);    
});

builder.Services.AddScoped<IRegistroDiarioRepository, RegistroDiarioRepository>();

builder.Services.AddControllers().AddJsonOptions(option =>
{   
    option.JsonSerializerOptions.WriteIndented = true;    
    option.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
});

builder.Services.AddControllers();

//***************************************************************************************

var app = builder.Build();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
