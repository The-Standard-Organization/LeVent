// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using LeVent.Models.Foundations.EventHandlerRegistrations;
using LeVent.Models.Foundations.EventHandlerRegistrations.Exceptions;

namespace LeVent.Services.Foundations.EventRegistrations
{
    public partial class EventHandlerRegistrationService<T>
    {
        private static void ValidateEventHandlerRegistration(
            EventHandlerRegistration<T> eventHandlerRegistration)
        {
            ValidateEventHandlerRegistrationIsNotNull(eventHandlerRegistration);

            Validate(
                 (Rule: IsInvalid(eventHandlerRegistration.EventHandler),
                 Parameter: nameof(EventHandlerRegistration<T>.EventHandler)));
        }

        private static void ValidateEventHandlerRegistrationIsNotNull(
            EventHandlerRegistration<T> eventHandlerRegistration)
        {
            if (eventHandlerRegistration is null)
            {
                throw new NullEventHandlerRegistrationException();
            }
        }

        private static dynamic IsInvalid(Func<T, ValueTask> EventHandler) => new
        {
            Condition = EventHandler == null,
            Message = "Handler is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidEventHandlerRegistrationException =
                new InvalidEventHandlerRegistrationException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidEventHandlerRegistrationException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidEventHandlerRegistrationException.ThrowIfContainsErrors();
        }
    }
}
