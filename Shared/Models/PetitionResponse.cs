using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class PetitionResponse
    {
        public bool Success { get; set; }
        public string? URL { get; set; }
        public string? Message { get; set; }
        public Object? Result { get; set; }
    }
}
