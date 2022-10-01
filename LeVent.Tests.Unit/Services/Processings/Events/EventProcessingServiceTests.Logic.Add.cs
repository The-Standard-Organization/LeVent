// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace LeVent.Tests.Unit.Services.Foundations.Events
{
    public partial class EventProcessingServiceTests
    {
        [Fact]
        public void ShouldAddEventHandler()
        {
            // given
            var eventHandlerMock =
                new Mock<Func<object, ValueTask>>();

            Func<object, ValueTask> inputEventHandler =
                eventHandlerMock.Object;

            // when
            this.eventProcessingService.AddEventHandler(inputEventHandler);

            // then
            this.eventServiceMock.Verify(broker =>
                broker.AddEventHandler(inputEventHandler),
                    Times.Once);

            this.eventServiceMock.VerifyNoOtherCalls();
        }
    }
}
