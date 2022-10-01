// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using Xeptions;

namespace LeVent.Models.Processings.Events.Exceptions
{
    public class EventProcessingDependencyValidationException : Xeption
    {
        public EventProcessingDependencyValidationException(Xeption innerException)
            : base("Event validation error occurred, please fix error and try again. ",
                  innerException)
        { }
    }
}
