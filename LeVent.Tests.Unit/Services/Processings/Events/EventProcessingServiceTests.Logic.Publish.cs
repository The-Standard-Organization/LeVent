// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace LeVent.Tests.Unit.Services.Foundations.Events
{
    public partial class EventProcessingServiceTests
    {
        [Fact]
        public async Task ShouldPublishEventAsync()
        {
            // given
            List<Mock<Func<object, ValueTask>>> randomEventHandlerMocks =
                CreateRandomEventHandlerMocks();

            List<Func<object, ValueTask>> retrievedEventHandlers =
                randomEventHandlerMocks.Select(handlerMock =>
                    handlerMock.Object)
                        .ToList();

            this.eventServiceMock.Setup(broker =>
                broker.RetrieveAllEventHandlers())
                    .Returns(retrievedEventHandlers);

            var randomEvent = new object();
            object inputEvent = randomEvent;

            // when
            await this.eventProcessingService.PublishEventAsync(inputEvent);

            // then
            randomEventHandlerMocks.ForEach(eventHandlerMock =>
                eventHandlerMock.Verify(eventHandler =>
                    eventHandler(inputEvent),
                        Times.Once));

            this.eventServiceMock.Verify(service =>
                service.RetrieveAllEventHandlers(),
                    Times.Once);

            this.eventServiceMock.VerifyNoOtherCalls();
        }
    }
}
