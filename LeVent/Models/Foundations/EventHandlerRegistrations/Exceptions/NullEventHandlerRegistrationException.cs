// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

using Xeptions;

namespace LeVent.Models.Foundations.EventHandlerRegistrations.Exceptions
{
    public class NullEventHandlerRegistrationException : Xeption
    {
        public NullEventHandlerRegistrationException()
            : base(message: "Event handler is null")
        { }

        public NullEventHandlerRegistrationException(string message)
            : base(message)
        { }
    }
}