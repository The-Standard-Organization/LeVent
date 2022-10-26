// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Threading.Tasks;
using LeVent.Models.Processings.Events.Exceptions;

namespace LeVent.Services.Processings.Events
{
    public partial class EventProcessingService<T> : IEventProcessingService<T>
    {
        private static void ValidateEventHandler(Func<T, ValueTask> eventHandler)
        {
            if (eventHandler is null)
            {
                throw new NullEventHandlerProcessingException();
            }
        }

        private static void ValidateEvent(T @event)
        {
            if (@event == null)
            {
                throw new NullEventProcessingException();
            }
        }
    }
}
