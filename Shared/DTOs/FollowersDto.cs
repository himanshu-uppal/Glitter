using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public class FollowersDto
    {
        public IEnumerable<UserDto> Followers { get; set; }
        public int FollowersCount { get; set; }
    }
}
