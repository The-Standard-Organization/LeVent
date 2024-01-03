// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeVent.Brokers.Storages;
using LeVent.Models.Foundations.EventHandlerRegistrations;
using LeVent.Services.Foundations.EventRegistrations;
using Moq;
using Tynamix.ObjectFiller;

namespace LeVent.Tests.Unit.Services.Foundations.EventHandlerRegistrations
{
    public partial class EventHandlerRegistrationServiceTests
    {
        private readonly Mock<IStorageBroker<object>> storageBrokerMock;
        private readonly IEventHandlerRegistrationService<object> eventHandlerRegistrationService;

        public EventHandlerRegistrationServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker<object>>();

            this.eventHandlerRegistrationService = new EventHandlerRegistrationService<object>(
                storageBroker: this.storageBrokerMock.Object);
        }

        private static List<EventHandlerRegistration<object>> CreateRandomEventHandlerRegistrations() =>
            CreateEventHandlerRegistrationFiller().Create(count: GetRandomNumber()).ToList();

        private static EventHandlerRegistration<object> CreateRandomEventHandlerRegistration() =>
            CreateEventHandlerRegistrationFiller().Create();

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static Filler<EventHandlerRegistration<object>> CreateEventHandlerRegistrationFiller()
        {
            var filler = new Filler<EventHandlerRegistration<object>>();

            filler.Setup()
                .OnProperty(registrationHandler => registrationHandler.EventHandler)
                    .Use(new Mock<Func<object, ValueTask>>().Object);

            return filler;
        }
    }
}
