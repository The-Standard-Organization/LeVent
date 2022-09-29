// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using Xeptions;

namespace LeVent.Models.Foundations.Events.Exceptions
{
    public class FailedEventStorageException : Xeption
    {
        public FailedEventStorageException(Exception innerException)
            : base("Failed event storage dependency error ocurred, contact support.",
                  innerException)
        { }
    }
}
