// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using LeVent.Brokers.Storages;
using LeVent.Services.Events;
using Moq;

namespace LeVent.Tests.Unit.Services.Events
{
    public partial class EventServiceTests
    {
        private readonly Mock<IStorageBroker<object>> storageBrokerMock;
        private readonly IEventService<object> eventService;

        public EventServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker<object>>();

            this.eventService = new EventService<object>(
                storageBroker: this.storageBrokerMock.Object);
        }
    }
}
