// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LeVent.Models.Foundations.Events;

namespace LeVent.Brokers.Storages
{
    public partial class StorageBroker<T> : IStorageBroker<T>
    {
        private static List<Func<T, ValueTask>> EventHandlers;
        private static List<EventHandlerRegistration<T>> EventHandlerRegistrations;

        public StorageBroker()
        {
            EventHandlers = new List<Func<T, ValueTask>>();
            EventHandlerRegistrations = new List<EventHandlerRegistration<T>>();
        }
    }
}
