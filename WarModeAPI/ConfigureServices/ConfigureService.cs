using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarModeAPI.WarModeConfig;

namespace WarModeAPI.ConfigureServices
{
    public static class ConfigureService
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            APIConfig apiConfig = new APIConfig();

            configuration
                .GetSection("APIConfig")
                .Bind(apiConfig);

            services.AddHttpClient("WarMode", options =>
            {
                options.BaseAddress = new Uri(apiConfig.Url);
            });

            services.Configure<APIConfig>(configuration.GetSection("APIConfig"));

        }
    }
}
