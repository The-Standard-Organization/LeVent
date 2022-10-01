// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Threading.Tasks;
using LeVent.Tests.Manual.Models.Students;

namespace LeVent.Tests.Manual.Brokers.Events
{
    public partial interface IEventBroker
    {
        void RegisterStudentHandler(Func<Student, ValueTask> studentHandler);
        ValueTask PublishStudentEventAsync(Student student);
    }
}
