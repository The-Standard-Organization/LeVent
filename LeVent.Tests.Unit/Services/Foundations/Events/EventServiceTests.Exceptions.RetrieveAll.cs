// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using FluentAssertions;
using LeVent.Models.Foundations.Events.Exceptions;
using Moq;
using Xunit;

namespace LeVent.Tests.Unit.Services.Foundations.Events
{
    public partial class EventServiceTests
    {
        [Fact]
        public void ShouldThrowServiceExceptionOnRetrieveAllIfServiceErrorOcurrs()
        {
            // given
            var serviceException = new Exception();

            var failedEventServiceException =
                new FailedEventServiceException(
                    serviceException);

            var expectedEventServiceException =
                new EventServiceException(
                    failedEventServiceException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllEventHandlers())
                    .Throws(serviceException);

            // when
            Action retrieveAllEventHandlersAction = () =>
                this.eventService.RetrieveAllEventHandlers();

            EventServiceException actualEventServiceException =
                Assert.Throws<EventServiceException>(retrieveAllEventHandlersAction);

            // then
            actualEventServiceException.Should()
                .BeEquivalentTo(expectedEventServiceException);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllEventHandlers(),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
