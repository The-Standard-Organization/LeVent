// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

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
        private void ShouldRegisterEventHandlerWithoutEventName()
        {
            // given
            var eventHandlerMock =
                new Mock<Func<object, ValueTask>>();

            Func<object, ValueTask> inputEventHandler =
                eventHandlerMock.Object;

            var expectedInputEventHandlerRegistration =
                new EventHandlerRegistration<object>
                {
                    EventHandler = inputEventHandler,
                    EventName = null
                };

            // when
            this.eventProcessingService.AddEventHandler(inputEventHandler);

            // then
            this.eventHandlerRegistrationServiceMock.Verify(service =>
                service.AddEventHandlerRegistation(
                    It.Is(SameEventHandlerRegistrationAs(
                        expectedInputEventHandlerRegistration))),
                            Times.Once);

            this.eventHandlerRegistrationServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        private void ShouldRegisterEventHandlerWithEventName()
        {
            // given
            var eventHandlerMock =
                new Mock<Func<object, ValueTask>>();

            Func<object, ValueTask> inputEventHandler =
                eventHandlerMock.Object;

            string randomEventName = GetRandomEventName();
            string inputEventName = randomEventName;

            var expectedInputEventHandlerRegistration =
                new EventHandlerRegistration<object>
                {
                    EventHandler = inputEventHandler,
                    EventName = inputEventName
                };

            // when
            this.eventProcessingService.AddEventHandler(
                inputEventHandler,
                inputEventName);

            // then
            this.eventHandlerRegistrationServiceMock.Verify(service =>
                service.AddEventHandlerRegistation(
                    It.Is(SameEventHandlerRegistrationAs(
                        expectedInputEventHandlerRegistration))),
                            Times.Once);

            this.eventHandlerRegistrationServiceMock.VerifyNoOtherCalls();
        }
    }
}
