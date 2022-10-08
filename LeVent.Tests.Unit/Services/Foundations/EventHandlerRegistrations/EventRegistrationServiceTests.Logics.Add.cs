// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using LeVent.Models.Foundations.Events;
using Moq;
using Xunit;

namespace LeVent.Tests.Unit.Services.Foundations.EventHandlerRegistrations
{
    public partial class EventHandlerRegistrationServiceTests
    {
        [Fact]
        public void ShouldAddEventHandlerRegistration()
        {
            // given
            EventHandlerRegistration<object> randomEventHandlerRegistration =
                CreateRandomEventHandlerRegistration();

            EventHandlerRegistration<object> inputEventHandlerRegistration =
                randomEventHandlerRegistration;

            // when
            this.eventHandlerRegistrationService.AddEventHandlerRegistation(
                inputEventHandlerRegistration);

            // then
            this.storageBrokerMock.Verify(broker =>
                broker.InsertEventHandlerRegistration(inputEventHandlerRegistration),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
