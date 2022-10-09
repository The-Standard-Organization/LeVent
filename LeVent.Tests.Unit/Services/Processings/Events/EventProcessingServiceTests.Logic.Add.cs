// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Threading.Tasks;
using LeVent.Models.Foundations.EventHandlerRegistrations;
using Moq;
using Xunit;

namespace LeVent.Tests.Unit.Services.Foundations.Events
{
    public partial class EventProcessingServiceTests
    {
        [Fact]
        public void ShouldRegisterEventHandlerWithoutEventName()
        {
            // given
            var eventHandlerMock =
                new Mock<Func<object, ValueTask>>();

            Func<object, ValueTask> inputEventHandler =
                eventHandlerMock.Object;

            var expectedInputEventHandlerRegistration =
                new EventHandlerRegistration<object>
                {
                    EventHandler = inputEventHandler
                };

            // when
            this.eventProcessingService.AddEventHandler(inputEventHandler);

            // then
            this.eventHandlerRegistrationServiceMock.Verify(service =>
                service.AddEventHandlerRegistation(
                    It.Is(SameEventHandlerRegistrationAs(
                        expectedInputEventHandlerRegistration))),
                            Times.Once);

            this.eventServiceMock.VerifyNoOtherCalls();
        }
    }
}
