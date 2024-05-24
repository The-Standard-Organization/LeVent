// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

using System;
using FluentAssertions;
using LeVent.Models.Foundations.EventHandlerRegistrations;
using LeVent.Models.Foundations.EventHandlerRegistrations.Exceptions;
using Moq;
using Xunit;

namespace LeVent.Tests.Unit.Services.Foundations.EventHandlerRegistrations
{
    public partial class EventHandlerRegistrationServiceTests
    {
        [Fact]
        private void ShouldThrowValidationExceptionOnAddIfEventRegistrationHandlerIsNull()
        {
            // given
            EventHandlerRegistration<object> nullEventHandler = null;
            
            var nullEventHandlerException =
                new NullEventHandlerRegistrationException(
                    message: "Event handler is null");

            var expectedEventHandlerRegistrationValidationException =
                new EventHandlerRegistrationValidationException(
                    message: "Event validation error occurred, please fix error and try again. ",
                    innerException: nullEventHandlerException);

            // when
            Action addEventHandlerRegistrationAction = () =>
                this.eventHandlerRegistrationService.AddEventHandlerRegistation(
                    nullEventHandler);

            EventHandlerRegistrationValidationException
                actualEventHandlerRegistrationValidationException =
                    Assert.Throws<EventHandlerRegistrationValidationException>(
                        addEventHandlerRegistrationAction);

            // then
            actualEventHandlerRegistrationValidationException.Should()
                .BeEquivalentTo(expectedEventHandlerRegistrationValidationException);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertEventHandlerRegistration(
                    It.IsAny<EventHandlerRegistration<object>>()),
                        Times.Never);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        private void ShouldThrowValidationExceptionOnAddIfEventHandlerIsNull()
        {
            // given
            EventHandlerRegistration<object> randomEventHandlerRegistration =
                CreateRandomEventHandlerRegistration();

            EventHandlerRegistration<object> invalidEventHandlerRegistration =
                randomEventHandlerRegistration;

            invalidEventHandlerRegistration.EventHandler = null;

            var invalidEventHandlerRegistrationException =
                new InvalidEventHandlerRegistrationException(
                    message: "Invalid event handler registration error ocurred, fix errors and try again.");

            invalidEventHandlerRegistrationException.AddData(
                key: nameof(EventHandlerRegistration<object>.EventHandler),
                values: "Handler is required");

            var expectedEventHandlerRegistrationValidationException =
                new EventHandlerRegistrationValidationException(
                    invalidEventHandlerRegistrationException);

            // when
            Action addEventHandlerRegistrationAction = () =>
                this.eventHandlerRegistrationService.AddEventHandlerRegistation(
                    invalidEventHandlerRegistration);

            EventHandlerRegistrationValidationException
                actualEventHandlerRegistrationValidationException =
                    Assert.Throws<EventHandlerRegistrationValidationException>(
                        addEventHandlerRegistrationAction);

            // then
            actualEventHandlerRegistrationValidationException.Should()
                .BeEquivalentTo(expectedEventHandlerRegistrationValidationException);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertEventHandlerRegistration(
                    It.IsAny<EventHandlerRegistration<object>>()),
                        Times.Never);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
