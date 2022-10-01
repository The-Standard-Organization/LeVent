// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Threading.Tasks;
using FluentAssertions;
using LeVent.Models.Foundations.Events.Exceptions;
using LeVent.Models.Processings.Events.Exceptions;
using Moq;
using Xeptions;
using Xunit;

namespace LeVent.Tests.Unit.Services.Foundations.Events
{
    public partial class EventProcessingServiceTests
    {
        [Theory]
        [MemberData(nameof(DependencyValidationExceptions))]
        public void ShouldThrowDependencyValidationExceptionOnAddIfDependencyValidationErrorOccurs(
            Xeption dependencyValidationException)
        {
            // given
            var eventHandlerMock =
                new Mock<Func<object, ValueTask>>();

            Func<object, ValueTask> someEventHandler =
                eventHandlerMock.Object;

            var expectedEventProcessingDependencyValidationException =
                new EventProcessingDependencyValidationException(
                    dependencyValidationException.InnerException as Xeption);

            this.eventServiceMock.Setup(service =>
                service.AddEventHandler(It.IsAny<Func<object, ValueTask>>()))
                    .Throws(dependencyValidationException);

            // when
            Action addEventHandlerAction = () =>
                this.eventProcessingService.AddEventHandler(someEventHandler);

            EventProcessingDependencyValidationException
                actualEventProcessingDependencyValidationException =
                    Assert.Throws<EventProcessingDependencyValidationException>(
                        addEventHandlerAction);

            // then
            actualEventProcessingDependencyValidationException.Should()
                .BeEquivalentTo(expectedEventProcessingDependencyValidationException);

            this.eventServiceMock.Verify(service =>
                service.AddEventHandler(
                    It.IsAny<Func<object, ValueTask>>()),
                        Times.Once);

            this.eventServiceMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(DependencyExceptions))]
        public void ShouldThrowDependencyExceptionOnAddIfDependencyErrorOccurs(
            Xeption dependencyException)
        {
            // given
            var eventHandlerMock =
                new Mock<Func<object, ValueTask>>();

            Func<object, ValueTask> someEventHandler =
                eventHandlerMock.Object;

            var expectedEventProcessingDependencyException =
                new EventProcessingDependencyException(
                    dependencyException.InnerException as Xeption);

            this.eventServiceMock.Setup(service =>
                service.AddEventHandler(It.IsAny<Func<object, ValueTask>>()))
                    .Throws(dependencyException);

            // when
            Action addEventHandlerAction = () =>
                this.eventProcessingService.AddEventHandler(someEventHandler);

            EventProcessingDependencyException
                actualEventProcessingDependencyException =
                    Assert.Throws<EventProcessingDependencyException>(
                        addEventHandlerAction);

            // then
            actualEventProcessingDependencyException.Should()
                .BeEquivalentTo(expectedEventProcessingDependencyException);

            this.eventServiceMock.Verify(service =>
                service.AddEventHandler(
                    It.IsAny<Func<object, ValueTask>>()),
                        Times.Once);

            this.eventServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowServiceExceptionOnAddIfServiceErrorOcurrs()
        {
            // given
            var eventHandlerMock =
                new Mock<Func<object, ValueTask>>();

            Func<object, ValueTask> someEventHandler =
                eventHandlerMock.Object;

            var serviceException = new Exception();

            var failedEventProcessingServiceException =
                new FailedEventProcessingServiceException(
                    serviceException);

            var expectedEventServiceException =
                new EventProcessingServiceException(
                    failedEventProcessingServiceException);

            this.eventServiceMock.Setup(service =>
                service.AddEventHandler(It.IsAny<Func<object, ValueTask>>()))
                    .Throws(serviceException);

            // when
            Action addEventHandlerAction = () =>
                this.eventProcessingService.AddEventHandler(someEventHandler);

            EventProcessingServiceException actualEventProcessingServiceException =
                Assert.Throws<EventProcessingServiceException>(addEventHandlerAction);

            // then
            actualEventProcessingServiceException.Should()
                .BeEquivalentTo(expectedEventServiceException);

            this.eventServiceMock.Verify(service =>
                service.AddEventHandler(
                    It.IsAny<Func<object, ValueTask>>()),
                        Times.Once);

            this.eventServiceMock.VerifyNoOtherCalls();
        }
    }
}
