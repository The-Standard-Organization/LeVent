// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Threading.Tasks;
using LeVent.Tests.Manual.Brokers.Events;
using LeVent.Tests.Manual.Models.Students;

namespace LeVent.Tests.Manual.Services.Foundations.StudentEvents
{
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
}
