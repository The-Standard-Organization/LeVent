// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using LeVent.Models.Foundations.Events;

namespace LeVent.Services.Foundations.EventRegistrations
{
    public interface IEventHandlerRegistrationService<T>
    {
        void AddEventHandlerRegistation(EventHandlerRegistration<T> eventHandlerRegistration);
    }
}
