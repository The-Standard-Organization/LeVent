// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

using Xeptions;

namespace LeVent.Models.Foundations.EventHandlerRegistrations.Exceptions
{
    public class InvalidEventHandlerRegistrationException : Xeption
    {
        public InvalidEventHandlerRegistrationException(string message)
            : base(message)
        { }
    }
}