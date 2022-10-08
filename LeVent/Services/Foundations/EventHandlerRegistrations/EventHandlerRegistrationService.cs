// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using LeVent.Brokers.Storages;
using LeVent.Models.Foundations.Events;

namespace LeVent.Services.Foundations.EventRegistrations
{
    public class EventHandlerRegistrationService<T> : IEventHandlerRegistrationService<T>
    {
        private readonly IStorageBroker<T> storageBroker;

        public EventHandlerRegistrationService(IStorageBroker<T> storageBroker) =>
            this.storageBroker = storageBroker;

        public void AddEventHandlerRegistation(EventHandlerRegistration<T> eventHandlerRegistration)
        {
            this.storageBroker.InsertEventHandlerRegistration(eventHandlerRegistration);
        }
    }
}
