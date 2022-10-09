// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using FluentAssertions;
using LeVent.Models.Foundations.EventHandlerRegistrations.Exceptions;
using Moq;
using Xunit;

namespace LeVent.Tests.Unit.Services.Foundations.EventHandlerRegistrations
{
    public partial class EventHandlerRegistrationServiceTests
    {
        [Fact]
        public void ShouldThrowServiceExceptionOnRetrieveAllIfServiceErrorOcurrs()
        {
            // given
            var serviceException = new Exception();

            var failedEventHandlerRegistrationServiceException =
                new FailedEventHandlerRegistrationServiceException(
                    serviceException);

            var expectedEventHandlerRegistrationServiceException =
                new EventHandlerRegistrationServiceException(
                    failedEventHandlerRegistrationServiceException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllEventHandlerRegistrations())
                    .Throws(serviceException);

            // when
            Action retrieveAllEventHandlerRegistrationsAction = () =>
                this.eventHandlerRegistrationService
                    .RetrieveAllEventHandlerRegistrations();

            EventHandlerRegistrationServiceException
                actualEventHandlerRegistrationServiceException =
                    Assert.Throws<EventHandlerRegistrationServiceException>(
                        retrieveAllEventHandlerRegistrationsAction);

            // then
            actualEventHandlerRegistrationServiceException.Should()
                .BeEquivalentTo(expectedEventHandlerRegistrationServiceException);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllEventHandlerRegistrations(),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
