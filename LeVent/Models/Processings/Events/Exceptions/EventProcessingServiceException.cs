// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using Xeptions;

namespace LeVent.Models.Foundations.Events.Exceptions
{
    public class EventProcessingServiceException : Xeption
    {
        public EventProcessingServiceException(Xeption innerException)
            : base(message: "Event service error occurred, contact support.",
                  innerException)
        { }
    }
}
