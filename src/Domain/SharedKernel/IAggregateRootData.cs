using SharedKernel.Events;
using System.Collections.Generic;

namespace SharedKernel
{
    /// <summary>
    ///  Aggregate root interface
    /// </summary>
    public interface IAggregateRootData
    {
        List<IDomainEvent> DomainEvents { get; }
    }
}