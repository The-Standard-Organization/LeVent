// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeVent.Models.Foundations.EventHandlerRegistrations;
using LeVent.Services.Foundations.EventRegistrations;
using LeVent.Services.Foundations.Events;

namespace LeVent.Services.Processings.Events
{
    public partial class EventProcessingService<T> : IEventProcessingService<T>
    {
        private readonly IEventService<T> eventService;
        private readonly IEventHandlerRegistrationService<T> eventHandlerRegistrationService;

        public EventProcessingService(
            IEventService<T> eventService,
            IEventHandlerRegistrationService<T> eventHandlerRegistrationService)
        {
            this.eventService = eventService;
            this.eventHandlerRegistrationService = eventHandlerRegistrationService;
        }

        public void AddEventHandler(Func<T, ValueTask> eventHandler, string eventName = null) =>
        TryCatch(() =>
        {
            ValidateEventHandler(eventHandler);

            var eventHandlerRegistration = new EventHandlerRegistration<T>
            {
                EventHandler = eventHandler,
                EventName = eventName
            };

            this.eventHandlerRegistrationService.AddEventHandlerRegistation(
                eventHandlerRegistration);
        });

        public ValueTask PublishEventAsync(T @event, string eventName = null) =>
        TryCatch(async () =>
        {
            ValidateEvent(@event);

            List<EventHandlerRegistration<T>> registrations =
                this.eventHandlerRegistrationService
                    .RetrieveAllEventHandlerRegistrations();

            List<Func<T, ValueTask>> eventHandlers = 
                registrations.Where(registration =>
                    registration.EventName == eventName)
                        .Select(registration =>
                            registration.EventHandler)
                                .ToList();

            foreach (Func<T, ValueTask> eventHandler in eventHandlers)
            {
                await eventHandler(@event);
            }
        });
    }
}
