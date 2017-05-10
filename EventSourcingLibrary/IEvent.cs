using System;

namespace WheresMyCar.EventSourcingLibrary
{
    /// <summary>
    /// This is how an event for a given entity type should look like.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IEvent<TEntity>
    {
        Guid Id { get; }

        Guid EntityId { get; }
        DateTime EventTime { get; }

        /// <summary>
        /// Applies this event to an entity and returns it. This means that all the entity modifications associated
        /// to this kind of event will be permormed on the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The entity after applying the event.</returns>
        TEntity ApplyTo(TEntity entity);
    }
}