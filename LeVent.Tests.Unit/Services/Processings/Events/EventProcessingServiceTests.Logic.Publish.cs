// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LeVent.Models.Foundations.EventHandlerRegistrations;
using Moq;
using Xunit;

namespace LeVent.Tests.Unit.Services.Foundations.Events
{
    public partial class EventProcessingServiceTests
    {
        [Fact]
        public async Task ShouldPublishEventWithoutEventNameAsync()
        {
            // given
            List<Mock<Func<object, ValueTask>>> randomEventHandlerMocks =
                CreateRandomEventHandlerMocks();

            List<EventHandlerRegistration<object>> randomEventHandlerRegistrations =
                CreateEventHandlerRegistrationsFromMocks(randomEventHandlerMocks);

            List<EventHandlerRegistration<object>> retrievedEventHandlerRegistrations =
                randomEventHandlerRegistrations;

            this.eventHandlerRegistrationServiceMock.Setup(broker =>
                broker.RetrieveAllEventHandlerRegistrations())
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
    }
}
