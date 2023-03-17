﻿// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using FluentAssertions;
using LeVent.Models.Foundations.EventHandlerRegistrations;
using LeVent.Models.Foundations.EventHandlerRegistrations.Exceptions;
using Moq;
using System;
using Xunit;

namespace LeVent.Tests.Unit.Services.Foundations.EventHandlerRegistrations
{
    public partial class EventHandlerRegistrationServiceTests
    {
        [Fact]
        public void ShouldThrowServiceExceptionOnAddIfServiceErrorOcurrs()
        {
            // given
            EventHandlerRegistration<object> someEventHandlerRegistration =
                CreateRandomEventHandlerRegistration();

            var serviceException = new Exception();

            var failedEventHandlerRegistrationServiceException =
                new FailedEventHandlerRegistrationServiceException(
                    serviceException);

            var expectedEventHandlerRegistrationServiceException =
                new EventHandlerRegistrationServiceException(
                    failedEventHandlerRegistrationServiceException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertEventHandlerRegistration(
                    It.IsAny<EventHandlerRegistration<object>>()))
                        .Throws(serviceException);

            // when
            Action addEventHandlerAction = () =>
                this.eventHandlerRegistrationService.AddEventHandlerRegistation(
                    someEventHandlerRegistration);

            EventHandlerRegistrationServiceException actualEventHandlerRegistrationServiceException =
                Assert.Throws<EventHandlerRegistrationServiceException>(addEventHandlerAction);

            // then
            actualEventHandlerRegistrationServiceException.Should()
                .BeEquivalentTo(expectedEventHandlerRegistrationServiceException);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertEventHandlerRegistration(
                    It.IsAny<EventHandlerRegistration<object>>()),
                        Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
