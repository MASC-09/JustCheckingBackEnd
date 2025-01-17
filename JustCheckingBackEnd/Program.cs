using JustCheckingDatabase.Context;
using JustCheckingDatabase.Services;
using JustCheckingDatabase.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<JCDEVDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("JCDEV")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMeasurementService, MeasurementService>();
builder.Services.AddScoped<IUserPlanService, UserPlanService>();
builder.Services.AddScoped<IMacroCardService, MacrocardService>();




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
