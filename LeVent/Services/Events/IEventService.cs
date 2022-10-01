// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeVent.Services.Events
{
    public interface IEventService<T>
    {
        void AddEventHandler(Func<T, ValueTask> eventHandler);
        List<Func<T, ValueTask>> RetrieveAllEventHandlers();
    }
}
