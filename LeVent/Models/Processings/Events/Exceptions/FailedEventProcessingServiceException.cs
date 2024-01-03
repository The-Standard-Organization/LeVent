// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers
// -------------------------------------------------------------------------------

using System;
using Xeptions;

namespace LeVent.Models.Foundations.Events.Exceptions
{
    public class FailedEventProcessingServiceException : Xeption
    {
        public FailedEventProcessingServiceException(Exception innerException)
            : base(message: "Failed event service error ocurred, contact support.",
                innerException)
        { }
        
        public FailedEventProcessingServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}