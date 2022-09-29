// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using Xeptions;

namespace LeVent.Models.Foundations.Events.Exceptions
{
    public class EventValidationException : Xeption
    {
        public EventValidationException(Xeption innerException)
            : base("Event validation error occurred, please fix error and try again. ", innerException) { }
    }
}
