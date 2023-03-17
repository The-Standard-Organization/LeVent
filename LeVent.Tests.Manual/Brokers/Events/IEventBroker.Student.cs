// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using LeVent.Tests.Manual.Models.Students;
using System;
using System.Threading.Tasks;

namespace LeVent.Tests.Manual.Brokers.Events
{
    public partial interface IEventBroker
    {
        void RegisterStudentHandler(Func<Student, ValueTask> studentHandler);
        ValueTask PublishStudentEventAsync(Student student);
    }
}
