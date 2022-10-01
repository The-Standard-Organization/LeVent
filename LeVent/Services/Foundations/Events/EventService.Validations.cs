// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Threading.Tasks;
using LeVent.Models.Foundations.Events.Exceptions;

namespace LeVent.Services.Foundations.Events
{
    public partial class EventService<T> : IEventService<T>
    {
        private static void ValidateEventHandler(Func<T, ValueTask> eventHandler)
        {
            if (eventHandler is null)
            {
                throw new NullEventHandlerException();
            }
        }
    }
}
