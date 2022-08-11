using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarModeAPI.Services;
using WarModeAPI.Services.Interface;
using WarModeAPI.WarModeConfig;

namespace WarModeAPI.ConfigureServices
{
    public static class ConfigureService
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            TibiaDataConfig tibiaDataConfig = new TibiaDataConfig();

            configuration
                .GetSection("TibiaDataConfig")
                .Bind(tibiaDataConfig);

            services.AddHttpClient("TibiaData", options =>
            {
                options.BaseAddress = new Uri(tibiaDataConfig.Url);
            });

            services.Configure<TibiaDataConfig>(configuration.GetSection("TibiaDataConfig"));
            //services.AddTransient<IWarModeService, WarModeService>();

        }
    }
}
