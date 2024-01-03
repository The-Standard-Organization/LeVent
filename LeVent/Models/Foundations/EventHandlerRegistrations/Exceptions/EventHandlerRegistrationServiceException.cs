// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------


using Xeptions;

namespace LeVent.Models.Foundations.EventHandlerRegistrations.Exceptions
{
    public class EventHandlerRegistrationServiceException : Xeption
    {
        public EventHandlerRegistrationServiceException(Xeption innerException)
            : base(message: "Event service error occurred, contact support.",
                innerException)
        { }
        
        public EventHandlerRegistrationServiceException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}