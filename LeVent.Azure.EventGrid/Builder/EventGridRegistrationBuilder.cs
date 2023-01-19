using Azure.Messaging.EventGrid;
using LeVent.Models.Foundations.EventHandlerRegistrations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeVent.Azure.EventGrid.Builder
{
    public class EventGridRegistrationBuilder
    {
        private readonly List<EventHandlerRegistration<EventGridEvent>> eventHandlerRegistrations;

        public EventGridRegistrationBuilder()
        {
            eventHandlerRegistrations = new();
        }

        public void AddEventGridEvent(string name, Func<EventGridEvent, ValueTask> eventHandler)
        {
            EventHandlerRegistration<EventGridEvent> eventRegistration = new()
            {
                EventName = name,
                EventHandler = eventHandler
            };

            eventHandlerRegistrations.Add(eventRegistration);
        }

        public List<EventHandlerRegistration<EventGridEvent>> Build()
        {
            return eventHandlerRegistrations;
        }
    }
}
