// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using Xeptions;

namespace LeVent.Models.Foundations.Events.Exceptions
{
    public class FailedEventServiceException : Xeption
    {
        public FailedEventServiceException(Exception innerException)
            : base("Failed event service error ocurred, contact support.",
                  innerException)
        { }
    }
}
