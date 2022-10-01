// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using LeVent.Models.Foundations.Events.Exceptions;
using Xeptions;

namespace LeVent.Services.Events
{
    public partial class EventService<T> : IEventService<T>
    {
        private delegate void ReturningNothingFunction();

        private void TryCatch(ReturningNothingFunction returningNothingFunction)
        {
            try
            {
                returningNothingFunction();
            }
            catch (NullEventHandlerException nullEventHandlerException)
            {
                throw new EventValidationException(nullEventHandlerException);
            }
            catch (Exception exception)
            {
                var failedEventServiceException =
                    new FailedEventServiceException(exception);

                throw new EventServiceException(failedEventServiceException);
            }
        }
    }
}
