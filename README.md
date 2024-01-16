![LeVent](https://raw.githubusercontent.com/hassanhabib/LeVent/master/LeVent/LeVent_git_logo.png)

[![.NET](https://github.com/hassanhabib/LeVent/actions/workflows/dotnet.yml/badge.svg)](https://github.com/hassanhabib/LeVent/actions/workflows/dotnet.yml)
[![Nuget](https://img.shields.io/nuget/v/LeVent?logo=nuget)](https://www.nuget.org/packages/LeVent/)
![Nuget](https://img.shields.io/nuget/dt/LeVent?color=blue&label=Downloads)
[![The Standard](https://img.shields.io/github/v/release/hassanhabib/The-Standard?filter=v2.10.0&style=default&label=Standard%20Version&color=2ea44f)](https://github.com/hassanhabib/The-Standard/tree/2.10.0)
[![The Standard - COMPLIANT](https://img.shields.io/badge/The_Standard-COMPLIANT-2ea44f)](https://github.com/hassanhabib/The-Standard)
[![The Standard Community](https://img.shields.io/discord/934130100008538142?color=%237289da&label=The%20Standard%20Community&logo=Discord)](https://discord.gg/vdPZ7hS52X)

# LeVent
LeVent is a simple .NET library designed to provide a local event subscribing/publishing capabilities to .NET developers.

## Standard-Compliance
This library was built according to The Standard. The library follows engineering principles, patterns and tooling as recommended by The Standard.

This library is also a community effort which involved many nights of pair-programming, test-driven development and in-depth exploration research and design discussions.

## Standard-Promise
The most important fulfillment aspect in a Standard complaint system is aimed towards contributing to people, its evolution, and principles.
An organization that systematically honors an environment of learning, training, and sharing knowledge is an organization that learns from the past, makes calculated risks for the future, 
and brings everyone within it up to speed on the current state of things as honestly, rapidly, and efficiently as possible. 
 
We believe that everyone has the right to privacy, and will never do anything that could violate that right.
We are committed to writing ethical and responsible software, and will always strive to use our skills, coding, and systems for the good.
We believe that these beliefs will help to ensure that our software(s) are safe and secure and that it will never be used to harm or collect personal data for malicious purposes.
 
The Standard Community as a promise to you is in upholding these values.
## How it Works
It's important to understand the ideas around the [Cul-De-Sac pattern](https://www.youtube.com/watch?v=Wgz5m0MY9Xo&ab_channel=HassanHabib) in order for you to take the most advantage of LeVent.

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


![image](https://user-images.githubusercontent.com/1453985/194765922-b5c0f67b-79f0-49b1-80ba-8fffc4546c7c.png)

If you have any suggestions, comments or questions, please feel free to contact me on:

[Twitter](https://twitter.com/hassanrezkhabib)

[LinkedIn](https://www.linkedin.com/in/hassanrezkhabib/)

[E-Mail](mailto:hassanhabib@live.com)

### Important Notice
Special thanks to all the contributors that make this project a success. A special thanks to Mr. Hassan Habib and Mr. Kailu Hu for their dedicated contribution.