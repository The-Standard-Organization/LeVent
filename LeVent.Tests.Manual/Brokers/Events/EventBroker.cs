// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using LeVent.Clients;
using LeVent.Tests.Manual.Models.Students;

namespace LeVent.Tests.Manual.Brokers.Events
{
    public partial class EventBroker : IEventBroker
    {
        public EventBroker() =>
            this.StudentEventClient = new LeVentClient<Student>();
    }
}
