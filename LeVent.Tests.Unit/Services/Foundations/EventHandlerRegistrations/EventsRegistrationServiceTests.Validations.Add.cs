// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using FluentAssertions;
using LeVent.Models.Foundations.Events;
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
            var nullEventHandlerException = new NullEventHandlerException();

            var expectedEventValidationException =
                new EventValidationException(nullEventHandlerException);

            // when
            Action addEventHandlerRegistrationAction = () =>
                this.eventHandlerRegistrationService.AddEventHandlerRegistation(
                    nullEventHandler);

            EventValidationException actualEventValidationException =
                Assert.Throws<EventValidationException>(
                    addEventHandlerRegistrationAction);

            // then
            actualEventValidationException.Should()
                .BeEquivalentTo(expectedEventValidationException);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertEventHandlerRegistration(
                    It.IsAny<EventHandlerRegistration<object>>()),
                        Times.Never);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
