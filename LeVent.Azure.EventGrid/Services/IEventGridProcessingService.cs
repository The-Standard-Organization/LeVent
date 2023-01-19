using Azure.Messaging.EventGrid;
using System.Threading.Tasks;

namespace LeVent.Azure.EventGrid.Services
{
    public interface IEventGridProcessingService
    {
        ValueTask PublishEventAsync(EventGridEvent @event, string eventName);
    }
}
