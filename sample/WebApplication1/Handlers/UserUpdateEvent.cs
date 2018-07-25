using Eventbus.AspNetCore.Abstractions;
using Eventbus.AspNetCore.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Handlers
{
    public class UserUpdateEvent : IntegrationEvent
    {
        public string Name { get; set; }
    }

    public class UserUpdateEventHandler : IIntegrationEventHandler<UserUpdateEvent>
    {
        public Task Hadle(UserUpdateEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
