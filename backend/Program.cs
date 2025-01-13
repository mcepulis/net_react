using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Backend.DTOs;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("QuizAppDb"));
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        builder => builder.WithOrigins("http://localhost:8080")  
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Quiz API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Quiz API v1");
        c.RoutePrefix = string.Empty; 
    });
}

app.UseCors("AllowFrontend");

app.UseRouting();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DbInitializer.Seed(context); 
}

app.Run();
