using System;
using System.Collections.Generic;
using System.Text;

namespace BlogEngine.Core.Entities
{
    public interface IEntityBase
    {
        Guid Id { get; set; }
        DateTime CreatedBy { get; set; }
        DateTime UpdatedBy { get; set; }
    }
}
    