// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Threading.Tasks;

namespace LeVent.Brokers.Storages
{
    public partial interface IStorageBroker<T>
    {
        void InsertEventHandler(Func<T, ValueTask> eventHandler);
    }
}
