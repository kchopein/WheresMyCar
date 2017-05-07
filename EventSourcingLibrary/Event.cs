using System;

namespace EventSourcingLibrary
{
    /// <summary>
    /// An base class for the events to be stored in the event store.
    /// Classes extending this one should define the event's payload type and the modifications
    /// that should be done to the entity as a result of this event.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TPayload">The type of the payload.</typeparam>
    /// <seealso cref="EventSourcingLibrary.IEvent{TEntity}" />
    public abstract class Event<TEntity, TPayload> : IEvent<TEntity>
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid EntityId { get; private set; }
        public DateTime EventTime { get; private set; } = DateTime.UtcNow;

        /// <summary>
        /// The event's payload or information associated to this event.
        /// </summary>
        /// <value>
        /// The payload.
        /// </value>
        public TPayload Payload { get; private set; }

        protected Event(Guid entityId, TPayload eventPayload)
        {
            Payload = eventPayload;
            EntityId = entityId;
        }

        /// <summary>
        /// Applies this event to an entity and returns it. This means that all the entity modifications associated
        /// to this kind of event will be permormed on the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// The entity after applying the event.
        /// </returns>
        public abstract TEntity ApplyTo(TEntity entity);
    }
}