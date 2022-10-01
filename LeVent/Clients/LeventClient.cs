// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Threading.Tasks;
using LeVent.Services.Processings.Events;

namespace LeVent.Clients
{
    public class LeventClient<T> : ILeventClient<T>
    {
        private readonly IEventProcessingService<T> eventProcessingService;

        public LeventClient(IEventProcessingService<T> eventProcessingService) =>
            this.eventProcessingService = eventProcessingService;

        public async ValueTask PublishEventAsync(T @event) =>
            await this.eventProcessingService.PublishEventAsync(@event);

        public void RegisterEventHandler(Func<T, ValueTask> eventHandler) =>
            this.eventProcessingService.AddEventHandler(eventHandler);
    }
}
