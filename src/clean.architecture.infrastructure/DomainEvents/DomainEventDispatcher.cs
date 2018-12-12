using clean.architecture.core.Interfaces;
using clean.architecture.core.SharedKernel;
using StructureMap;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System;

namespace clean.architecture.infrastructure.DomainEvents
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private IContainer _container;

        public DomainEventDispatcher(IContainer container)
        {
            _container = container;
        }

        public void Dispatch(BaseDomainEvent domainEvent)
        {
            var handleType = typeof(IHandler<>).MakeGenericType(domainEvent.GetType());
            var wrapperType = typeof(DomainEventHandler<>).MakeGenericType(domainEvent.GetType());
            var handlers = _container.GetAllInstances(handleType);
            var wrappedHandlers = handlers
                .Cast<object>()
                .Select(handler => (DomainEventHandler)Activator.CreateInstance(wrapperType, handler));

            foreach (var handler in wrappedHandlers)
                handler.Handle(domainEvent);
        }

        private abstract class DomainEventHandler
        {
            public abstract void Handle(BaseDomainEvent domainEvent);
        }

        private class DomainEventHandler<T> : DomainEventHandler where T : BaseDomainEvent
        {
            private readonly IHandler<T> _handler;

            public DomainEventHandler(IHandler<T> handler)
            {
                _handler = handler;
            }

            public override void Handle(BaseDomainEvent domainEvent)
            {
                _handler.Handle((T)domainEvent);
            }
        }
    }
}
