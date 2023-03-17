// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using LeVent.Models.Foundations.EventHandlerRegistrations;
using System.Collections.Generic;

namespace LeVent.Services.Foundations.EventRegistrations
{
    public interface IEventHandlerRegistrationService<T>
    {
        void AddEventHandlerRegistation(EventHandlerRegistration<T> eventHandlerRegistration);
        List<EventHandlerRegistration<T>> RetrieveAllEventHandlerRegistrations();
    }
}
