// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using LeVent.Models.Foundations.EventHandlerRegistrations;
using LeVent.Models.Foundations.EventHandlerRegistrations.Exceptions;

namespace LeVent.Services.Foundations.EventRegistrations
{
    public partial class EventHandlerRegistrationService<T> : IEventHandlerRegistrationService<T>
    {
        private delegate void ReturningNothingFunction();
        private delegate List<EventHandlerRegistration<T>> ReturningEventHandlerRegistrationFunction();

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
            catch (InvalidEventHandlerRegistrationException invalidEventHandlerRegistrationException)
            {
                throw new EventHandlerRegistrationValidationException(
                    invalidEventHandlerRegistrationException);
            }
            catch (Exception exception)
            {
                var failedEventHandlerRegistrationServiceException =
                    new FailedEventHandlerRegistrationServiceException(exception);

                throw new EventHandlerRegistrationServiceException(
                    failedEventHandlerRegistrationServiceException);
            }
        }

        private List<EventHandlerRegistration<T>> TryCatch(
            ReturningEventHandlerRegistrationFunction returningEventHandlerRegistrationFunction)
        {
            try
            {
                return returningEventHandlerRegistrationFunction();
            }
            catch (Exception exception)
            {
                var failedEventHandlerRegistrationServiceException =
                    new FailedEventHandlerRegistrationServiceException(exception);

                throw new EventHandlerRegistrationServiceException(
                    failedEventHandlerRegistrationServiceException);
            }
        }
    }
}
