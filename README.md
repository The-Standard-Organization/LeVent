<p align="center">
  <img width="25%" height="25%" src="https://github.com/hassanhabib/LeVent/blob/master/LeVent/LeVent.png?raw=true">
</p>

[![.NET](https://github.com/hassanhabib/LeVent/actions/workflows/dotnet.yml/badge.svg)](https://github.com/hassanhabib/LeVent/actions/workflows/dotnet.yml)
[![Nuget](https://img.shields.io/nuget/v/LeVent?logo=nuget)](https://www.nuget.org/packages/LeVent/)
[![The Standard - COMPLIANT](https://img.shields.io/badge/The_Standard-COMPLIANT-2ea44f)](https://github.com/hassanhabib/The-Standard)
[![The Standard Community](https://img.shields.io/discord/934130100008538142?color=%237289da&label=The%20Standard%20Community&logo=Discord)](https://discord.gg/vdPZ7hS52X)

# LeVent
LeVent is a simple .NET library designed to provide a local event subscribing/publishing capabilities to .NET developers.

## How it Works
It's important to understand the ideas around the [Cul-De-Sac pattern](youtube.com/watch?v=Wgz5m0MY9Xo&ab_channel=HassanHabib) in order for you to take the most advantage of LeVent.

Assume that you have multiple Foundation Services that want to be notified when an event of any type occurs. You can create a simple `EventBroker` that leverages LeVent to offer the registeration and publishing capabilities as follows:

![image](https://user-images.githubusercontent.com/1453985/193402310-3e7e0617-f04c-4187-a381-5ad6e7936573.png)

In the figure above, the `EventBroker` leverages LeVent to offer subscribing and publishing capabilities as follows:

```csharp
        public ILeVentClient<Student> StudentEventClient { get; set; }

        public async ValueTask PublishStudentEventAsync(Student student) =>
            await this.StudentEventClient.PublishEventAsync(student);

        public void RegisterStudentHandler(Func<Student, ValueTask> studentHandler) =>
            this.StudentEventClient.RegisterEventHandler(studentHandler);
```

Then, an `StudentEventService` will leverage the `EventBroker` to allow higher-order services to register/listen or publish through that eventing mechanism as follows:

```csharp
    public class StudentEventService : IStudentEventService
    {
        private readonly IEventBroker eventBroker;

        public StudentEventService(IEventBroker eventBroker) =>
            this.eventBroker = eventBroker;

        public async ValueTask PublishStudentEventAsync(Student student) =>
            await this.eventBroker.PublishStudentEventAsync(student);

        public void RegisterStudentEventHandler(Func<Student, ValueTask> studentEventHandler) =>
            this.eventBroker.RegisterStudentHandler(studentEventHandler);
    }

```

The next step would be for Orchestration services to either publish or listen to the event and call it's dependencies.

In the case of a publisher - a `StudentOrchestrationService` would be as follows:

```csharp
    public class StudentOrchestrationService : IStudentOrchestrationService
    {
        private readonly IStudentEventService studentEventService;
        private readonly IStudentService studentService;

        public StudentOrchestrationService(
            IStudentEventService studentEventService,
            IStudentService studentService)
        {
            this.studentEventService = studentEventService;
            this.studentService = studentService;
        }

        public async ValueTask AddStudentAsync(Student student)
        {
            this.studentService.AddStudent(student);
            await this.studentEventService.PublishStudentEventAsync(student);
        }
    }
```
The Orchestration service above will add a `Student` first then publish an event about that student to all listeners.

Let's check out what a listener would look like:

```csharp
    public class StudentLibraryOrchestrationService : IStudentLibraryOrchestrationService
    {
        private readonly IStudentEventService studentEventService;
        private readonly IStudentLibraryService studentLibraryService;

        public StudentLibraryOrchestrationService(
            IStudentEventService studentEventService,
            IStudentLibraryService studentLibraryService)
        {
            this.studentEventService = studentEventService;
            this.studentLibraryService = studentLibraryService;
        }

        public void ListenToStudentEvents()
        {
            this.studentEventService.RegisterStudentEventHandler((student) =>
            {
                this.studentLibraryService.RegisterStudentLibaryCard(student);

                return ValueTask.CompletedTask;
            });
        }
```

The `StudentLibraryOrchestrationService` will receive a `Student` event from whomever is publishing these events with no coupling and acts upon that very same event by creating a `LibraryCard`.

This pattern is called [Cul-De-Sac](https://github.com/hassanhabib/The-Standard/blob/master/2.%20Services/2.3%20Orchestrations/2.3%20Orchestrations.md#2322-cul-de-sac). It's an advanced low-level architecture technique to allow scaling and chaining to infinite number of events with no coupling whatsoever - here's how it looks in the 3D space:


![image](https://user-images.githubusercontent.com/1453985/193402672-062e7db2-7e47-4b50-bbd6-a376b198814c.png)

The figure above assume no dependcy between one listener and the other. You can also leverage LeVent to allow chaining of listeners as follows:

![image](https://user-images.githubusercontent.com/1453985/193402792-7e808de6-d649-4766-bcda-a29448fe8571.png)

These patterns allow for a more maintainble standardized systems - completely decoupled from it's event source and capable of passing forward an event as an interceptor or completing a task and forwarding.


Here's the Low-Level Architecture of this library

<br />

![image](https://user-images.githubusercontent.com/1453985/194765922-b5c0f67b-79f0-49b1-80ba-8fffc4546c7c.png)
