// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using LeVent.Clients;
using Xunit;

namespace LeVent.Tests.Acceptance
{
    public class LeVentClientTests
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
            eventResults = new List<string>();
        }

        [Fact]
        private async Task ShouldRegisterPublishForSpecificEventNameAsync()
        {
            // given
            string eventName = "event name";
            string myEvent = "nothing";
            var leVentClient = new LeVentClient<string>();

            // when
            leVentClient.RegisterEventHandler(
                eventHandler: DoSomethingWithEvent,
                eventName);

            leVentClient.RegisterEventHandler(
                eventHandler: DoSomethingElseWithEventAsync,
                eventName);

            await leVentClient.PublishEventAsync(myEvent, eventName);

            // then
            eventResults.Count.Should().Be(2);
            eventResults.Should().Contain($"{myEvent} arrived @ First Handler");
            eventResults.Should().Contain($"{myEvent} arrived @ Second Handler");
            eventResults = new List<string>();
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