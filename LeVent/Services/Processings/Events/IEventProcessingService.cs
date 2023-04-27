// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;

namespace LeVent.Services.Processings.Events
{
    public interface IEventProcessingService<T>
    {
        void AddEventHandler(Func<T, ValueTask> eventHandler, string eventName = null);
        ValueTask PublishEventAsync(T @event, string eventName = null);
    }
}
