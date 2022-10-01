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
        public void ShouldThrowServiceExceptionOnAddIfServiceErrorOcurrs()
        {
            // given
            var eventHandlerMock =
                new Mock<Func<object, ValueTask>>();

            Func<object, ValueTask> someEventHandler =
                eventHandlerMock.Object;

            var storageException = new Exception();

            var failedEventServiceException =
                new FailedEventServiceException(
                    storageException);

            var expectedEventServiceException =
                new EventServiceException(
                    failedEventServiceException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertEventHandler(It.IsAny<Func<object, ValueTask>>()))
                    .Throws(storageException);

            // when
            Action addEventHandlerAction = () =>
                this.eventService.AddEventHandler(someEventHandler);

            EventServiceException actualEventServiceException =
                Assert.Throws<EventServiceException>(addEventHandlerAction);

            // then
            actualEventServiceException.Should()
                .BeEquivalentTo(expectedEventServiceException);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertEventHandler(
                    It.IsAny<Func<object, ValueTask>>()),
                        Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
