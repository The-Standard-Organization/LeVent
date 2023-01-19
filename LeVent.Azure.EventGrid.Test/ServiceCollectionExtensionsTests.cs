using Azure.Messaging.EventGrid;
using LeVent.Azure.EventGrid.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Threading.Tasks;

namespace LeVent.Azure.EventGrid.Test
{
    public class ServiceCollectionExtensionsTests
    {
        [Fact]
        public async Task ShouldFireEvent()
        {
            // Set up mock method to verify event handler call
            Mock<Action<EventGridEvent>> eventTriggerMock = new();
            Action<EventGridEvent> eventTrigger = eventTriggerMock.Object;

            EventGridEvent expectedEventGridEvent =
                new("TestSubject", "TestEventType", "TestDataVersion", null);

            ValueTask GenericEventHanlder(EventGridEvent eventGridEvent)
            {
                eventTrigger(eventGridEvent);

                return new ValueTask();
            }

            IServiceCollection serviceCollection = new ServiceCollection();

            // Register LeVent Azure Event Grid Services
            // This will be set in Program.cs dependency injection by consumer
            serviceCollection.UseAzureEventGrid(builder =>
            {
                builder.AddEventGridEvent(
                    name: expectedEventGridEvent.Subject,
                    eventHandler: GenericEventHanlder);
            });

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            IEventGridProcessingService eventGridProcessingService =
                serviceProvider.GetRequiredService<IEventGridProcessingService>();

            await eventGridProcessingService.PublishEventAsync(expectedEventGridEvent, expectedEventGridEvent.Subject);

            eventTriggerMock.Verify(trigger => trigger.Invoke(expectedEventGridEvent), Times.Once());
        }
    }
}
