// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using LeVent.Models.Foundations.EventHandlerRegistrations;
using LeVent.Models.Foundations.EventHandlerRegistrations.Exceptions;
using Xeptions;

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
                throw CreateEventHandlerRegistrationValidationException(
                    nullEventHandlerRegistrationException);
            }
            catch (InvalidEventHandlerRegistrationException invalidEventHandlerRegistrationException)
            {
                throw CreateEventHandlerRegistrationValidationException(
                    invalidEventHandlerRegistrationException);
            }
            catch (Exception exception)
            {
                var failedEventHandlerRegistrationServiceException =
                    new FailedEventHandlerRegistrationServiceException(
                        message: "Failed event handler registration service error occurred, contact support.",
                        innerException: exception);

                throw CreateEventHandlerRegistrationServiceException(
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
                    new FailedEventHandlerRegistrationServiceException(
                        message: "Failed event handler registration service error occurred, contact support.",
                        innerException: exception);

                throw CreateEventHandlerRegistrationServiceException(
                    failedEventHandlerRegistrationServiceException);
            }
        }

        private static EventHandlerRegistrationValidationException CreateEventHandlerRegistrationValidationException(
            Xeption innerException)
        {
            return new EventHandlerRegistrationValidationException(
                message: "Event validation error occurred, please fix error and try again.",
                innerException: innerException);
        }

        private static EventHandlerRegistrationServiceException CreateEventHandlerRegistrationServiceException(
            Xeption innerException)
        {
            return new EventHandlerRegistrationServiceException(
                message: "Event service error occurred, contact support.",
                innerException: innerException);
        }
    }
}
