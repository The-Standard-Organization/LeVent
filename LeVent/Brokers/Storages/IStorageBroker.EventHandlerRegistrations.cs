// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using LeVent.Models.Foundations.EventHandlerRegistrations;

namespace LeVent.Brokers.Storages
{
    public partial interface IStorageBroker<T>
    {
        void InsertEventHandlerRegistration(EventHandlerRegistration<T> eventHandlerRegistration);
        List<EventHandlerRegistration<T>> SelectAllEventHandlerRegistrations();
    }
}
