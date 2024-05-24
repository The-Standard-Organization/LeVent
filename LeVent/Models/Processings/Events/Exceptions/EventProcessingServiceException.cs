// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers
// -------------------------------------------------------------------------------

using Xeptions;

namespace LeVent.Models.Foundations.Events.Exceptions
{
    public class EventProcessingServiceException : Xeption
    {
        public EventProcessingServiceException(Xeption innerException)
            : base(message: "Event service error occurred, contact support.",
                innerException)
        { }
        
        public EventProcessingServiceException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}