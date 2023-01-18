using Azure.Messaging.EventGrid;
using LeVent.Azure.EventGrid.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LeVent.Azure.EventGrid
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection UseAzureEventGrid(this IServiceCollection services, Action<EventGridRegistrationBuilder> builderAction)
        {
            EventGridRegistrationBuilder builder = new();

            builderAction(builder);

            return services.AddLeVentServices<EventGridEvent>(builder.Build());
        }
    }
}
