﻿// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers
// -------------------------------------------------------------------------------

using Xeptions;

namespace LeVent.Models.Processings.Events.Exceptions
{
    public class NullEventProcessingException : Xeption
    {
        public NullEventProcessingException(string message)
            : base(message)
        { }
    }
}