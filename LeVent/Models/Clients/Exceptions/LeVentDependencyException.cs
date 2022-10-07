// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using Xeptions;

namespace LeVent.Models.Clients.Exceptions
{
    public class LeVentDependencyException : Xeption
    {
        public LeVentDependencyException(Xeption innerException)
            : base(message: "LeVent dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
