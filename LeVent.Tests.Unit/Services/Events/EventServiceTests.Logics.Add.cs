// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace LeVent.Tests.Unit.Services.Events
{
    public partial class EventServiceTests
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
            this.eventService.AddEventHandler(inputEventHandler);

            // then
            this.storageBrokerMock.Verify(broker =>
                broker.InsertEventHandler(inputEventHandler),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
