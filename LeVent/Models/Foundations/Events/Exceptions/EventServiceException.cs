// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using Xeptions;

namespace LeVent.Models.Foundations.Events.Exceptions
{
    public class EventServiceException : Xeption
    {
        public EventServiceException(Xeption innerException)
            : base(message: "Event service error occurred, contact support.",
                  innerException)
        { }
    }
}
