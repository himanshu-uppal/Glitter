using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public class ReactionTypesResponseDto
    {
        public IEnumerable<ReactionDto> ReactionTypes { get; set; }
    }
}
