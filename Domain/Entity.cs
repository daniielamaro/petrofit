using System;

namespace Domain
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime DataCreate { get; set; }
        public DateTime? DataUpdate { get; set; }
    }
}
