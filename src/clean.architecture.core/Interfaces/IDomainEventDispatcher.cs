using clean.architecture.core.SharedKernel;

namespace clean.architecture.core.Interfaces
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(BaseDomainEvent domainEvent);
    }
}
