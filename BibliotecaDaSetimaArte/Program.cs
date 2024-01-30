using AutoMapper;
using BibliotecaDaSetimaArte.Context;
using BibliotecaDaSetimaArte.DTOs.Mapping;
using BibliotecaDaSetimaArte.Extensions;
using BibliotecaDaSetimaArte.Filters;
using BibliotecaDaSetimaArte.Repository;
using BibliotecaDaSetimaArte.Repository.Interfaces;
using BibliotecaDaSetimaArte.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<ApiLogginFilter>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddTransient<IMyService, MyService>();

string MySqlConnectionString = builder.Configuration.GetConnectionString("ConnectionStringDefault");
builder.Services.AddDbContext<AppDbContext>(op =>
{
    op.UseMySql(MySqlConnectionString, ServerVersion.AutoDetect(MySqlConnectionString));
});

builder.Services.AddScoped<IUnityOfWork, UnityOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
