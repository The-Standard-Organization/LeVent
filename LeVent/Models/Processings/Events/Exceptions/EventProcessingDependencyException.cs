// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using Xeptions;

namespace LeVent.Models.Processings.Events.Exceptions
{
    public class EventProcessingDependencyException : Xeption
    {
        public EventProcessingDependencyException(Xeption innerException)
            : base("Event error occurred, please fix error and try again. ",
                  innerException)
        { }
    }
}
