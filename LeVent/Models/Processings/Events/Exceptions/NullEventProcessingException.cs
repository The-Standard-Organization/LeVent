// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using Xeptions;

namespace LeVent.Models.Processings.Events.Exceptions
{
    public class NullEventProcessingException : Xeption
    {
        public NullEventProcessingException()
            : base("Event is null") { }
    }
}
