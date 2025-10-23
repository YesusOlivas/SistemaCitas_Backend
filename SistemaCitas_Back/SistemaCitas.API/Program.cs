using Microsoft.EntityFrameworkCore;
using SistemaCitas.API.Extensions;
using SistemaCitas.BusinessLogic;
using SistemaCitas.DataAccess.Context;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("CitaMediConn");

builder.Services.AddDbContext<SistemaCitasContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddHttpContextAccessor();

builder.Services.DataAccess(connectionString);
builder.Services.BusinessLogic();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost4200", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

 builder.Services.AddAutoMapper(config =>
 {
    config.AddProfile(typeof(MappingProfileExtensions));
 });

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowLocalhost4200");

app.UseAuthorization();

app.MapControllers();

app.Run();