// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Threading.Tasks;
using LeVent.Brokers.Storages;
using LeVent.Services.Foundations.Events;
using LeVent.Services.Processings.Events;

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

        public async ValueTask PublishEventAsync(T @event) =>
            await this.eventProcessingService.PublishEventAsync(@event);

        public void RegisterEventHandler(Func<T, ValueTask> eventHandler) =>
            this.eventProcessingService.AddEventHandler(eventHandler);
    }
}
