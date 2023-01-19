using Azure.Messaging.EventGrid;
using LeVent.Services.Processings.Events;
using System.Threading.Tasks;

namespace LeVent.Azure.EventGrid.Services
{
    internal class EventGridProcessingService : IEventGridProcessingService
    {
        private readonly IEventProcessingService<EventGridEvent> eventProcessingService;

        public EventGridProcessingService(IEventProcessingService<EventGridEvent> eventProcessingService)
        {
            this.eventProcessingService = eventProcessingService;
        }

        public async ValueTask PublishEventAsync(EventGridEvent @event, string eventName)
        {
            await eventProcessingService.PublishEventAsync(@event, eventName);
        }
    }
}
