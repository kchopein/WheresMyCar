using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Model
{
    public abstract class Event<T> : Event
    {
        [NotMapped]
        public T Payload
        {
            get
            {
                return JsonConvert.DeserializeObject<T>(this.SerializedPayload);
            }
            private set { JsonConvert.SerializeObject(value); }
        }

        protected Event(Guid entityId, T eventPayload) : base(entityId)
        {
            Payload = eventPayload;
        }
    }

    public abstract class Event
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();
        public Guid EntityId { get; protected set; }
        public DateTime EventTime { get; protected set; }
        public string SerializedPayload { get; protected set; }

        protected Event(Guid entityId)
        {
            EntityId = entityId;
            this.EventTime = DateTime.UtcNow;
        }
    }

}