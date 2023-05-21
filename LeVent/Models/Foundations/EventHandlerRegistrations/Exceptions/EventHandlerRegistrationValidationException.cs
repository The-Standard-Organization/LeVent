// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------


using Xeptions;

namespace LeVent.Models.Foundations.EventHandlerRegistrations.Exceptions
{
    public class EventHandlerRegistrationValidationException : Xeption
    {
        public EventHandlerRegistrationValidationException(Xeption innerException)
            : base("Event validation error occurred, please fix error and try again. ",
                innerException)
        { }
    }
}
