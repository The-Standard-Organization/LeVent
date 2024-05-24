// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

using Xeptions;

namespace LeVent.Models.Clients.Exceptions
{
    public class LeVentDependencyException : Xeption
    {
        public LeVentDependencyException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}