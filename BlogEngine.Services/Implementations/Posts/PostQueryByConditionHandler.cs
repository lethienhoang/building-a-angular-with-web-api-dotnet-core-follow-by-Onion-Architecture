using BlogEngine.Services.Abstracts;
using BlogEngine.Services.Dtos.Posts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Services.Implementations.Posts
{
    public class PostQueryByCondition : IPostQueryByCondition
    {
        public Task<PostDto> GetByCondition(PostQueryByConditionDto condition)
        {
            throw new NotImplementedException();
        }

        public Task<PostDto> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
