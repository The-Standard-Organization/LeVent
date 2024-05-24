// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers
// -------------------------------------------------------------------------------

using Xeptions;

namespace LeVent.Models.Processings.Events.Exceptions
{
    public class EventProcessingValidationException : Xeption
    {
        public EventProcessingValidationException(Xeption innerException)
            : base(message: "Event validation error occurred, please fix error and try again. ",
                innerException)
        { }
        
        public EventProcessingValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}