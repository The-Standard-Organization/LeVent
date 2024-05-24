// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

using System.Collections.Generic;
using FluentAssertions;
using LeVent.Models.Foundations.EventHandlerRegistrations;
using Moq;
using Xunit;

namespace LeVent.Tests.Unit.Services.Foundations.EventHandlerRegistrations
{
    public partial class EventHandlerRegistrationServiceTests
    {
        [Fact]
        private void ShouldRetrieveAllEventHandlerRegistrations()
        {
            // given
            List<EventHandlerRegistration<object>> randomEventHandlerRegistrations =
                CreateRandomEventHandlerRegistrations();

            List<EventHandlerRegistration<object>> storageEventHandlerRegistrations =
                randomEventHandlerRegistrations;

            List<EventHandlerRegistration<object>> expectedEventHandlerRegistrations =
                storageEventHandlerRegistrations;

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllEventHandlerRegistrations())
                    .Returns(storageEventHandlerRegistrations);

            // when
            List<EventHandlerRegistration<object>> actualEventHandlerRegistrations =
                this.eventHandlerRegistrationService.RetrieveAllEventHandlerRegistrations();

            // then
            actualEventHandlerRegistrations.Should().BeEquivalentTo(
                expectedEventHandlerRegistrations);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllEventHandlerRegistrations(),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
