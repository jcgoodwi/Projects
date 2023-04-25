using DataAccess;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;

var  MyAllowSpecificOrigins = "*";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>  
{  
    options.AddPolicy(name: MyAllowSpecificOrigins,  
        policy  =>  
        {  
            policy.WithOrigins(MyAllowSpecificOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod(); // add the allowed origins  
        });  
});  

builder.Services.AddScoped<Repository>();
builder.Services.AddDbContext<FlashcardDbContext>((options) => options.UseSqlServer(builder.Configuration.GetConnectionString("FlashCardDB")));
builder.Services.AddCors(opt =>
        {
            opt.AddPolicy(name: "OpenAccess", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
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

app.UseCors(MyAllowSpecificOrigins);

app.Run();
