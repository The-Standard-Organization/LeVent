// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------


using System;
using System.Threading.Tasks;
using FluentAssertions;
using LeVent.Models.Foundations.EventHandlerRegistrations;
using LeVent.Models.Processings.Events.Exceptions;
using Moq;
using Xunit;

namespace LeVent.Tests.Unit.Services.Foundations.Events
{
    public partial class EventProcessingServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnAddIfEventHandlerIsNull()
        {
            // given
            Func<object, ValueTask> nullEventHandler = null;

            var nullEventHandlerProcessingException =
                new NullEventHandlerProcessingException();

            var expectedEventProcessingValidationException =
                new EventProcessingValidationException(
                    nullEventHandlerProcessingException);

            // when
            Action addEventHandlerAction = () =>
                this.eventProcessingService.AddEventHandler(nullEventHandler);

            EventProcessingValidationException actualEventProcessingValidationException =
                Assert.Throws<EventProcessingValidationException>(addEventHandlerAction);

            // then
            actualEventProcessingValidationException.Should()
                .BeEquivalentTo(expectedEventProcessingValidationException);

            this.eventHandlerRegistrationServiceMock.Verify(service =>
                service.AddEventHandlerRegistation(
                    It.IsAny<EventHandlerRegistration<object>>()),
                        Times.Never);

            this.eventHandlerRegistrationServiceMock.VerifyNoOtherCalls();
        }
    }
}
