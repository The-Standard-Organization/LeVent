// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using LeVent.Models.Foundations.EventHandlerRegistrations;
using LeVent.Models.Foundations.EventHandlerRegistrations.Exceptions;

namespace LeVent.Services.Foundations.EventRegistrations
{
    public partial class EventHandlerRegistrationService<T>
    {
        private static void ValidateEventHandlerRegistration(
            EventHandlerRegistration<T> eventHandlerRegistration)
        {
            if (eventHandlerRegistration is null)
            {
                throw new NullEventHandlerRegistrationException();
            }
        }
    }
}
