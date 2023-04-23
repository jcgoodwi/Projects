using DataAccess;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<Repository>();
builder.Services.AddDbContext<FlashcardDbContext>((options) => options.UseSqlServer(builder.Configuration.GetConnectionString("FlashCardDB")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();