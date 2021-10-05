using System;

namespace SharedKernel.Events
{
    public interface IDomainEvent
    {
        DateTime CreatedAt { get; }
    }
}