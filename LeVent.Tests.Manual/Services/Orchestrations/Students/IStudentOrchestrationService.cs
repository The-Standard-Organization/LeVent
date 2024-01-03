// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

using System.Threading.Tasks;
using LeVent.Tests.Manual.Models.Students;

namespace LeVent.Tests.Manual.Services.Orchestrations.Students
{
    public interface IStudentOrchestrationService
    {
        ValueTask AddStudentAsync(Student student);
    }
}
