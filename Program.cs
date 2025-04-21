using Labb_3_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Info.Version = "v1";
        document.Info.Title = ".NET 9 API";
        document.Info.Description = "This API make it possible to coneect services to a person";
        document.Info.Contact = new OpenApiContact
        {
            Name = "Josef Forkman",
            Email = "Josef@forkman.dev",
            Url = new Uri("https://www.linkedin.com/in/josef-forkman/")
        };
        document.Info.License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://opensource.org/licenses/MIT")
        };

        return Task.CompletedTask;
    });
});

builder.Services.AddDbContext<DBContext>(option => option.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
