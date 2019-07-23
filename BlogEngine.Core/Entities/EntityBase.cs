using System;
using System.Collections.Generic;
using System.Text;

namespace BlogEngine.Core.Entities
{
    public abstract class EntityBase  : IEntityBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedBy { get; set; }
        public DateTime UpdatedBy { get; set; }
    }
}
