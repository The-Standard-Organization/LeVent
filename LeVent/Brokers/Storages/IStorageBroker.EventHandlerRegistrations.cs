// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System.Collections.Generic;
using LeVent.Models.Foundations.Events;

namespace LeVent.Brokers.Storages
{
    public partial interface IStorageBroker<T>
    {
        void InsertEventHandlerRegistration(EventHandlerRegistration<T> eventHandlerRegistration);
        List<EventHandlerRegistration<T>> SelectAllEventHandlerRegistrations();
    }
}
