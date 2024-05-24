// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers
// -------------------------------------------------------------------------------

using Xeptions;

namespace LeVent.Models.Processings.Events.Exceptions
{
    public class EventProcessingDependencyValidationException : Xeption
    {
        public EventProcessingDependencyValidationException(Xeption innerException)
            : base(message: "Event validation error occurred, please fix error and try again.",
                innerException)
        { }
        
        public EventProcessingDependencyValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}