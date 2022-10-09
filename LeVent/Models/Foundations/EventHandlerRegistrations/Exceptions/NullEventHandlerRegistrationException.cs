// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using Xeptions;

namespace LeVent.Models.Foundations.EventHandlerRegistrations.Exceptions
{
    public class NullEventHandlerRegistrationException : Xeption
    {
        public NullEventHandlerRegistrationException() : base("Event handler is null") { }
    }
}
