using BusinessObject.Interfaces;
using DataAccess.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuraci�n Inicial
ConfigurationManager configuration = builder.Configuration;

//Cadena de conexi�n sql............................
builder.Services.AddDbContext<ApplicationDbContext>(Options => Options.UseSqlite(
    configuration.GetConnectionString("DefaultConnection")));

//Inyecci�n de dependencias
builder.Services.AddScoped<IUser, BusinessObject.Services.UserService>();


var app = builder.Build();

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