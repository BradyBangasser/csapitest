using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt => {
    opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo {
        Title = "Test API"
    });
});
builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(opt => {
        opt.RouteTemplate = "docs/{documentName}/swagger.json";
    });
    app.UseSwaggerUI(opt => {
        opt.SwaggerEndpoint("/docs/v1/swagger.json", "Test API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
