using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public class PeopleSearchResponseDto
    {
        public IEnumerable<UserDto> People { get; set; }
       public  int PeopleCount { get; set; }
    }
}
