// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using LeVent.Models.Foundations.EventHandlerRegistrations.Exceptions;

namespace LeVent.Services.Foundations.EventRegistrations
{
    public partial class EventHandlerRegistrationService<T> : IEventHandlerRegistrationService<T>
    {
        private delegate void ReturningNothingFunction();

        private void TryCatch(ReturningNothingFunction returningNothingFunction)
        {
            try
            {
                returningNothingFunction();
            }
            catch (NullEventHandlerRegistrationException nullEventHandlerRegistrationException)
            {
                throw new EventHandlerRegistrationValidationException(
                    nullEventHandlerRegistrationException);
            }
        }
    }
}
