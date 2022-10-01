// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Threading.Tasks;
using FluentAssertions;
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

            var storageException = new Exception();

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
    }
}
