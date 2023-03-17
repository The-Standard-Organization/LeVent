// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using LeVent.Tests.Manual.Models.Students;
using System;
using System.Threading.Tasks;

namespace LeVent.Tests.Manual.Services.Foundations.StudentEvents
{
    public interface IStudentEventService
    {
        void RegisterStudentEventHandler(Func<Student, ValueTask> studentEventHandler);
        ValueTask PublishStudentEventAsync(Student student);
    }
}
