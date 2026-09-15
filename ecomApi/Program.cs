using ecomApi.Controllers.Models;
using ecomApi.Interface;
using ecomApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddDbContext<EcomDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("EcomDbConnection")));    

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
