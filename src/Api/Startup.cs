using FluentValidation;
using Pickles.Api.Validators;
using Pickles.Domain;
using Pickles.Domain.Config;
using Pickles.Domain.Extensions;

namespace Pickles.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
        var environmentName = Environment.GetEnvironmentVariable("Hosting:Environment");

        var appSettingsConfig = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environmentName}.json", true)
            .AddEnvironmentVariables()
            .Build();

        var appSettings = new AppSettings();
        appSettingsConfig.Bind(appSettings);

        Console.WriteLine(appSettings.ToJson());
        services.AddSingleton(appSettings);

        services.AddControllers();
        services.AddDomain(appSettings);
        services.AddValidatorsFromAssemblyContaining<UserValidator>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
            });
        });
    }
}