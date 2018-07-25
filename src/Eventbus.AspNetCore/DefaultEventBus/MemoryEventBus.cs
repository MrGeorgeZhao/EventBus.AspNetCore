using Eventbus.AspNetCore.Abstractions;
using Eventbus.AspNetCore.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Eventbus.AspNetCore.DefaultEventBus
{
    public class MemoryEventBus : IEventBus
    {

        private readonly IEventBusSubscriptionsManager _subsManager;


        public MemoryEventBus(IEventBusSubscriptionsManager subscriptionsManager)
        {
            _subsManager = subscriptionsManager;

        }

        public void Publish<T>(T @event) where T : IntegrationEvent
        {
            if (_subsManager.IsEmpty)
                return;
            var eventName = _subsManager.GetEventKey<T>();
            var list = _subsManager.GetHandlersForEvent(eventName);

            if (list.Any())
            {
                list.ToList().ForEach(p =>
                {
                    var handler = Activator.CreateInstance(p.HandlerType) as IIntegrationEventHandler<T>;
                    handler.Hadle(@event);
                });
            }
        }

        public void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler
        {
            var eventName = _subsManager.GetEventKey<T>();
            _subsManager.AddSubscription<T, TH>();
        }
    }
}
