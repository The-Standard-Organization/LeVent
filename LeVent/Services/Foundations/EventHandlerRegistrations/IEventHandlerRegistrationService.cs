// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System.Collections.Generic;
using LeVent.Models.Foundations.EventHandlerRegistrations;

namespace LeVent.Services.Foundations.EventRegistrations
{
    public interface IEventHandlerRegistrationService<T>
    {
        void AddEventHandlerRegistation(EventHandlerRegistration<T> eventHandlerRegistration);
        List<EventHandlerRegistration<T>> RetrieveAllEventHandlerRegistrations();
    }
}
