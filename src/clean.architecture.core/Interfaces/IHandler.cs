using clean.architecture.core.SharedKernel;

namespace clean.architecture.core.Interfaces
{
    public interface IHandler<T> where T : BaseDomainEvent
    {
        void Handle(T domainEvent);
    }
}
