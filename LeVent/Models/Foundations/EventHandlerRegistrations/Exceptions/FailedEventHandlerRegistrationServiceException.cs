// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

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
    }
}