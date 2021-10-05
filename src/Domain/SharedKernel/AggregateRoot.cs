using SharedKernel.Events;
using System.Collections.Generic;

namespace SharedKernel
{
    /// <summary>
    /// Aggregate root base class
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRootData
    {
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        private List<IDomainEvent> _domainEvents;
    }
}