// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Threading.Tasks;
using LeVent.Brokers.Storages;
using LeVent.Models.Clients.Exceptions;
using LeVent.Models.Foundations.Events.Exceptions;
using LeVent.Models.Processings.Events.Exceptions;
using LeVent.Services.Foundations.Events;
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

            IEventService<T> eventService =
                new EventService<T>(storageBroker);

            this.eventProcessingService =
                new EventProcessingService<T>(eventService);
        }

        public async ValueTask PublishEventAsync(T @event)
        {
            try
            {
                await this.eventProcessingService.PublishEventAsync(@event);
            }
            catch (EventProcessingValidationException eventProcessingValidationException)
            {
                throw new LeVentValidationException(
                    eventProcessingValidationException.InnerException as Xeption);
            }
            catch (EventProcessingDependencyValidationException eventProcessingDependencyValidationException)
            {
                throw new LeVentValidationException(
                    eventProcessingDependencyValidationException.InnerException as Xeption);
            }
            catch (EventProcessingDependencyException eventProcessingDependencyException)
            {
                throw new LeVentDependencyException(
                    eventProcessingDependencyException.InnerException as Xeption);
            }
            catch (EventProcessingServiceException eventProcessingServiceException)
            {
                throw new LeVentServiceException(
                    eventProcessingServiceException.InnerException as Xeption);
            }
        }

        public void RegisterEventHandler(Func<T, ValueTask> eventHandler)
        {
            try
            {
                this.eventProcessingService.AddEventHandler(eventHandler);
            }
            catch (EventProcessingValidationException eventProcessingValidationException)
            {
                throw new LeVentValidationException(
                    eventProcessingValidationException.InnerException as Xeption);
            }
            catch (EventProcessingDependencyValidationException eventProcessingDependencyValidationException)
            {
                throw new LeVentValidationException(
                    eventProcessingDependencyValidationException.InnerException as Xeption);
            }
            catch (EventProcessingDependencyException eventProcessingDependencyException)
            {
                throw new LeVentDependencyException(
                    eventProcessingDependencyException.InnerException as Xeption);
            }
            catch (EventProcessingServiceException eventProcessingServiceException)
            {
                throw new LeVentServiceException(
                    eventProcessingServiceException.InnerException as Xeption);
            }
        }
    }
}
