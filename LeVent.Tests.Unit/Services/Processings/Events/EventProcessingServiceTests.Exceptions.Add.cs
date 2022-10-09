// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Threading.Tasks;
using FluentAssertions;
using LeVent.Models.Foundations.EventHandlerRegistrations;
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

            this.eventHandlerRegistrationServiceMock.Setup(service =>
                service.AddEventHandlerRegistation(
                    It.IsAny<EventHandlerRegistration<object>>()))
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

            this.eventHandlerRegistrationServiceMock.Verify(service =>
                service.AddEventHandlerRegistation(
                    It.IsAny<EventHandlerRegistration<object>>()),
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

            this.eventHandlerRegistrationServiceMock.Setup(service =>
                service.AddEventHandlerRegistation(
                    It.IsAny<EventHandlerRegistration<object>>()))
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

            this.eventHandlerRegistrationServiceMock.Verify(service =>
                service.AddEventHandlerRegistation(
                    It.IsAny<EventHandlerRegistration<object>>()),
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

            this.eventHandlerRegistrationServiceMock.Setup(service =>
                service.AddEventHandlerRegistation(
                    It.IsAny<EventHandlerRegistration<object>>()))
                        .Throws(serviceException);

            // when
            Action addEventHandlerAction = () =>
                this.eventProcessingService.AddEventHandler(someEventHandler);

            EventProcessingServiceException actualEventProcessingServiceException =
                Assert.Throws<EventProcessingServiceException>(addEventHandlerAction);

            // then
            actualEventProcessingServiceException.Should()
                .BeEquivalentTo(expectedEventServiceException);

            this.eventHandlerRegistrationServiceMock.Verify(service =>
                service.AddEventHandlerRegistation(
                    It.IsAny<EventHandlerRegistration<object>>()),
                        Times.Once);

            this.eventServiceMock.VerifyNoOtherCalls();
        }
    }
}
