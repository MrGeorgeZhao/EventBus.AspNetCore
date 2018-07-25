using Eventbus.AspNetCore.Abstractions;
using Eventbus.AspNetCore.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventbus.AspNetCore
{
    public interface IEventBusSubscriptionsManager
    {

        bool IsEmpty { get; }

        void AddSubscription<T, TH>() where T : IntegrationEvent
            where TH : IIntegrationEventHandler;

        bool HasSubscriptionsForEvent<T>() where T : IntegrationEvent;

        IEnumerable<SubscriptionInfo> GetHandlersForEvent<T>() where T : IntegrationEvent;
        IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName);

        string GetEventKey<T>();


    }
}
