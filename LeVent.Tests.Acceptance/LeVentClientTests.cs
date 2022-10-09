// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using LeVent.Clients;
using Xunit;

namespace LeVent.Tests.Acceptance
{
    public class DeleteMe
    {
        private static List<string> eventResults =
            new List<string>();

        [Fact]
        public async Task ShouldRegisterPublishEventsAsync()
        {
            // given
            string myEvent = "nothing";
            var leVentClient = new LeVentClient<string>();

            // when
            leVentClient.RegisterEventHandler(DoSomethingWithEvent);
            leVentClient.RegisterEventHandler(DoSomethingElseWithEventAsync);
            await leVentClient.PublishEventAsync(myEvent);

            // then
            eventResults.Count.Should().Be(2);
            eventResults.Should().Contain($"{myEvent} arrived @ First Handler");
            eventResults.Should().Contain($"{myEvent} arrived @ Second Handler");
        }

        private ValueTask DoSomethingWithEvent(string @event)
        {
            eventResults.Add($"{@event} arrived @ First Handler");

            return ValueTask.CompletedTask;
        }

        private ValueTask DoSomethingElseWithEventAsync(string @event)
        {
            eventResults.Add($"{@event} arrived @ Second Handler");

            return ValueTask.CompletedTask;
        }
    }
}