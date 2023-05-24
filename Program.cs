global using RolePlayingGameApi.Models;
global using RolePlayingGameApi.Services.CharacterService;
global using RolePlayingGameApi.Dtos.Characters;
global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
global using RolePlayingGameApi.Data;
global using RolePlayingGameApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(
  options => options.UseSqlServer(builder.Configuration.GetConnectionString("CharacterDBConnection")
));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();

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
