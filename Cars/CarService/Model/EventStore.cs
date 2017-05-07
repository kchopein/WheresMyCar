using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace CarService.Model
{
    public class EventStore<TEntity> where TEntity: new()
    {
        [BsonId]
        public Guid Id { get; private set; } = Guid.NewGuid();
        public IList<IEvent<TEntity>> Events { get; private set; } = new List<IEvent<TEntity>>();

        public TEntity GetEntity()
        {
            var entity = new TEntity();
            foreach (IEvent<TEntity> e in Events)
            {
                entity = e.ApplyTo(entity);
            }
            return entity;
        }
    }
}