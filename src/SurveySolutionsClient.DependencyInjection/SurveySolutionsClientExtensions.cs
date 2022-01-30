using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SurveySolutionsClient.Apis;
using System.Net.Http;

namespace SurveySolutionsClient
{
    public static class SurveySolutionsClientExtensions
    {
        public static void AddSurveySolutionsApiClient(this IServiceCollection services)
        {
            services.AddScoped<ISurveySolutionsApi>(s =>
            {
                var httpClient = s.GetService<HttpClient>() ?? new HttpClient();

                var config = s.GetService<IOptions<SurveySolutionsApiConfiguration>>()?.Value;

                if (config == null)
                {
                    var options = s.GetRequiredService<IOptions<SurveySolutionApiClientOptionsConfig>>().Value;

                    config = new SurveySolutionsApiConfiguration(new Credentials(options.UserName, options.Password), options.Url, options.Workspace);
                }

                return new SurveySolutionsApi(httpClient, config);
            });
        }

        public static void ConfigureSurveySolutionsApiClient(this IServiceCollection services, IConfigurationSection section)
        {
            services.Configure<SurveySolutionApiClientOptionsConfig>(section);
        }

        public static void ConfigureSurveySolutionsApiClient(this IServiceCollection services,
            Credentials credentials, string baseUrl, string? workspace = null)
        {
            services.Configure<SurveySolutionsApiConfiguration>(s => new SurveySolutionsApiConfiguration(credentials, baseUrl, workspace));
        }
    }
}
