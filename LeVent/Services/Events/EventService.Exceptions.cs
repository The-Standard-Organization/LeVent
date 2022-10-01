// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LeVent.Models.Foundations.Events.Exceptions;

namespace LeVent.Services.Events
{
    public partial class EventService<T>
    {
        private delegate void ReturningNothingFunction();
        private delegate List<Func<T, ValueTask>> ReturningFuncsFunction();

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

        private List<Func<T, ValueTask>> TryCatch(ReturningFuncsFunction returningFuncsFunction)
        {
            try
            {
                return returningFuncsFunction();
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
