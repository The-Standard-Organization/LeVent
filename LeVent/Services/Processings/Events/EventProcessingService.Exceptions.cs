// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Threading.Tasks;
using LeVent.Models.Foundations.EventHandlerRegistrations.Exceptions;
using LeVent.Models.Foundations.Events.Exceptions;
using LeVent.Models.Processings.Events.Exceptions;
using Xeptions;

namespace LeVent.Services.Processings.Events
{
    public partial class EventProcessingService<T> : IEventProcessingService<T>
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
                throw new EventProcessingValidationException(nullEventHandlerProcessingException);
            }
            catch (EventHandlerRegistrationValidationException eventHandlerRegistrationValidationException)
            {
                throw new EventProcessingDependencyValidationException(
                    eventHandlerRegistrationValidationException.InnerException as Xeption);
            }
            catch (EventDependencyException eventDependencyException)
            {
                throw new EventProcessingDependencyException(
                    eventDependencyException.InnerException as Xeption);
            }
            catch (EventServiceException eventServiceException)
            {
                throw new EventProcessingDependencyException(
                    eventServiceException.InnerException as Xeption);
            }
            catch (Exception exception)
            {
                var failedEventProcessingServiceException =
                    new FailedEventProcessingServiceException(exception);

                throw new EventProcessingServiceException(
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
                throw new EventProcessingValidationException(nullEventProcessingException);
            }
            catch (Exception exception)
            {
                var failedEventProcessingServiceException =
                    new FailedEventProcessingServiceException(exception);

                throw new EventProcessingServiceException(
                    failedEventProcessingServiceException);
            }
        }
    }
}
