using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public class FolloweesDto
    {
        public IEnumerable<UserDto> Followees { get; set; }
        public int FolloweesCount { get; set; }
    }
}
