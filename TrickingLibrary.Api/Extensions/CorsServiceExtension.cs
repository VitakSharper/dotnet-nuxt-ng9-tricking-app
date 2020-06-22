using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TrickingLibrary.Api.Extensions
{
    public static class CorsServiceExtension
    {
        private const string Rules = "corsRules";

        public static IServiceCollection AddCorsServices(this IServiceCollection services)
        {
            services.AddCors(opt =>
                opt.AddPolicy(Rules, build =>
                    build.AllowAnyHeader().AllowAnyOrigin().AllowAnyOrigin()));
            return services;
        }

        public static IApplicationBuilder UseCorsMiddleware(this IApplicationBuilder app)
        {
            app.UseCors(Rules);
            return app;
        }
    }
}