// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

using Xeptions;

namespace LeVent.Models.Foundations.EventHandlerRegistrations.Exceptions
{
    public class InvalidEventHandlerRegistrationException : Xeption
    {
        public InvalidEventHandlerRegistrationException()
            : base(message: "Invalid event handler registration error ocurred, fix errors and try again.")
        { }
        
        public InvalidEventHandlerRegistrationException(string message)
            : base(message)
        { }
    }
}