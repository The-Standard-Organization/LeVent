// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeVent.Brokers.Storages;
using LeVent.Services.Foundations.Events;
using Moq;
using Tynamix.ObjectFiller;

namespace LeVent.Tests.Unit.Services.Foundations.Events
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

        private static List<Func<object, ValueTask>> CreateRandomEventHandlers()
        {
            int randomCount = GetRandomNumber();

            return Enumerable.Range(start: 0, count: randomCount)
                .Select(_ => new Mock<Func<object, ValueTask>>().Object)
                    .ToList();
        }

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();
    }
}
