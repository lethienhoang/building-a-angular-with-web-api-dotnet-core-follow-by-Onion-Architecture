using System;
using System.Collections.Generic;
using System.Text;

namespace BlogEngine.Services.ViewModels
{
    public class BaseViewModel
    {
        public Guid Id { get; set; }

        public DateTime CreatedBy { get; set; }
        public DateTime UpdatedBy { get; set; }

    }
}
