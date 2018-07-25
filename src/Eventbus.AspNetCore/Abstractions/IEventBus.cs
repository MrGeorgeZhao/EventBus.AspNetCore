using Eventbus.AspNetCore.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventbus.AspNetCore.Abstractions
{
    public interface IEventBus
    {
        void Publish<T>(T @event) where T : IntegrationEvent;

        void Subscribe<T, TH>()
          where T : IntegrationEvent
          where TH : IIntegrationEventHandler;
    }
}
