using Microsoft.Extensions.DependencyInjection;
using Mpesa.Lib.Settings;
using Mpesa.Lib.Services;
using Mpesa.Lib.Enums;
using Mpesa.Factory;

namespace Mpesa;

public static class MpesaExtension
{
    public static IServiceCollection ConfigureMpesa(this IServiceCollection services, Config configuration)
    {
     services.AddSingleton<IMpesa>(serviceProvider =>
     {
         Enum.TryParse(configuration.Env, out Env enviroment);
         IMpesa client = factory.CreateMpesaClient(configuration, enviroment);
         return client;
     });

        return services;
    }
}
