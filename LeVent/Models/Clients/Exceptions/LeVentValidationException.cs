// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

using Xeptions;

namespace LeVent.Models.Clients.Exceptions
{
    public class LeVentValidationException : Xeption
    {
        public LeVentValidationException(Xeption innerException)
            : base(message: "LeVent validation error occurred, fix errors and try again.",
                  innerException)
        { }
        
        public LeVentValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}