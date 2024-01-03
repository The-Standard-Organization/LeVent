// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

using System;
using Xeptions;

namespace LeVent.Models.Foundations.EventHandlerRegistrations.Exceptions
{
    public class FailedEventHandlerRegistrationServiceException : Xeption
    {
        public FailedEventHandlerRegistrationServiceException(Exception innerException)
            : base(message: "Failed event handler registration service error occurred, contact support.",
                innerException)
        { }
        
        public FailedEventHandlerRegistrationServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}