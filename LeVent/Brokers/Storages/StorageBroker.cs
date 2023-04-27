// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LeVent.Models.Foundations.EventHandlerRegistrations;

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
