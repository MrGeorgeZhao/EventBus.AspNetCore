using Eventbus.AspNetCore;
using Eventbus.AspNetCore.Abstractions;
using Eventbus.AspNetCore.DefaultEventBus;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus.AspNetCore.DependencyInjection
{
    public static class EventBusExtension
    {
        public static void AddMemoryEventBus(this IServiceCollection services)
        {
            services.AddTransient<IEventBus, MemoryEventBus>();
            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
        }
    }
}
