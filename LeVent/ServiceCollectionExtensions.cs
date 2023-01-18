using LeVent.Brokers.Storages;
using LeVent.Models.Foundations.EventHandlerRegistrations;
using LeVent.Services.Foundations.EventRegistrations;
using LeVent.Services.Processings.Events;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace LeVent
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLeVentServices<T>(
            this IServiceCollection services,
            List<EventHandlerRegistration<T>> eventHandlerRegistrations)
        {
            StorageBroker<T> storageBroker = new();

            foreach (EventHandlerRegistration<T> eventRegistration in eventHandlerRegistrations)
            {
                storageBroker.InsertEventHandlerRegistration(eventRegistration);
            }

            return services
                    .AddScoped<IStorageBroker<T>>(_ => storageBroker)
                    .AddScoped<IEventHandlerRegistrationService<T>, EventHandlerRegistrationService<T>>()
                    .AddScoped<IEventProcessingService<T>, EventProcessingService<T>>();
        }
    }
}
