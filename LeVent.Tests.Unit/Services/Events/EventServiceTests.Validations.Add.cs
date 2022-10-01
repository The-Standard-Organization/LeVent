// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Threading.Tasks;
using FluentAssertions;
using LeVent.Models.Foundations.Events.Exceptions;
using Moq;
using Xunit;

namespace LeVent.Tests.Unit.Services.Events
{
    public partial class EventServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnAddIfEventHandlerIsNull()
        {
            // given
            Func<object, ValueTask> nullEventHandler = null;
            var nullEventHandlerException = new NullEventHandlerException();

            var expectedEventValidationException =
                new EventValidationException(nullEventHandlerException);

            // when
            Action addEventHandlerAction = () =>
                this.eventService.AddEventHandler(nullEventHandler);

            EventValidationException actualEventValidationException =
                Assert.Throws<EventValidationException>(addEventHandlerAction);

            // then
            actualEventValidationException.Should()
                .BeEquivalentTo(expectedEventValidationException);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertEventHandler(It.IsAny<Func<object, ValueTask>>()),
                    Times.Never);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
