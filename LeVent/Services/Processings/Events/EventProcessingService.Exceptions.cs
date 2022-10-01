// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using LeVent.Models.Processings.Events.Exceptions;

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
        }
    }
}
