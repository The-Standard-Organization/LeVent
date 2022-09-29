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
        public void ShouldThrowDependencyExceptionOnAddIfDependencyErrorOcurrs()
        {
            // given
            var eventHandlerMock =
                new Mock<Func<object, ValueTask>>();

            Func<object, ValueTask> someEventHandler =
                eventHandlerMock.Object;

            var storageException = new Exception();

            var failedEventStorageException = 
                new FailedEventStorageException(
                    storageException);

            var expectedEventDependencyException =
                new EventDependencyException(
                    failedEventStorageException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertEventHandler(It.IsAny<Func<object, ValueTask>>()))
                    .Throws(storageException);

            // when
            Action addEventHandlerAction = () =>
                this.eventService.AddEventHandler(someEventHandler);

            EventDependencyException actualEventDependencyException =
                Assert.Throws<EventDependencyException>(addEventHandlerAction);

            // then
            actualEventDependencyException.Should()
                .BeEquivalentTo(expectedEventDependencyException);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertEventHandler(It.IsAny<Func<object, ValueTask>>()),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
