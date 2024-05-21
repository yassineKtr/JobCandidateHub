using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Postgresql;

namespace PostgresqlTests;

public static class Helper
{
    private static IServiceProvider serviceProvider;

    public static void Init(Func<IServiceCollection, IServiceCollection> init = null,
        IList<Assembly> assemblies = null)
    {
        var services = new ServiceCollection();
        services.AddOptions();
        var configuration = GetIConfigurationRoot(Directory.GetCurrentDirectory());
        services.UsePostgreSql(configuration.GetSection("PostgreSql"));
        init?.Invoke(services);
        var provider = services.BuildServiceProvider(new ServiceProviderOptions
        {
            ValidateScopes = true
        });
        serviceProvider = provider;
    }

    public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        => new ConfigurationBuilder()
            .SetBasePath(outputPath)
            .AddJsonFile("appsettings.json", true)
            .Build();

    public static T GetInstance<T>() where T : class
        => serviceProvider.GetService<T>();
}