// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------


using System;
using System.Threading.Tasks;

namespace LeVent.Clients
{
    public interface ILeVentClient<T>
    {
        void RegisterEventHandler(Func<T, ValueTask> eventHandler, string eventName = null);
        ValueTask PublishEventAsync(T @event, string eventName = null);
    }
}
