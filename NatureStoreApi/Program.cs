using Microsoft.EntityFrameworkCore;
using NatureStoreApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();   // Generates the raw documentation endpoints
    app.UseSwaggerUI(); // Hosts the visual web dashboard
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
