// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using Xeptions;

namespace LeVent.Models.Foundations.Events.Exceptions
{
    public class EventDependencyException : Xeption
    {
        public EventDependencyException(Xeption innerException)
            : base(message: "Event dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
