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
        private void ShouldThrowServiceExceptionOnAddIfServiceErrorOcurrs()
        {
            // given
            EventHandlerRegistration<object> someEventHandlerRegistration =
                CreateRandomEventHandlerRegistration();

            var serviceException = new Exception();

            var failedEventHandlerRegistrationServiceException =
                new FailedEventHandlerRegistrationServiceException(
                    message: "Failed event handler registration service error occurred, contact support.",
                    innerException: serviceException);

            var expectedEventHandlerRegistrationServiceException =
                new EventHandlerRegistrationServiceException(
                    message: "Event service error occurred, contact support.",
                    innerException: failedEventHandlerRegistrationServiceException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertEventHandlerRegistration(
                    It.IsAny<EventHandlerRegistration<object>>()))
                        .Throws(serviceException);

            // when
            Action addEventHandlerAction = () =>
                this.eventHandlerRegistrationService.AddEventHandlerRegistation(
                    someEventHandlerRegistration);

            EventHandlerRegistrationServiceException actualEventHandlerRegistrationServiceException =
                Assert.Throws<EventHandlerRegistrationServiceException>(addEventHandlerAction);

            // then
            actualEventHandlerRegistrationServiceException.Should()
                .BeEquivalentTo(expectedEventHandlerRegistrationServiceException);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertEventHandlerRegistration(
                    It.IsAny<EventHandlerRegistration<object>>()),
                        Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
