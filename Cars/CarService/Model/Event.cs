using System;

namespace CarService.Model
{
    public abstract class Event<TEntity, TPayload> : IEvent<TEntity>
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();
        public Guid EntityId { get; protected set; }
        public DateTime EventTime { get; protected set; } = DateTime.UtcNow;

        public TPayload Payload { get; protected set; }
        protected Event(Guid entityId, TPayload eventPayload) 
        {
            Payload = eventPayload;
            EntityId = entityId;
        }

        public abstract TEntity ApplyTo(TEntity entity);
    }
}