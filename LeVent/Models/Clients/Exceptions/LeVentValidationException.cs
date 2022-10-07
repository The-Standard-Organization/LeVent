// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using Xeptions;

namespace LeVent.Models.Clients.Exceptions
{
    public class LeVentValidationException : Xeption
    {
        public LeVentValidationException(Xeption innerException)
            : base(message: "LeVent validation error occurred, fix errors and try again.",
                  innerException)
        { }
    }
}
