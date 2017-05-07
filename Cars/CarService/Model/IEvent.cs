using System;

namespace CarService.Model
{
    public interface IEvent<TEntity>
    {
        Guid EntityId { get; }
        DateTime EventTime { get; }
        Guid Id { get; }

        TEntity ApplyTo(TEntity entity);
    }
}