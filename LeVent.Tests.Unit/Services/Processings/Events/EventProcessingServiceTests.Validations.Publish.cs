// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

using System.Threading.Tasks;
using FluentAssertions;
using LeVent.Models.Processings.Events.Exceptions;
using Moq;
using Xunit;

namespace LeVent.Tests.Unit.Services.Foundations.Events
{
    public partial class EventProcessingServiceTests
    {
        [Fact]
        private async Task ShouldThrowValidationExceptionOnAddIfEventIsNullAsync()
        {
            // given
            object nullEvent = null;

            var nullEventProcessingException =
                new NullEventProcessingException(
                    message: "Event is null");

            var expectedEventProcessingValidationException =
                new EventProcessingValidationException(
                    message: "Event validation error occurred, please fix error and try again. ",
                    innerException: nullEventProcessingException);

            // when
            ValueTask publishEventTask = this.eventProcessingService
                .PublishEventAsync(nullEvent);

            EventProcessingValidationException actualEventProcessingValidationException =
                await Assert.ThrowsAsync<EventProcessingValidationException>(
                    publishEventTask.AsTask);

            // then
            actualEventProcessingValidationException.Should()
                .BeEquivalentTo(expectedEventProcessingValidationException);

            this.eventHandlerRegistrationServiceMock.Verify(broker =>
                broker.RetrieveAllEventHandlerRegistrations(),
                    Times.Never);

            this.eventHandlerRegistrationServiceMock.VerifyNoOtherCalls();
        }
    }
}
