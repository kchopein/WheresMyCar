﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace WheresMyCar.EventSourcingLibrary
{
    /// <summary>
    /// Event store for a type of entity. It keeps a list of events and provides the entity by instantiating it and
    /// applying all the equence of events.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class EventStore<TEntity> where TEntity : new()
    {
        [BsonId]
        public Guid Id { get; private set; } = Guid.NewGuid();

        protected IList<IEvent<TEntity>> EventsList { get; private set; } = new List<IEvent<TEntity>>();

        [BsonIgnore]
        public IEnumerable<IEvent<TEntity>> Events => EventsList;

        /// <summary>
        /// Returns an entity built by applying all the sequence of events in the store.
        /// </summary>
        /// <returns>The entity in its current state.</returns>
        public TEntity GetEntity()
        {
            var entity = new TEntity();
            foreach (IEvent<TEntity> e in EventsList)
            {
                entity = e.ApplyTo(entity);
            }
            return entity;
        }
    }
}