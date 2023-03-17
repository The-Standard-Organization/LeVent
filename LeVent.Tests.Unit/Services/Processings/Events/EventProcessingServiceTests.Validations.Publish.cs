// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using FluentAssertions;
using LeVent.Models.Processings.Events.Exceptions;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace LeVent.Tests.Unit.Services.Foundations.Events
{
    public partial class EventProcessingServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfEventIsNullAsync()
        {
            // given
            object nullEvent = null;

            var nullEventProcessingException =
                new NullEventProcessingException();

            var expectedEventProcessingValidationException =
                new EventProcessingValidationException(
                    nullEventProcessingException);

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
