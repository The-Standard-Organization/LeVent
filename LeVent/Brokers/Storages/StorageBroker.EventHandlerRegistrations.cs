// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System.Collections.Generic;

namespace LeVent.Brokers.Storages
{
    public partial class StorageBroker<T>
    {
        public void InsertEventHandlerRegistration(EventHandlerRegistration<T> eventHandlerRegistration) =>
            EventHandlerRegistrations.Add(eventHandlerRegistration);

        public List<EventHandlerRegistration<T>> SelectAllEventHandlerRegistrations() =>
            EventHandlerRegistrations;
    }
}
