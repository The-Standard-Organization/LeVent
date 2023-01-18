using Azure.Messaging.EventGrid;
using LeVent.Models.Foundations.EventHandlerRegistrations;

namespace LeVent.Azure.EventGrid.Builder
{
    public class EventGridRegistrationBuilder
    {
        private readonly List<EventHandlerRegistration<EventGridEvent>> eventHandlerRegistrations;

        public EventGridRegistrationBuilder()
        {
            eventHandlerRegistrations = new();
        }

        public void AddEventGridEvent(EventHandlerRegistration<EventGridEvent> eventRegistration)
        {
            eventHandlerRegistrations.Add(eventRegistration);
        }

        public List<EventHandlerRegistration<EventGridEvent>> Build()
        {
            return eventHandlerRegistrations;
        }
    }
}
