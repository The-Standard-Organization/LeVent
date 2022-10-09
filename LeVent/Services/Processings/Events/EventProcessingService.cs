// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

            this.eventService.AddEventHandler(eventHandler);
        });

        public ValueTask PublishEventAsync(T @event) =>
        TryCatch(async () =>
        {
            ValidateEvent(@event);

            List<Func<T, ValueTask>> registeredEvents =
                this.eventService.RetrieveAllEventHandlers();

            foreach (Func<T, ValueTask> registeredEvent in registeredEvents)
            {
                await registeredEvent(@event);
            }
        });
    }
}
