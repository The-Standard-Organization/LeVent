// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeVent.Brokers.Storages
{
    public partial class StorageBroker<T> : IStorageBroker<T>
    {
        private static List<Func<T, ValueTask>> EventHandlers;

        public StorageBroker() =>
            EventHandlers = new List<Func<T, ValueTask>>();
    }
}
