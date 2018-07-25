using Eventbus.AspNetCore.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Eventbus.AspNetCore.Abstractions
{
    public interface IIntegrationEventHandler<T> : IIntegrationEventHandler where T : IntegrationEvent
    {
        Task Hadle(T @event);
    }

    public interface IIntegrationEventHandler
    {

    }
}
