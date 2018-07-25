using System;
using System.Collections.Generic;
using System.Text;
using Eventbus.AspNetCore.Abstractions;
using Eventbus.AspNetCore.Events;
using System.Linq;

namespace Eventbus.AspNetCore.DefaultEventBus
{
    public class InMemoryEventBusSubscriptionsManager : IEventBusSubscriptionsManager
    {
        public Dictionary<string, List<SubscriptionInfo>> _handlers { get; set; }


        public InMemoryEventBusSubscriptionsManager()
        {
            _handlers = new Dictionary<string, List<SubscriptionInfo>>();

        }

        public bool IsEmpty => !_handlers.Keys.Any();

        public bool HasSubscriptionsForEvent(string eventName) => _handlers.ContainsKey(eventName);

        public IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName) => _handlers[eventName];

        public void AddSubscription<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler
        {
            var eventName = GetEventKey<T>();
            DoAddSubscription(typeof(TH), eventName, false);
        }

        private void DoAddSubscription(Type handlerType, string eventName, bool isDynamic)
        {
            if (!HasSubscriptionsForEvent(eventName))
            {
                _handlers.Add(eventName, new List<SubscriptionInfo>());
            }

            if (_handlers[eventName].Any(s => s.HandlerType == handlerType))
            {
                throw new ArgumentException(
                    $"Handler Type {handlerType.Name} already registered for '{eventName}'", nameof(handlerType));
            }

            if (isDynamic)
            {
                _handlers[eventName].Add(SubscriptionInfo.Dynamic(handlerType));
            }
            else
            {
                _handlers[eventName].Add(SubscriptionInfo.Typed(handlerType));
            }
        }

        public IEnumerable<SubscriptionInfo> GetHandlersForEvent<T>() where T : IntegrationEvent
        {
            var key = GetEventKey<T>();
            return GetHandlersForEvent(key);
        }

        public bool HasSubscriptionsForEvent<T>() where T : IntegrationEvent
        {
            var key = GetEventKey<T>();
            return HasSubscriptionsForEvent(key);
        }

        public string GetEventKey<T>()
        {
            return typeof(T).Name;
        }
    }
}
