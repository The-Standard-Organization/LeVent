// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers
// -------------------------------------------------------------------------------

using Xeptions;

namespace LeVent.Models.Processings.Events.Exceptions
{
    public class EventProcessingValidationException : Xeption
    {
        public EventProcessingValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}