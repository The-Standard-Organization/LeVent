// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Threading.Tasks;
using FluentAssertions;
using LeVent.Models.Foundations.Events.Exceptions;
using Moq;
using Xunit;

namespace LeVent.Tests.Unit.Services.Foundations.Events
{
    public partial class EventProcessingServiceTests
    {
        [Fact]
        public async Task ShouldThrowServiceExceptionOnPublishIfServiceErrorOccursAsync()
        {
            // given
            var someEvent = new object();
            var serviceException = new Exception();

            var failedEventProcessingServiceException =
                new FailedEventProcessingServiceException(
                    serviceException);

            var expectedEventServiceException =
                new EventProcessingServiceException(
                    failedEventProcessingServiceException);

            this.eventHandlerRegistrationServiceMock.Setup(service =>
                service.RetrieveAllEventHandlerRegistrations())
                    .Throws(serviceException);

            // when
            ValueTask publishEventTask = this.eventProcessingService
                .PublishEventAsync(someEvent);

            EventProcessingServiceException actualEventProcessingServiceException =
                await Assert.ThrowsAsync<EventProcessingServiceException>(
                    publishEventTask.AsTask);

            // then
            actualEventProcessingServiceException.Should()
                .BeEquivalentTo(expectedEventServiceException);

            this.eventHandlerRegistrationServiceMock.Verify(service =>
                service.RetrieveAllEventHandlerRegistrations(),
                    Times.Once);

            this.eventHandlerRegistrationServiceMock.VerifyNoOtherCalls();
        }
    }
}
