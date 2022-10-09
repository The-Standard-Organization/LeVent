// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System.Collections.Generic;
using LeVent.Brokers.Storages;
using LeVent.Models.Foundations.EventHandlerRegistrations;

namespace LeVent.Services.Foundations.EventRegistrations
{
    public partial class EventHandlerRegistrationService<T> : IEventHandlerRegistrationService<T>
    {
        private readonly IStorageBroker<T> storageBroker;

        public EventHandlerRegistrationService(IStorageBroker<T> storageBroker) =>
            this.storageBroker = storageBroker;

        public void AddEventHandlerRegistation(EventHandlerRegistration<T> eventHandlerRegistration) =>
        TryCatch(() =>
        {
            ValidateEventHandlerRegistration(eventHandlerRegistration);

            this.storageBroker.InsertEventHandlerRegistration(eventHandlerRegistration);
        });

        public List<EventHandlerRegistration<T>> RetrieveAllEventHandlerRegistrations() =>
        TryCatch(() => this.storageBroker.SelectAllEventHandlerRegistrations());
    }
}
