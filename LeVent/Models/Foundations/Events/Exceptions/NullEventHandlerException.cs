// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using Xeptions;

namespace LeVent.Models.Foundations.Events.Exceptions
{
    public class NullEventHandlerException : Xeption
    {
        public NullEventHandlerException()
            : base("Event handler is null") { }
    }
}
