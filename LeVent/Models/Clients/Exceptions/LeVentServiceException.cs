// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using Xeptions;

namespace LeVent.Models.Clients.Exceptions
{
    public class LeVentServiceException : Xeption
    {
        public LeVentServiceException(Xeption innerException)
            : base(message: "LeVent service error occurred, fix errors and try again.",
                  innerException)
        { }
    }
}
