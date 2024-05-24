// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeVent.Models.Foundations.EventHandlerRegistrations;
using Moq;
using Xunit;

namespace LeVent.Tests.Unit.Services.Foundations.Events
{
    public partial class EventProcessingServiceTests
    {
        [Fact]
        private async Task ShouldPublishEventWithoutEventNameAsync()
        {
            // given
            List<Mock<Func<object, ValueTask>>> randomEventHandlerMocks =
                CreateRandomEventHandlerMocks();

            List<EventHandlerRegistration<object>> randomEventHandlerRegistrations =
                CreateEventHandlerRegistrationsFromMocks(randomEventHandlerMocks);

            List<EventHandlerRegistration<object>> retrievedEventHandlerRegistrations =
                randomEventHandlerRegistrations;

            this.eventHandlerRegistrationServiceMock.Setup(service =>
                service.RetrieveAllEventHandlerRegistrations())
                    .Returns(retrievedEventHandlerRegistrations);

            var randomEvent = new object();
            object inputEvent = randomEvent;

            // when
            await this.eventProcessingService.PublishEventAsync(inputEvent);

            // then
            randomEventHandlerMocks.ForEach(eventHandlerMock =>
                eventHandlerMock.Verify(eventHandler =>
                    eventHandler(inputEvent),
                        Times.Once));

            this.eventHandlerRegistrationServiceMock.Verify(service =>
                service.RetrieveAllEventHandlerRegistrations(),
                    Times.Once);

            this.eventHandlerRegistrationServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        private async Task ShouldPublishEventWithEventNameAsync()
        {
            // given
            string randomEventName = GetRandomEventName();
            string inputEventName = randomEventName;

            List<Mock<Func<object, ValueTask>>> randomCalledEventHandlerMocks =
                CreateRandomEventHandlerMocks();

            List<Mock<Func<object, ValueTask>>> randomNonCalledEventHandlerMocks =
                CreateRandomEventHandlerMocks();

            List<EventHandlerRegistration<object>> randomTargetEventHandlerRegistrations =
                CreateEventHandlerRegistrationsFromMocks(
                    randomCalledEventHandlerMocks,
                    inputEventName);

            List<EventHandlerRegistration<object>> randomNonTargetEventHandlerRegistrations =
                CreateEventHandlerRegistrationsFromMocks(
                    randomNonCalledEventHandlerMocks);

            List<EventHandlerRegistration<object>> retrievedTargetEventHandlerRegistrations =
                randomTargetEventHandlerRegistrations;

            List<EventHandlerRegistration<object>> retrievedNonTargetEventHandlerRegistrations =
                randomNonTargetEventHandlerRegistrations;

            List<EventHandlerRegistration<object>> retrievedAllEventHandlerRegistrations =
                retrievedTargetEventHandlerRegistrations.Concat(
                    retrievedNonTargetEventHandlerRegistrations)
                        .ToList();

            this.eventHandlerRegistrationServiceMock.Setup(service =>
                service.RetrieveAllEventHandlerRegistrations())
                    .Returns(retrievedAllEventHandlerRegistrations);

            var randomEvent = new object();
            object inputEvent = randomEvent;

            // when
            await this.eventProcessingService.PublishEventAsync(
                inputEvent,
                inputEventName);

            // then
            randomCalledEventHandlerMocks.ForEach(eventHandlerMock =>
                eventHandlerMock.Verify(eventHandler =>
                    eventHandler(inputEvent),
                        Times.Once));

            randomNonCalledEventHandlerMocks.ForEach(eventHandlerMock =>
                eventHandlerMock.Verify(eventHandler =>
                    eventHandler(inputEvent),
                        Times.Never));

            this.eventHandlerRegistrationServiceMock.Verify(service =>
                service.RetrieveAllEventHandlerRegistrations(),
                    Times.Once);

            this.eventHandlerRegistrationServiceMock.VerifyNoOtherCalls();
        }
    }
}
