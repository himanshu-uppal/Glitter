using Glitter.DataAccess.Entities;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glitter.Business.Extensions.ModelDtoExtensions
{
    public static class CommentExtensions
    {
        public static CommentDto ToCommentDto(this Comment comment)
        {
            return new CommentDto
            {
                User = comment.User.ToUserDto(),
                Message = comment.Message

            };

        }
    }
}
