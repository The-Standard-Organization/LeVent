// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers
// -------------------------------------------------------------------------------

using Xeptions;

namespace LeVent.Models.Processings.Events.Exceptions
{
    public class NullEventHandlerProcessingException : Xeption
    {
        public NullEventHandlerProcessingException(string message)
            : base(message)
        { }
    }
}