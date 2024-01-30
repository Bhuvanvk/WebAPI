using Microsoft.Extensions.Hosting;
using WebAPI.Filters;
using WebAPI.Middleware;
using WebAPI.Repositories.Implementations;
using WebAPI.Repositories.Interfaces;
using WebAPI.Services.Implementations;
using WebAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ActionFilter)); // Add the filter globally
});

//builder.Services.addsw
builder.Services.AddLogging();
builder.Services.AddScoped<ISubmissionServiceRepo, SubmissionServiceRepo>();
builder.Services.AddScoped<ISubmissionService, SubmissionService>();
builder.Services.AddTransient<ExceptionLoggingMiddleware>();//addmiddleware service
builder.Services.AddScoped<ActionFilter>();// register service filter

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(option => {
    option.AllowAnyHeader();
    option.AllowAnyMethod();
    option.AllowAnyOrigin();
    });
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<ExceptionLoggingMiddleware>();// use middleware

app.Run();
