using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class StatusCode
    {
        public string Status { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Importance { get; set; }

    }
}
