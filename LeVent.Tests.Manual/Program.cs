// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using LeVent.Tests.Manual.Brokers.Events;
using LeVent.Tests.Manual.Models.Students;
using LeVent.Tests.Manual.Services.Foundations.StudentEvents;
using LeVent.Tests.Manual.Services.Foundations.StudentLibraries;
using LeVent.Tests.Manual.Services.Foundations.Students;
using LeVent.Tests.Manual.Services.Orchestrations.StudentLibraries;
using LeVent.Tests.Manual.Services.Orchestrations.Students;

namespace LeVent.Tests.Manual
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var someStudent = new Student
            {
                Id = Guid.NewGuid(),
                Name = "Kailu Hu"
            };

            var eventBroker = new EventBroker();
            var studentService = new StudentService();
            var studentLibraryService = new StudentLibraryService();
            var studentEventService = new StudentEventService(eventBroker);

            var studentLibraryOrchestrationService =
                new StudentLibraryOrchestrationService(
                    studentEventService,
                    studentLibraryService);

            var studentOrchestrationService =
                new StudentOrchestrationService(
                    studentEventService,
                    studentService);

            studentLibraryOrchestrationService.ListenToStudentEvents();
            await studentOrchestrationService.AddStudentAsync(someStudent);
        }
    }
}