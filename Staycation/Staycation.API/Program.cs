using Microsoft.EntityFrameworkCore;
using Staycation.Business.Interfaces;
using Staycation.Business.Services;
using Staycation.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string? connString = builder.Configuration.GetConnectionString("StaycationDB");

builder.Services.AddDbContext<StaycationContext>(options =>
{
    options.UseSqlServer(connString);
});
builder.Services.AddTransient<IAccommodationService, AccommodationService>();

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
