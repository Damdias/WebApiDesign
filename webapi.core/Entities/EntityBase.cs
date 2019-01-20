using System;

namespace webapi.core.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; }
    }

}
