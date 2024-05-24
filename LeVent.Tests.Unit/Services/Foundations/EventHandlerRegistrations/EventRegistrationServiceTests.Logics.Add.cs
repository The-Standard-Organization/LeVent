// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

using LeVent.Models.Foundations.EventHandlerRegistrations;
using Moq;
using Xunit;

namespace LeVent.Tests.Unit.Services.Foundations.EventHandlerRegistrations
{
    public partial class EventHandlerRegistrationServiceTests
    {
        [Fact]
        private void ShouldAddEventHandlerRegistration()
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
                broker.InsertEventHandlerRegistration(
                    inputEventHandlerRegistration),
                        Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
