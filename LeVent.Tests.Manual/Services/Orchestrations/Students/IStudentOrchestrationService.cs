// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System.Threading.Tasks;
using LeVent.Tests.Manual.Models.Students;

namespace LeVent.Tests.Manual.Services.Orchestrations.Students
{
    public interface IStudentOrchestrationService
    {
        ValueTask AddStudentAsync(Student student);
    }
}
