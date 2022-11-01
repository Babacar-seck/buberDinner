using BuberDinner.Api.Errors;
using BuberDinner.Api.Filters;
using BuberDinner.Api.Middleware;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);
// Seconde Approche      
//builder.Services.AddControllers( opt => opt.Filters.Add<ErrorHandlingFilterAttribute>());
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

var app = builder.Build();
{
    // La premiere approche pour créer un middleware simple 
    // app.UseMiddleware<ErrorHandlingMiddleware>();

    // Troisieme Approche 
    //Adds a middleware to the pipeline that will catch exceptions, log them, reset the request path, and re-execute the request. The request will not be re-executed if the response has already started.
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
