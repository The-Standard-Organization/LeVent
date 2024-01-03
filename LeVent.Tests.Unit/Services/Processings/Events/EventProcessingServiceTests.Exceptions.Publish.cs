// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

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
        private async Task ShouldThrowServiceExceptionOnPublishIfServiceErrorOccursAsync()
        {
            // given
            var someEvent = new object();
            var serviceException = new Exception();

            var failedEventProcessingServiceException =
                new FailedEventProcessingServiceException(
                    message: "Failed event service error ocurred, contact support.",
                    innerException: serviceException);

            var expectedEventServiceException =
                new EventProcessingServiceException(
                    message: "Event service error occurred, contact support.",
                    innerException: failedEventProcessingServiceException);

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
