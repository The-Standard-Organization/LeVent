// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

using Xeptions;

namespace LeVent.Models.Foundations.EventHandlerRegistrations.Exceptions
{
    public class EventHandlerRegistrationValidationException : Xeption
    {
        public EventHandlerRegistrationValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}