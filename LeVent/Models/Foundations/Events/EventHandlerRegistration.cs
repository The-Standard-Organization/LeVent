// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Threading.Tasks;

namespace LeVent.Models.Foundations.Events
{
    public class EventHandlerRegistration<T>
    {
        public Func<T, ValueTask> EventHandler { get; set; }
        public string EventName { get; set; }
    }
}
