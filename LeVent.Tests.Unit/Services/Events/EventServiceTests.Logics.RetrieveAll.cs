// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Xunit;

namespace LeVent.Tests.Unit.Services.Events
{
    public partial class EventServiceTests
    {
        [Fact]
        public void ShouldRetrieveAllEventHandlers()
        {
            // given
            List<Func<object, ValueTask>> randomEventHandlers =
                CreateRandomEventHandlers();

            List<Func<object, ValueTask>> storageEventHandlers =
                randomEventHandlers;//

            List<Func<object, ValueTask>> expectedEventHandlers =
                storageEventHandlers.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllEventHandlers())
                    .Returns(storageEventHandlers);

            // when
            List<Func<object, ValueTask>> actualEventHandlers =
                this.eventService.RetrieveAllEventHandlers();

            // then
            actualEventHandlers.Should().BeEquivalentTo(expectedEventHandlers);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllEventHandlers(),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
