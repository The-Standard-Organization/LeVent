// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using Xeptions;

namespace LeVent.Models.Processings.Events.Exceptions
{
    public class NullEventHandlerProcessingException : Xeption
    {
        public NullEventHandlerProcessingException()
            : base("Event handler is null") { }
    }
}
