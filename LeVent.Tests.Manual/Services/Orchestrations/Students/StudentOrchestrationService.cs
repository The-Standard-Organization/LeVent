// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

using System.Threading.Tasks;
using LeVent.Tests.Manual.Models.Students;
using LeVent.Tests.Manual.Services.Foundations.StudentEvents;
using LeVent.Tests.Manual.Services.Foundations.Students;

namespace LeVent.Tests.Manual.Services.Orchestrations.Students
{
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
}
