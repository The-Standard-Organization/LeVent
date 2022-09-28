// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeVent.Brokers.Storages
{
    public partial class StorageBroker<T>
    {
        public void InsertEventHandler(Func<T, ValueTask> eventHandler) =>
            EventHandlers.Add(eventHandler);

        public List<Func<T, ValueTask>> SelectAllEventHandlers() =>
            EventHandlers;
    }
}
