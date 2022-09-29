// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using LeVent.Models.Foundations.Events.Exceptions;

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
                var failedEventStorageException = 
                    new FailedEventStorageException(exception);

                throw new EventDependencyException(failedEventStorageException);
            }
        }
    }
}
