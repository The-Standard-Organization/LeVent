// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using Xeptions;

namespace LeVent.Models.Foundations.EventHandlerRegistrations.Exceptions
{
    public class InvalidEventHandlerRegistrationException : Xeption
    {
        public InvalidEventHandlerRegistrationException()
            : base(message: "Invalid event handler registration error ocurred, fix errors and try again.")
        { }
    }
}
