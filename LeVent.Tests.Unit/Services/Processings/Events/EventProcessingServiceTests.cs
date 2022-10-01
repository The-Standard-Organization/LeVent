// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeVent.Models.Foundations.Events.Exceptions;
using LeVent.Services.Foundations.Events;
using LeVent.Services.Processings.Events;
using Moq;
using Tynamix.ObjectFiller;
using Xeptions;
using Xunit;

namespace LeVent.Tests.Unit.Services.Foundations.Events
{
    public partial class EventProcessingServiceTests
    {
        private readonly Mock<IEventService<object>> eventServiceMock;
        private readonly IEventProcessingService<object> eventProcessingService;

        public EventProcessingServiceTests()
        {
            this.eventServiceMock = new Mock<IEventService<object>>();

            this.eventProcessingService = new EventProcessingService<object>(
                eventService: this.eventServiceMock.Object);
        }

        public static TheoryData DependencyValidationExceptions()
        {
            var nullEventHandlerException =
                new NullEventHandlerException();

            return new TheoryData<Exception>
            {
                new EventValidationException(nullEventHandlerException)
            };
        }

        public static TheoryData DependencyExceptions()
        {
            var someInnerException =
                new Xeption();

            return new TheoryData<Exception>
            {
                new EventDependencyException(someInnerException),
                new EventServiceException(someInnerException)
            };
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
