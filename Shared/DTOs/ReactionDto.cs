using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public class ReactionDto:IDto
    {
        public Guid Key { get; set; }
        public string Name { get; set; }
    }
}
