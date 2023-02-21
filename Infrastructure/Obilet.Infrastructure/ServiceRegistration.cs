using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Obilet.Application.Models.BusJourneys;
using Obilet.Application.Models.BusLocations;
using Obilet.Application.Models.Sessions;
using Obilet.Application.Repositories;
using Obilet.Application.Repositories.BusJourney;
using Obilet.Application.Repositories.BusLocation;
using Obilet.Application.Repositories.ServiceApi;
using Obilet.Application.Repositories.Session;
using Obilet.Application.Validations;
using Obilet.Infrastructure.Repositories;
using Obilet.Infrastructure.Repositories.BusJourney;
using Obilet.Infrastructure.Repositories.BusLocation;
using Obilet.Infrastructure.Repositories.ServiceApi;
using Obilet.Infrastructure.Repositories.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {

            services.AddHttpClient("obilet", httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://v2-api.obilet.com/api/");
                httpClient.DefaultRequestHeaders.Add("Authorization", "Basic JEcYcEMyantZV095WVc3G2JtVjNZbWx1");
            });
            services.AddScoped<ICookieManager, CookieManager>();
            services.AddScoped<ISessionRepository<SessionResponse>,SessionRepositories>();
            services.AddScoped<IServiceApiRepository,ServiceApiRepository>();
            services.AddScoped<IBusLocationRepository, BusLocationRepositories>();
            services.AddBrowserDetection();
            services.AddScoped<IBusJourneyRepository, BusJourneyRepositories>();
           
           services.AddFluentValidation(o => o.RegisterValidatorsFromAssemblyContaining<BusLocationValidator>());
            return services;
        }
    }
}
