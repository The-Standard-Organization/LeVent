﻿// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

using Xeptions;

namespace LeVent.Models.Foundations.EventHandlerRegistrations.Exceptions
{
    public class NullEventHandlerRegistrationException : Xeption
    {
        public NullEventHandlerRegistrationException(string message)
            : base(message)
        { }
    }
}