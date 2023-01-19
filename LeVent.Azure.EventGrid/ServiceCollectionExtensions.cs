using Azure.Messaging.EventGrid;
using LeVent.Azure.EventGrid.Builder;
using LeVent.Azure.EventGrid.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LeVent.Azure.EventGrid
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection UseAzureEventGrid(this IServiceCollection services, Action<EventGridRegistrationBuilder> builderAction)
        {
            EventGridRegistrationBuilder builder = new();

            builderAction(builder);

            services
                .AddOptions<EventGridOptions>()
                .BindConfiguration(nameof(EventGridOptions));


            return services
                .AddScoped<IEventGridProcessingService, EventGridProcessingService>()
                .AddLeVentServices<EventGridEvent>(builder.Build());
        }

        public static IServiceCollection UseAzureEventGrid(
            this IServiceCollection services,
            Action<EventGridRegistrationBuilder> builderAction,
            Action<EventGridOptions> eventGridOptionsConfiguration)
        {
            EventGridRegistrationBuilder builder = new();

            builderAction(builder);

            services.Configure<EventGridOptions>(eventGridOptionsConfiguration);

            return services;
        }
    }
}
