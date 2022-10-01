// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Threading.Tasks;
using LeVent.Tests.Manual.Models.Students;

namespace LeVent.Tests.Manual.Services.Foundations.StudentEvents
{
    public interface IStudentEventService
    {
        void RegisterStudentEventHandler(Func<Student, ValueTask> studentEventHandler);
        ValueTask PublishStudentEventAsync(Student student);
    }
}
