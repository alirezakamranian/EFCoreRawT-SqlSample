using Microsoft.EntityFrameworkCore;
using RawT_SqlSample.DataAccess;

var builder = WebApplication.CreateBuilder(args);

//                                  services container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlServer("Server=localhost;Database=RawT-SqlSample;User Id=SA;Password=12230500o90P;TrustServerCertificate=True"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//                                  HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
