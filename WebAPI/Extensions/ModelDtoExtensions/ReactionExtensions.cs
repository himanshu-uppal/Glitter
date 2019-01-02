using Glitter.DataAccess.Entities;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glitter.Business.Extensions.ModelDtoExtensions
{
    public static class ReactionExtensions
    {
        public static ReactionDto ToReactionDto(this Reaction reaction)
        {
            return new ReactionDto
            {
                Key = reaction.Key,
                Name = reaction.Name

            };
        }
    }
}
