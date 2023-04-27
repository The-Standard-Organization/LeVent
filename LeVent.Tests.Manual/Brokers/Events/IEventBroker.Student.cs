// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

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
