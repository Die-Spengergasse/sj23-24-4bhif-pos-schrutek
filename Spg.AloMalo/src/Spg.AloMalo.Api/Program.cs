using Microsoft.EntityFrameworkCore;
using Spg.AloMalo.Application.Mock;
using Spg.AloMalo.Application.Services;
using Spg.AloMalo.DomainModel.Interfaces;
using Spg.AloMalo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB Context registrieren:
builder.Services.AddDbContext<PhotoContext>(o => o.UseSqlite(""));

builder.Services.AddScoped<IPhotoService, PhotoService>();

string? c = builder.Configuration.GetConnectionString("MSSQL");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
