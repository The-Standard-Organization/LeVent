// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

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
