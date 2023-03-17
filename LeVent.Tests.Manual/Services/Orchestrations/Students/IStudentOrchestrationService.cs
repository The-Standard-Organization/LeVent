// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using LeVent.Tests.Manual.Models.Students;
using System.Threading.Tasks;

namespace LeVent.Tests.Manual.Services.Orchestrations.Students
{
    public interface IStudentOrchestrationService
    {
        ValueTask AddStudentAsync(Student student);
    }
}
