// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using LeVent.Models.Foundations.Events.Exceptions;
using LeVent.Models.Processings.Events.Exceptions;
using Xeptions;

namespace LeVent.Services.Processings.Events
{
    public partial class EventProcessingService<T> : IEventProcessingService<T>
    {
        private delegate void ReturningNothingFunction();

        private void TryCatch(ReturningNothingFunction returningNothingFunction)
        {
            try
            {
                returningNothingFunction();
            }
            catch (NullEventHandlerProcessingException nullEventHandlerProcessingException)
            {
                throw new EventProcessingValidationException(nullEventHandlerProcessingException);
            }
            catch (EventValidationException eventValidationException)
            {
                throw new EventProcessingDependencyValidationException(
                    eventValidationException.InnerException as Xeption);
            }
        }
    }
}
