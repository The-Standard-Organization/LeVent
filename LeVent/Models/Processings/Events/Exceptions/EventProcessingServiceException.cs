// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers
// -------------------------------------------------------------------------------

using Xeptions;

namespace LeVent.Models.Foundations.Events.Exceptions
{
    public class EventProcessingServiceException : Xeption
    {
        public EventProcessingServiceException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}