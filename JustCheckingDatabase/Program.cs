using JustCheckingDatabase.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<JCDEVDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("JCDEV")));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
