using Asp.Versioning;

namespace OpenApi.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddProblemDetails();
            builder.Services.AddOpenApi();

            // Api Versioning
            builder.Services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;
                opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader());
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            var app = builder.Build();

            app.UseExceptionHandler();
            app.UseStatusCodePages();
            app.MapOpenApi();
            app.MapControllers();

            app.Run();
        }
    }
}
