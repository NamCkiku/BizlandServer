namespace Bizland.Domain.Core
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}