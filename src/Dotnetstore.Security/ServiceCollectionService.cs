using Microsoft.Extensions.DependencyInjection;

namespace Dotnetstore.Security;

public static class ServiceCollectionService
{
    public static IServiceCollection AddDotnetstoreSecurity(this IServiceCollection services)
    {
        services
            .AddScoped<IAsymmetricEncryptionService, AsymmetricEncryptionService>()
            .AddScoped<IEncryptionService, EncryptionService>()
            .AddScoped<IHashService, HashService>();
        
        return services;
    }
}