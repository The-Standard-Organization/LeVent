// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

using System.Threading.Tasks;
using LeVent.Tests.Manual.Services.Foundations.StudentEvents;
using LeVent.Tests.Manual.Services.Foundations.StudentLibraries;

namespace LeVent.Tests.Manual.Services.Orchestrations.StudentLibraries
{
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
    }
}
