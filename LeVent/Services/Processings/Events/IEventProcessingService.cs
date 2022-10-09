// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Threading.Tasks;

namespace LeVent.Services.Processings.Events
{
    public interface IEventProcessingService<T>
    {
        void AddEventHandler(Func<T, ValueTask> eventHandler, string eventName = null);
        ValueTask PublishEventAsync(T @event);
    }
}
