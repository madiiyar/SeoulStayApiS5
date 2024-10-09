using Microsoft.EntityFrameworkCore;
using SeoulStayApiS5.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SeoulStayMobileS5Context>(options => options.
UseSqlServer(builder.Configuration.GetConnectionString("defcon")));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
