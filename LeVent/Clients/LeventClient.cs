// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------


using System;
using System.Threading.Tasks;
using LeVent.Brokers.Storages;
using LeVent.Models.Clients.Exceptions;
using LeVent.Models.Foundations.Events.Exceptions;
using LeVent.Models.Processings.Events.Exceptions;
using LeVent.Services.Foundations.EventRegistrations;
using LeVent.Services.Processings.Events;
using Xeptions;

namespace LeVent.Clients
{
    public class LeVentClient<T> : ILeVentClient<T>
    {
        private readonly IEventProcessingService<T> eventProcessingService;

        public LeVentClient()
        {
            IStorageBroker<T> storageBroker =
                new StorageBroker<T>();

            IEventHandlerRegistrationService<T> registrationService =
                new EventHandlerRegistrationService<T>(storageBroker);

            this.eventProcessingService =
                new EventProcessingService<T>(registrationService);
        }

        public async ValueTask PublishEventAsync(T @event, string eventName = null)
        {
            try
            {
                await this.eventProcessingService.PublishEventAsync(@event, eventName);
            }
            catch (EventProcessingValidationException eventProcessingValidationException)
            {
                throw CreateLeVentValidationException(eventProcessingValidationException);
            }
            catch (EventProcessingDependencyValidationException eventProcessingDependencyValidationException)
            {
                throw CreateLeVentValidationException(eventProcessingDependencyValidationException);
            }
            catch (EventProcessingDependencyException eventProcessingDependencyException)
            {
                throw CreateLeVentDependencyException(eventProcessingDependencyException);
            }
            catch (EventProcessingServiceException eventProcessingServiceException)
            {
                throw CreateLeVentServiceException(eventProcessingServiceException);
            }
        }

        public void RegisterEventHandler(Func<T, ValueTask> eventHandler, string eventName = null)
        {
            try
            {
                this.eventProcessingService.AddEventHandler(eventHandler, eventName);
            }
            catch (EventProcessingValidationException eventProcessingValidationException)
            {
                throw CreateLeVentValidationException(eventProcessingValidationException);
            }
            catch (EventProcessingDependencyValidationException eventProcessingDependencyValidationException)
            {
                throw CreateLeVentValidationException(eventProcessingDependencyValidationException);
            }
            catch (EventProcessingDependencyException eventProcessingDependencyException)
            {
                throw CreateLeVentDependencyException(eventProcessingDependencyException);
            }
            catch (EventProcessingServiceException eventProcessingServiceException)
            {
                throw CreateLeVentServiceException(eventProcessingServiceException);
            }
        }

        private static LeVentValidationException CreateLeVentValidationException(Xeption innerException)
        {
            return new LeVentValidationException(
                message: "LeVent validation error occurred, fix errors and try again.",
                innerException: innerException);
        }

        private static LeVentDependencyException CreateLeVentDependencyException(Xeption innerException)
        {
            return new LeVentDependencyException(
                message: "LeVent dependency error occurred, contact support.",
                innerException: innerException);
        }

        private static LeVentServiceException CreateLeVentServiceException(Xeption innerException)
        {
            return new LeVentServiceException(
                message: "LeVent service error occurred, fix errors and try again.",
                innerException: innerException);
        }
    }
}