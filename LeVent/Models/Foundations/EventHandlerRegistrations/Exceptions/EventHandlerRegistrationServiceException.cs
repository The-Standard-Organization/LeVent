// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using Xeptions;

namespace LeVent.Models.Foundations.EventHandlerRegistrations.Exceptions
{
    public class EventHandlerRegistrationServiceException : Xeption
    {
        public EventHandlerRegistrationServiceException(Xeption innerException)
            : base("Event service error occurred, contact support.",
                innerException)
        { }
    }
}
