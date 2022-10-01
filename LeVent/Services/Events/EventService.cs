// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LeVent.Brokers.Storages;

namespace LeVent.Services.Events
{
    public partial class EventService<T> : IEventService<T>
    {
        private readonly IStorageBroker<T> storageBroker;

        public EventService(IStorageBroker<T> storageBroker) =>
            this.storageBroker = storageBroker;

        public void AddEventHandler(Func<T, ValueTask> eventHandler) =>
        TryCatch(() =>
        {
            ValidateEventHandler(eventHandler);

            this.storageBroker.InsertEventHandler(eventHandler);
        });

        public List<Func<T, ValueTask>> RetrieveAllEventHandlers() => 
        TryCatch(() => this.storageBroker.SelectAllEventHandlers());
    }
}
