// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using LeVent.Models.Foundations.EventHandlerRegistrations.Exceptions;
using LeVent.Models.Foundations.Events.Exceptions;
using LeVent.Models.Processings.Events.Exceptions;
using Xeptions;

namespace LeVent.Services.Processings.Events
{
    public partial class EventProcessingService<T>
    {
        private delegate void ReturningNothingFunction();
        private delegate ValueTask ReturningValueTaskFunction();

        private void TryCatch(ReturningNothingFunction returningNothingFunction)
        {
            try
            {
                returningNothingFunction();
            }
            catch (NullEventHandlerProcessingException nullEventHandlerProcessingException)
            {
                throw CreateEventProcessingValidationException(nullEventHandlerProcessingException);
            }
            catch (EventHandlerRegistrationValidationException eventHandlerRegistrationValidationException)
            {
                throw CreateEventProcessingDependencyValidationException(
                    eventHandlerRegistrationValidationException.InnerException as Xeption);
            }
            catch (EventHandlerRegistrationServiceException eventHandlerRegistrationServiceException)
            {
                throw CreateEventProcessingDependencyException(
                    eventHandlerRegistrationServiceException.InnerException as Xeption);
            }
            catch (Exception exception)
            {
                var failedEventProcessingServiceException =
                    new FailedEventProcessingServiceException(
                            message: "Failed event service error ocurred, contact support.",
                            innerException: exception);

                throw CreateEventProcessingServiceException(
                    failedEventProcessingServiceException);
            }
        }

        private async ValueTask TryCatch(ReturningValueTaskFunction returningValueTaskFunction)
        {
            try
            {
                await returningValueTaskFunction();
            }
            catch (NullEventProcessingException nullEventProcessingException)
            {
                throw CreateEventProcessingValidationException(nullEventProcessingException);
            }
            catch (Exception exception)
            {
                var failedEventProcessingServiceException =
                    new FailedEventProcessingServiceException(
                        message: "Failed event service error ocurred, contact support.",
                        innerException: exception);

                throw CreateEventProcessingServiceException(
                    failedEventProcessingServiceException);
            }
        }

        private static EventProcessingValidationException CreateEventProcessingValidationException(
            Xeption innerException)
        {
            return new EventProcessingValidationException(
                message: "Event validation error occurred, please fix error and try again.",
                innerException: innerException);
        }

        private static EventProcessingDependencyValidationException CreateEventProcessingDependencyValidationException(
            Xeption innerException)
        {
            return new EventProcessingDependencyValidationException(
                message: "Event validation error occurred, please fix error and try again.",
                innerException: innerException);
        }

        private static EventProcessingDependencyException CreateEventProcessingDependencyException(
            Xeption innerException)
        {
            return new EventProcessingDependencyException(
                message: "Event error occurred, please fix error and try again.",
                innerException: innerException);
        }

        private static EventProcessingServiceException CreateEventProcessingServiceException(
            Xeption innerException)
        {
            return new EventProcessingServiceException(
                message: "Event service error occurred, contact support.",
                innerException: innerException);
        }
    }
}
