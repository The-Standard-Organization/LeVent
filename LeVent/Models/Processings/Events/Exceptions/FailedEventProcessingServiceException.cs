// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers
// -------------------------------------------------------------------------------

using System;
using Xeptions;

namespace LeVent.Models.Foundations.Events.Exceptions
{
    public class FailedEventProcessingServiceException : Xeption
    {
        public FailedEventProcessingServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}