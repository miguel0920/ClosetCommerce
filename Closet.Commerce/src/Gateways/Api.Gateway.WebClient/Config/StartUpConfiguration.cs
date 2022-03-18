﻿using Api.Gateway.Proxies;
using Api.Gateway.Proxies.Implementations;
using Api.Gateway.Proxies.Interfaces;

namespace Api.Gateway.WebClient.Config
{
    public static class StartUpConfiguration
    {
        public static IServiceCollection AddAppsettingBinding(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<ApiUrls>(opts => configuration.GetSection("ApiUrls").Bind(opts));
            return service;
        }

        public static IServiceCollection AddProxiesRegistration(this IServiceCollection service)
        {
            service.AddHttpContextAccessor();

            service.AddHttpClient<IOrderProxy, OrderProxy>();
            service.AddHttpClient<ICustomerProxy, CustomerProxy>();
            service.AddHttpClient<ICatalogProxy, CatalogProxy>();

            return service;
        }
    }
}