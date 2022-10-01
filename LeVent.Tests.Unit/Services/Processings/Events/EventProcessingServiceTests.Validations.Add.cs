// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
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

            this.eventServiceMock.Verify(broker =>
                broker.AddEventHandler(It.IsAny<Func<object, ValueTask>>()),
                    Times.Never);

            this.eventServiceMock.VerifyNoOtherCalls();
        }
    }
}
