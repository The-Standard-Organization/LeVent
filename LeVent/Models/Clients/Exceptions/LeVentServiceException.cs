// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

using Xeptions;

namespace LeVent.Models.Clients.Exceptions
{
    public class LeVentServiceException : Xeption
    {
        public LeVentServiceException(Xeption innerException)
            : base(message: "LeVent service error occurred, fix errors and try again.",
                  innerException)
        { }

        public LeVentServiceException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}