// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using FluentAssertions;
using LeVent.Models.Foundations.EventHandlerRegistrations;
using LeVent.Models.Foundations.EventHandlerRegistrations.Exceptions;
using LeVent.Models.Foundations.Events.Exceptions;
using Moq;
using Xunit;

namespace LeVent.Tests.Unit.Services.Foundations.EventHandlerRegistrations
{
    public partial class EventHandlerRegistrationServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnAddIfEventRegistrationHandlerIsNull()
        {
            // given
            EventHandlerRegistration<object> nullEventHandler = null;
            var nullEventHandlerException = new NullEventHandlerRegistrationException();

            var expectedEventHandlerRegistrationValidationException =
                new EventHandlerRegistrationValidationException(nullEventHandlerException);

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
    }
}
