// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Threading.Tasks;

namespace LeVent.Services.Events
{
    public interface IEventService<T>
    {
        void AddEventHandler(Func<T, ValueTask> eventHandler);
    }
}
