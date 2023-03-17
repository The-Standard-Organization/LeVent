// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using LeVent.Models.Foundations.EventHandlerRegistrations;
using System.Collections.Generic;

namespace LeVent.Brokers.Storages
{
    public partial interface IStorageBroker<T>
    {
        void InsertEventHandlerRegistration(EventHandlerRegistration<T> eventHandlerRegistration);
        List<EventHandlerRegistration<T>> SelectAllEventHandlerRegistrations();
    }
}
