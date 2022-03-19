using Microsoft.Extensions.DependencyInjection;
using mpesa.lib.settings;
using Mpesa.lib.Services;
using Mpesa.lib.Enums;
using Mpesa.Factory;


namespace Mpesa;

public static class MpesaExtension
{

    public static IServiceCollection ConfigureMpesa(this IServiceCollection services, Config configuration)
    {
        services.AddSingleton<IMpesa>(serviceProvider =>
     {
         var configuration = serviceProvider.GetRequiredService<IConfig>();
         Enum.TryParse(configuration.Env, out Env enviroment);
         IMpesa client = factory.CreateMpesaClient(configuration, enviroment);
         return client;
     });

        return services;
    }

}
