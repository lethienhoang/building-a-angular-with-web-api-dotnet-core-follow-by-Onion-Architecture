using System;
using System.Collections.Generic;
using System.Text;

namespace BlogEngine.Services.Dtos
{
    public class BaseDto
    {
        public Guid Id { get; set; }

        public DateTime CreatedBy { get; set; }
        public DateTime UpdatedBy { get; set; }

    }
}
