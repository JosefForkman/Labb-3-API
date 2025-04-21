using Microsoft.OpenApi.Models;

namespace Labb_3_API.lib;
public static class OpenApiConfig
{
    public static void ConfigureOpenApi(this IServiceCollection services)
    {
        services.AddOpenApi(options =>
        {
            options.AddDocumentTransformer((document, context, cancellationToken) =>
            {
                document.Info.Version = "v1";
                document.Info.Title = ".NET 9 API";
                document.Info.Description = "This API make it possible to connect services to a person";
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
    }
}
